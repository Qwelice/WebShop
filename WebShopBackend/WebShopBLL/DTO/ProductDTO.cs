namespace WebShopBLL.DTO
{
    using System;

    public class ProductDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<CategoryDTO> Categories { get; set; }
        public int Price { get; set; }
        public int PriceFix { get; set; }
        public byte[] PhotoData { get; set; }
    }
}
