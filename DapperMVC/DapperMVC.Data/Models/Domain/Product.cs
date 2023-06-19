using System.ComponentModel.DataAnnotations;

namespace DapperMVC.Data.Models.Domain
{
    public class Product
    {
        public int ProductID { get; set; }
        [Required]
        public string? ProductName { get; set; }
        [Required]
        public string? ProductDesc { get; set; }
        public int Price { get; set; }

        public int Qty { get; set; }

    }
}
