using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertising.Bll.BusinessLogic.Interfaces;
using AdvertisingService.Models;
using AdvertisingService.Models.AuthorizationModels;
using Common.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AdvertisingService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private UserManager<ApplicationUser> _userManager;
        private IBusinessLogic db;

        public UserProfileController(UserManager<ApplicationUser> userManager, IBusinessLogic db)
        {
            _userManager = userManager;
            this.db = db;
        }

        [HttpGet]
        [Authorize]
        public async Task<Object> GetUserProfile()
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;

            var user = await _userManager.FindByIdAsync(userId);

            return new
            {
                userId,
                user.FullName,
                user.Email,
                user.UserName
            };
        }

        [HttpGet]
        [Authorize]
        [Route("GetCreatorInfo")]
        public async Task<Object> GetCreatorInfo()
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;

            IEnumerable<AuctionLot> auctionLots = await db.AuctionLots.GetAllAsync();

            var lots = auctionLots.Where(x => x.Opened == false && x.WinnerId == userId).ToList();

            List<ApplicationUser> users = new List<ApplicationUser>();

            foreach (AuctionLot i in lots)
            {
                users.Add(await _userManager.FindByIdAsync(i.CreaterId));
            }

            Message message = new Message(lots, users);

            return Ok(users);
        }

        [HttpPost]
        [Authorize]
        [Route("ChangePassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordModel model)
        {
            if(model == null || model.NewPassword == null || model.NewPassword == "")
            {
                return BadRequest(new { message = "Не введён пароль." });
            }

            ApplicationUser user = await _userManager.FindByIdAsync(User.Claims.First(c => c.Type == "UserID").Value);
            if (user != null)
            {
                var _passwordValidator =
                    HttpContext.RequestServices.GetService(typeof(IPasswordValidator<ApplicationUser>)) as IPasswordValidator<ApplicationUser>;
                var _passwordHasher =
                    HttpContext.RequestServices.GetService(typeof(IPasswordHasher<ApplicationUser>)) as IPasswordHasher<ApplicationUser>;

                IdentityResult result =
                    await _passwordValidator.ValidateAsync(_userManager, user, model.NewPassword);
                if (result.Succeeded)
                {
                    user.PasswordHash = _passwordHasher.HashPassword(user, model.NewPassword);
                    await _userManager.UpdateAsync(user);
                    return Ok(result.Succeeded);
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        return BadRequest(new { message = error.Description });
                    }
                }
            }
            else
            {
                return BadRequest(new { message = "Пользователь не найден." });
            }

            return Ok(model);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("ForAdmin")]
        public string GetForAdminOrModer()
        {
            return "Web method for Admin";
        }

        [HttpGet]
        [Authorize(Roles = "Admin,User")]
        [Route("ForUsers")]
        public string GetForEveryone()
        {
            return "Web method for everyone";
        }
    }
}