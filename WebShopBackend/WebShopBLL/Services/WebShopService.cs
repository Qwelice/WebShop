namespace WebShopBLL.Services
{
    using MongoDB.Driver;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using WebShopBLL.DTO;
    using WebShopBLL.Services.Interfaces;
    using WebShopDAL.Entities;
    using WebShopDAL.Infrastructure;
    using WebShopDAL.MongoModels;
    using SimMetrics.Net.Metric;

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

        public async Task CreateNewOrderAsync(OrderDTO order)
        {
            var user = _unitOfWork.Users.Find(entity => entity.Email == order.User.Email).FirstOrDefault();
            if (user != null)
            {
                var products = await _unitOfWork.Products.FindAsync(entity => order.Products.Select(p => p.Id).Contains(entity.Id));
                var orderEntity = new OrderEntity();
                orderEntity.IsClosed = order.IsClosed;
                orderEntity.ClosedDate = order.ClosedDate;
                orderEntity.Owner = user;
                orderEntity.Products = products.ToList();
                await _unitOfWork.Orders.SaveAsync(orderEntity);
            }
        }

        public async Task CreateNewProductAsync(ProductDTO product)
        {
            if(_unitOfWork.Products.Find(entity => entity.Name == product.Name).Any())
            {
                throw new ArgumentException("Продукт с таким названием уже существует");
            }
            var newProduct = new ProductEntity();
            newProduct.Name = product.Name;
            newProduct.Price = product.Price;
            newProduct.PriceFix = 0;
            var categories = _unitOfWork.Categories.Find(entity => product.Categories.Select(c => c.Name).Contains(entity.Name)).ToList();
            foreach (var category in categories)
            {
                newProduct.Categories.Add(category);
            }
            await _unitOfWork.Products.SaveAsync(newProduct);
            var prods = await _unitOfWork.Products.FindAsync(entity => entity.Name == product.Name);
            var prod = prods.FirstOrDefault();
            if (prod != null)
            {
                var id = prod.Id;
                await _unitOfWork.ProductsExtend.InsertOneAsync(new ProductModel { PhotoId = id, PhotoData = product.PhotoData, Description = product.Description });
            }
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

        public async Task<IList<CategoryDTO>> GetAllCategoriesAsync()
        {
            var result = new List<CategoryDTO>();
            var categories = await _unitOfWork.Categories.GetAllAsync();
            foreach (var category in categories)
            {
                result.Add(new CategoryDTO() { Id = category.Id, Name = category.Name });
            }
            return result;
        }

        public async Task<IList<ProductDTO>> GetAllProductsAsync()
        {
            var result = new List<ProductDTO>();
            var products = await _unitOfWork.Products.GetAllAsync();
            foreach(var product in products)
            {
                var filter = Builders<ProductModel>.Filter.Where(p => p.PhotoId == product.Id);
                var ext = _unitOfWork.ProductsExtend.Find(filter).FirstOrDefault();
                if(ext == null)
                {
                    continue;
                }
                var prod = new ProductDTO
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = ext.Description,
                    Price = product.Price,
                    PriceFix = product.PriceFix,
                    PhotoData = ext.PhotoData,
                    Categories = product.Categories.Select(c => new CategoryDTO() { Id = c.Id, Name = c.Name }).ToList()
                };
                result.Add(prod);
            }
            return result;
        }

        public async Task<IList<ProductDTO>> GetProductsByQueryAsync(string query)
        {
            var result = new List<ProductDTO>();
            var queryString = query.Trim().ToLower();
            double similarityPercentage = 0.2;
            var similarity = new JaccardSimilarity();
            var prods = await _unitOfWork.Products.FindAsync(entity => 
                similarity.GetSimilarity(entity.Name, queryString) >= similarityPercentage ||
                entity.Name.Contains(queryString) ||
                entity.Categories.Where(c => c.Name.Contains(queryString) || similarity.GetSimilarity(c.Name, queryString) >= similarityPercentage).Any()
                );
            
            foreach(var prod in prods)
            {
                var filter = Builders<ProductModel>.Filter.Where(p => p.PhotoId == prod.Id);
                var ext = _unitOfWork.ProductsExtend.Find(filter).FirstOrDefault();
                if (ext == null)
                {
                    continue;
                }
                result.Add(new ProductDTO
                {
                    Id = prod.Id,
                    Name = prod.Name,
                    Description = ext.Description,
                    Price = prod.Price,
                    PriceFix = prod.PriceFix,
                    PhotoData = ext.PhotoData,
                    Categories = prod.Categories.Select(c => new CategoryDTO { Id = c.Id, Name = c.Name }).ToList()
                });
            }

            return result;
        }
    }
}
