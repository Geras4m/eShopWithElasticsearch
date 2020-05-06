using System.ComponentModel.DataAnnotations;

namespace ES.WineShop.Data.Entities
{
    public class Product : Entity
    {        
        [Required]
        public string SKU { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public string ImageUrl { get; set; }
        [Required]
        public int Category { get; set; }
        [Required]
        public decimal Cost { get; set; }
        [Required]
        public decimal ListPrice { get; set; }
        public decimal? SalePrice { get; set; }
        [Required]
        public decimal ShippingCost { get; set; }
        [Required]
        public int Availability { get; set; }
        public bool IsFreeShipping { get; set; }
    }
}
