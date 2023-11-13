namespace WebShopBLL.Services
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using WebShopBLL.DTO;
    using WebShopBLL.Services.Interfaces;
    using WebShopDAL.Entities;
    using WebShopDAL.Infrastructure;

    public class WebShopService : IWebShopService
    {
        private UnitOfWork _unitOfWork;

        public WebShopService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateNewCategoryAsync(CategoryDTO category)
        {
            if(_unitOfWork.Categories.Find(entity => entity.Name == category.Name).Any())
            {
                throw new ArgumentException("Такая категория уже существует");
            }

            var newCategory = new CategoryEntity();
            newCategory.Name = category.Name;
            await _unitOfWork.Categories.SaveAsync(newCategory);
        }

        public Task CreateNewProduct(ProductDTO product)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteCategory(CategoryDTO category)
        {
            if(!_unitOfWork.Categories.Find(entity => entity.Name == category.Name).Any())
            {
                throw new ArgumentException("Такой категории не существует");
            }

            var entity = _unitOfWork.Categories.Find(e => e.Name == category.Name).FirstOrDefault();
            await _unitOfWork.Categories.DeleteAsync(entity);
        }

        public Task DeleteProduct(ProductDTO product)
        {
            throw new NotImplementedException();
        }
    }
}
