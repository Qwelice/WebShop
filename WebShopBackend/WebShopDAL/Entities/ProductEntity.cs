namespace WebShopDAL.Entities
{
    using System.Collections.Generic;

    public class ProductEntity : BaseEntity
    {
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual int Price { get; set; }
        public virtual int PriceFix { get; set; }
        public virtual IList<CategoryEntity> Categories { get; set; }

        public ProductEntity() 
        {
            Categories = new List<CategoryEntity>();
        }
    }
}
