using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectCIS310
{
    public class Product
    {
        //Changed these from private to public
        public int ID { get; set; }
        public string productName { get; set; }
        public string productType { get; set; }
        public decimal productPrice { get; set; }

        public Product(string setProductName, string setProductType, decimal setProductPrice)
        {
            this.productName = setProductName;
            this.productType = setProductType;
            this.productPrice = setProductPrice;
        }

        public Product()
        {

        }
    }
}

