using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertising.Bll.BusinessLogic.Interfaces;
using AdvertisingService.Models;
using Common.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdvertisingService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuctionLotController : ControllerBase
    {
        private IBusinessLogic db;

        public AuctionLotController(IBusinessLogic db)
        {
            this.db = db;
        }

        // GET: api/AuctionLot
        [HttpGet]
        public async Task<IEnumerable<AuctionLot>> Get()
        {
            IEnumerable<AuctionLot> auctionLots = await db.AuctionLots.GetAllAsync();

            var lots = auctionLots.Where(x => x.Opened == true);

            return lots;
        }


        // GET: api/AuctionLot/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            IEnumerable<AuctionLot> auctionLots = await db.AuctionLots.GetAllAsync();

            var lots = auctionLots.Where(x => x.Id == id).ToList();
            var lot = lots[0];

            var category = await db.AdvertisingCategories.GetItemByIdAsync(lot.LotCategoryId);

            LotFullModel lotFullModel = new LotFullModel
            {
                Id = lot.Id,
                LotName = lot.LotName,
                Text = lot.Text,
                ImagePath = lot.ImagePath,
                StartPrice = lot.StartPrice,
                LotCategoryId = lot.LotCategoryId,
                CategoryName = category.CategoryName,
                Checked = lot.Checked,
                CreaterId = lot.CreaterId,
                Opened = lot.Opened,
                WinnerId = lot.WinnerId

            };

            return Ok(lotFullModel);
        }

        [HttpGet("mess={id}")]
        public async Task<IActionResult> GetMess(string id)
        {
            IEnumerable<AuctionLot> auctionLots = await db.AuctionLots.GetAllAsync();

            var lots = auctionLots.Where(x => x.WinnerId == id).ToList();

            return Ok(lots);
        }

        // PUT: api/AuctionLot/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, AuctionLot auctionLot)
        {
            if (auctionLot == null)
            {
                return BadRequest();
            }

            if (id != auctionLot.Id)
            {
                return BadRequest();
            }

            await db.AuctionLots.UpdateAsync(auctionLot);

            return Ok(auctionLot);
        }

        // POST: api/AuctionLot
        [HttpPost]
        public async Task<IActionResult> Post(AuctionLot auctionLotModel)
        {
            AuctionLot auctionLot;

            if (auctionLotModel == null)
            {
                auctionLot = await db.AuctionLots.CreateAsync(new AuctionLot
                {
                    LotName = "",
                    Text = "",
                    ImagePath = "",
                    StartPrice = "",
                    LotCategoryId = 0,
                    Opened = true,
                    Checked = true,
                    CreaterId = "",
                    WinnerId = ""
                });

                return Ok(auctionLot);
            }
            else if (auctionLotModel.ImagePath == null || auctionLotModel.ImagePath == "")
            {
                auctionLotModel.ImagePath = "/assets/images/no_photo.png";
            }
            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            auctionLotModel.CreaterId = userId;
            auctionLot = await db.AuctionLots.CreateAsync(auctionLotModel);

            return Ok(auctionLot);
        }

        // DELETE: api/AuctionLot/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            await db.AuctionLots.DeleteAsync(id);

            return Ok();
        }
    }
}