namespace WebShopDAL.MongoModels
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    using System;

    public class PhotoModel
    {
        public ObjectId Id { get; set; }
        public byte[] PhotoData { get; set; }
        public Guid PhotoId { get; set; }
    }
}
