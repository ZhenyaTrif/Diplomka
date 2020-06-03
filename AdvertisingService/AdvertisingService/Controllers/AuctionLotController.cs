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
            return await db.AuctionLots.GetAllAsync();
        }

        [HttpGet]
        [Route("categoryid={categoryId}/page={page}")]
        [Route("categoryid={categoryId}/title={title}/page={page}")]
        public async Task<IActionResult> ChangePage(string title = null, int? categoryId = 0, int page = 1)
        {
            int pageSize = 10;

            IEnumerable<AuctionLot> ads = await db.AuctionLots.GetAllAsync();

            if (categoryId != null && categoryId != 0)
            {
                ads = ads.Where(p => p.LotCategoryId == categoryId);
            }
            if (!String.IsNullOrEmpty(title))
            {
                ads = ads.Where(p => p.LotName.Contains(title));
            }

            var count = ads.Count();

            var items = ads.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            SearchListModel<AuctionLot> viewModel = new SearchListModel<AuctionLot>
            {
                PageModel = new PageModel(count, page, pageSize),
                FilterModel = new FilterModel(await db.AdvertisingCategories.GetAllAsync(), categoryId, title),
                Ads = items
            };

            return Ok(viewModel);


            //return await db.AuctionLots.GetAllAsync();
        }

        // GET: api/AuctionLot/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            AuctionLot auctionLot = await db.AuctionLots.GetItemByIdAsync(id);

            if (auctionLot == null)
            {
                return NotFound();
            }

            var category = await db.AdvertisingCategories.GetItemByIdAsync(auctionLot.LotCategoryId);

            LotFullModel adFullModel = new LotFullModel
            {
                Id = auctionLot.Id,
                LotName = auctionLot.LotName,
                Text = auctionLot.Text,
                ImagePath = auctionLot.ImagePath,
                StartPrice = auctionLot.StartPrice,
                LotCategoryId = auctionLot.LotCategoryId,
                CategoryName = category.CategoryName,
                Opened = auctionLot.Opened
            };

            return Ok(adFullModel);
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
                    LotCategoryId = 0
                });

                return Ok(auctionLot);
            }
            else if (auctionLotModel.ImagePath == null || auctionLotModel.ImagePath == "")
            {
                auctionLotModel.ImagePath = "/assets/images/no_photo.png";
            }

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