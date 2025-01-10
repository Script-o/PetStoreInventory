using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStoreInventory
{
    public interface IUILogic
    {
        public Product AddProductMenu();
        public void ViewProductMenu(IProductLogic productLogic);

        public string OutputJsonToConsoleClean(List<Product> _products);
    }
}
