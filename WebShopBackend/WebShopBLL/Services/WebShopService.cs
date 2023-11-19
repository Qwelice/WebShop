namespace WebShopBLL.Services
{
    using Microsoft.AspNetCore.Http.HttpResults;
    using MongoDB.Bson;
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

        public async Task CreateNewProductAsync(ProductDTO product)
        {
            if(_unitOfWork.Products.Find(entity => entity.Name == product.Name).Any())
            {
                throw new ArgumentException("Продукт с таким названием уже существует");
            }
            var newProduct = new ProductEntity();
            newProduct.Name = product.Name;
            newProduct.Description = product.Description;
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
                await _unitOfWork.Photos.InsertOneAsync(new PhotoModel { PhotoId = id, PhotoData = product.PhotoData });
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
                var filter = Builders<PhotoModel>.Filter.Where(p => p.PhotoId == product.Id);
                var photoData = _unitOfWork.Photos.Find(filter).FirstOrDefault()?.PhotoData;
                if(photoData == null)
                {
                    continue;
                }
                var prod = new ProductDTO
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    PriceFix = product.PriceFix,
                    PhotoData = photoData,
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
                entity.Name.Contains(queryString));
            
            foreach(var prod in prods)
            {
                var filter = Builders<PhotoModel>.Filter.Where(p => p.PhotoId == prod.Id);
                var photoData = _unitOfWork.Photos.Find(filter).FirstOrDefault()?.PhotoData;
                if (photoData == null)
                {
                    continue;
                }
                result.Add(new ProductDTO
                {
                    Id = prod.Id,
                    Name = prod.Name,
                    Description = prod.Description,
                    Price = prod.Price,
                    PriceFix = prod.PriceFix,
                    PhotoData = photoData,
                    Categories = prod.Categories.Select(c => new CategoryDTO { Id = c.Id, Name = c.Name }).ToList()
                });
            }

            return result;
        }
    }
}
