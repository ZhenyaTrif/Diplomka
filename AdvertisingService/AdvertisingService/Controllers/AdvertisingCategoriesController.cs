using Advertising.Bll.BusinessLogic.Interfaces;
using Common.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvertisingService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertisingCategoriesController : ControllerBase
    {
        private IBusinessLogic db;

        public AdvertisingCategoriesController(IBusinessLogic db)
        {
            this.db = db;
        }

        // GET: api/AdvertisingCategories
        [HttpGet]
        public async Task<IEnumerable<AdvertisingCategory>> Get()
        {
            return await db.AdvertisingCategories.GetAllAsync();
        }

        // GET: api/AdvertisingCategories/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var advertisingCategory = await db.AdvertisingCategories.GetItemByIdAsync(id);

            if (advertisingCategory == null)
            {
                return NotFound();
            }

            return Ok(advertisingCategory);
        }

        // PUT: api/AdvertisingCategories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, AdvertisingCategory advertisingCategory)
        {
            if (advertisingCategory == null)
            {
                return BadRequest();
            }

            if (id != advertisingCategory.Id)
            {
                return BadRequest();
            }

            await db.AdvertisingCategories.UpdateAsync(advertisingCategory);

            return Ok(advertisingCategory);
        }

        // POST: api/AdvertisingCategories
        [HttpPost]
        public async Task<IActionResult> Post(AdvertisingCategory advertisingCategory)
        {
            AdvertisingCategory _advertisingCategory;

            if (advertisingCategory == null)
            {
                _advertisingCategory = await db.AdvertisingCategories.CreateAsync(new AdvertisingCategory { CategoryName = "Новая категория" });

                return Ok(_advertisingCategory);
            }

            _advertisingCategory = await db.AdvertisingCategories.CreateAsync(advertisingCategory);

            return Ok(_advertisingCategory);
        }

        // DELETE: api/AdvertisingCategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            AdvertisingCategory advertisingCategory = await db.AdvertisingCategories.GetItemByIdAsync(id);

            if (advertisingCategory == null)
            {
                return NotFound();
            }

            IEnumerable<AdvertisingModel> advertisings = await db.Advertisings.GetByAdvertisingCategoryIdAsync(id);

            if ((advertisings.ToList()).Count != 0)
            {
                foreach (var advertising in advertisings)
                {
                    advertising.AdvertisingCategoryId = 0;
                    await db.Advertisings.UpdateAsync(advertising);
                }
            }
            await db.AdvertisingCategories.DeleteAsync(advertisingCategory.Id);

            return Ok();
        }
    }
}
