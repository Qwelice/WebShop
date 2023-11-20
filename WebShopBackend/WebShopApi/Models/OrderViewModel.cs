namespace WebShopApi.Models
{
    public class OrderViewModel
    {
        public string UserEmail { get; set; }
        public IList<ProductViewModel> Products { get; set; }
    }
}
