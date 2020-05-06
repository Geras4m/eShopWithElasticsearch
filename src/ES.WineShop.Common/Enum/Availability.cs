using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ES.WineShop.Common.Enum
{
    public enum Availability
    {
        InStock = 1,
        SoldOut = 2,
        Clearance = 3,
        Backorder = 4,        
    }
}
