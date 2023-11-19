namespace WebShopAdminApi.Models
{
    public class NewProductViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public IList<CategoryViewModel> Categories { get; set; }
        public IFormFile Photo { get; set; }
    }
}
