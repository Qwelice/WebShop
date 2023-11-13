namespace WebShopAdminApi.Models
{
    using System.ComponentModel.DataAnnotations;

    public class NewCategoryViewModel
    {
        [Required]
        public string CategoryName { get; set; }
    }
}
