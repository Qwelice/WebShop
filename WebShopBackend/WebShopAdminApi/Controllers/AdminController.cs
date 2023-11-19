namespace WebShopAdminApi.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MongoDB.Bson.IO;
    using System.Text.Json;
    using System.Text.Json.Serialization;
    using WebShopAdminApi.Models;
    using WebShopBLL.DTO;
    using WebShopBLL.Services.Interfaces;

    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "admin")]
    public class AdminController : ControllerBase
    {
        private IWebShopService _shopService;
        public AdminController(IWebShopService shopService) 
        {
            _shopService = shopService;
        }

        [HttpPost("newcategory")]
        public async Task<IActionResult> NewCategory([FromBody] NewCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var category = new CategoryDTO { Name = model.CategoryName.Trim().ToLower() };
                try
                {
                    await _shopService.CreateNewCategoryAsync(category);
                }catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
                return Ok(new { Succeed = true, Category = category.Name });
            }
            return BadRequest("Некорректные данные");
        }

        [HttpPost("categories")]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _shopService.GetAllCategoriesAsync();
            var result = categories.Select(c => new { Id = c.Id, Name = c.Name }).ToList();
            return Ok(new { Categories = result });
        }

        [HttpPost("newproduct")]
        public async Task<IActionResult> NewProduct([FromForm]NewProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var file = GetPhotoData(model.Photo);
                    var product = new ProductDTO 
                    { 
                        Name = model.Name.Trim().ToLower(),
                        Description = model.Description.Trim().ToLower(),
                        Price = model.Price,
                        PhotoData = file,
                        Categories = model.Categories.Select(c => new CategoryDTO { Id = c.Id, Name = c.Name }).ToList()
                    };
                    await _shopService.CreateNewProductAsync(product);

                }catch(Exception ex)
                {
                    return BadRequest(ex.Message);
                }

            }
            return Ok();
        }

        [HttpGet("products")]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _shopService.GetAllProductsAsync();
            return Ok(new { Products = products });
        }

        [HttpPost("products/{query}")]
        public async Task<IActionResult> GetProductsByQuery(string query)
        {
            var products = await _shopService.GetProductsByQueryAsync(query);

            return Ok(new { Products = products });
        }

        [NonAction]
        private byte[] GetPhotoData(IFormFile file)
        {
            if (file == null || file.Length <= 0)
            {
                throw new ArgumentException("Некорректный файл фотографии");
            }
            using(var memoryStrem = new MemoryStream())
            {
                file.CopyTo(memoryStrem);
                return memoryStrem.ToArray();
            }
        }
    }
}
