namespace WebShopAdminApi.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using WebShopAdminApi.Models;
    using WebShopBLL.DTO;
    using WebShopBLL.Services.Interfaces;

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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
                await _shopService.CreateNewCategoryAsync(category);
                return Ok(new { Succeed = true });
            }
            return BadRequest("Некорректные данные");
        }
    }
}
