namespace WebShopDAL.Entities
{
    public class CategoryEntity : BaseEntity
    {
        public virtual string Name { get; set; }
        public virtual IList<ProductEntity> Products { get; set; }

        public CategoryEntity() 
        {
            Products = new List<ProductEntity>();
        }
    }
}
