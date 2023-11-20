namespace WebShopDAL.MongoModels
{
    using MongoDB.Bson;
    using System;

    public class ProductModel
    {
        public ObjectId Id { get; set; }
        public byte[] PhotoData { get; set; }
        public Guid PhotoId { get; set; }
        public string Description { get; set; }
    }
}
