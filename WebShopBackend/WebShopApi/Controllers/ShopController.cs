namespace WebShopApi.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using WebShopBLL.DTO;
    using WebShopBLL.Infrastructure;
    using WebShopBLL.Services.Interfaces;

    [Route("api/[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        private IWebShopService _shopService;
        private int _itemsPerPage = 10;

        public ShopController(IWebShopService shopService)
        {
            _shopService = shopService;
        }

        [HttpPost("products")]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _shopService.GetAllProductsAsync();
            var pagination = new PaginationHelper<ProductDTO>(products, _itemsPerPage);
            int pageIndex = 0;
            return Ok(new { Products = products.Take(_itemsPerPage), PageCount = pagination.PageCount, CurrentPage = pageIndex + 1 });
        }

        [HttpPost("products/{page:int}")]
        public async Task<IActionResult> GetProductsByPage(int page)
        {
            int pageIndex = page - 1;
            var products = await _shopService.GetAllProductsAsync();
            var pagination = new PaginationHelper<ProductDTO>(products, _itemsPerPage);
            var result = products.Skip(pageIndex * _itemsPerPage).Take(_itemsPerPage);
            return Ok(new { Products = result, PageCount = pagination.PageCount, CurrentPage = pageIndex + 1 });
        }

        [HttpPost("products/{query}")]
        public async Task<IActionResult> GetProductsByQuery(string query)
        {
            var products = await _shopService.GetProductsByQueryAsync(query);
            var pagination = new PaginationHelper<ProductDTO>(products, _itemsPerPage);
            var pageIndex = 0;
            return Ok(new { Products = products, PageCount = pagination.PageCount, CurrentPage = pageIndex + 1 });
        }

        [HttpPost("products/{query}/{page:int}")]
        public async Task<IActionResult> GetProductsByQueryAndPage(string query, int page)
        {
            var pageIndex = page - 1;
            var products = await _shopService.GetProductsByQueryAsync(query);
            var pagination = new PaginationHelper<ProductDTO>(products, _itemsPerPage);
            var result = products.Skip(pageIndex * _itemsPerPage).Take(_itemsPerPage);
            return Ok(new { Products = products, PageCount = pagination.PageCount, CurrentPage = pageIndex + 1 });
        }
    }
}
