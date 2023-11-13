namespace WebShopBLL.Services.Interfaces
{
    using System.Threading.Tasks;
    using WebShopBLL.DTO;

    public interface IWebShopService
    {
        public Task CreateNewCategoryAsync(CategoryDTO category);
        public Task DeleteCategory(CategoryDTO category);
        public Task CreateNewProduct(ProductDTO product);
        public Task DeleteProduct(ProductDTO product);
    }
}
