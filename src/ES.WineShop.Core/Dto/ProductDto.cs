using ES.WineShop.Common.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace ES.WineShop.Core.Dto
{
    public class ProductDto : BaseDto
    {
        public string SKU { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public string ImageUrl { get; set; }
        public ProductCategory Category { get; set; }
        public decimal Cost { get; set; }
        public decimal ListPrice { get; set; }
        public decimal? SalePrice { get; set; }
        public decimal ShippingCost { get; set; }
        public Availability Availability { get; set; }
        public bool IsFreeShipping { get; set; }
    }
}
