namespace WebShopDAL.Entities
{
    using System;
    using System.Collections.Generic;

    public class OrderEntity : BaseEntity
    {
        public virtual UserEntity Owner { get; set; }
        public virtual IList<ProductEntity> Products { get; set; }
        public virtual bool IsClosed { get; set; }
        public virtual DateTime ClosedDate { get; set; }

        public OrderEntity()
        {
            Products = new List<ProductEntity>();
        }
    }
}
