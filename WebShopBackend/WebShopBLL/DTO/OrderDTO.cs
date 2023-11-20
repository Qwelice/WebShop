namespace WebShopBLL.DTO
{
    using System;
    using System.Collections.Generic;

    public class OrderDTO
    {
        public Guid Id { get; set; }
        public UserDTO User { get; set; }
        public IList<ProductDTO> Products { get; set; }
        public bool IsClosed { get; set; }
        public DateTime ClosedDate { get; set; }
    }
}
