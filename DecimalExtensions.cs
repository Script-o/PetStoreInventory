using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStoreInventory
{
    public static class DecimalExtensions
    {
        public static decimal DiscountThisPrice(this decimal value)
        {
            return Math.Round(value *= .9M, 2);
        }
    }
}
