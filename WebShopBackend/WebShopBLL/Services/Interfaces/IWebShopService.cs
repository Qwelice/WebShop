namespace WebShopBLL.Services.Interfaces
{
    using System.Threading.Tasks;
    using WebShopBLL.DTO;

    public interface IWebShopService
    {
        public Task CreateNewCategoryAsync(CategoryDTO category);
        public Task DeleteCategory(CategoryDTO category);
        public Task CreateNewProductAsync(ProductDTO product);
        public Task DeleteProduct(ProductDTO product);
        public Task<IList<CategoryDTO>> GetAllCategoriesAsync();
        public Task<IList<ProductDTO>> GetAllProductsAsync();
        public Task<IList<ProductDTO>> GetProductsByQueryAsync(string query);
    }
}
