namespace WebShopAdminApi.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("getcategories")]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _shopService.GetAllCategoriesAsync();
            var result = categories.Select(c => new { Id = c.Id, Name = c.Name }).ToList();
            return Ok(new { Categories = result });
        }
    }
}
