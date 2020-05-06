using ES.WineShop.Common.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ES.WineShop.Web.Models
{
    public class ProductViewModel : BaseViewModel
    {
        [Required]
        public string SKU { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public string ImageUrl { get; set; }
        public string Category { get; set; }
        public decimal Cost { get; set; }
        public decimal ListPrice { get; set; }
        public decimal? SalePrice { get; set; }
        public decimal ShippingCost { get; set; }
        public string Availability { get; set; }
        public bool IsFreeShipping { get; set; }
    }
}
