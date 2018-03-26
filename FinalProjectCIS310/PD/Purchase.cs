using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectCIS310
{
    public class Purchase
    {
        public int ID { get; set; }
        public int customerID { get; set; }
        public int productID { get; set; }
        public int quantity { get; set; }
        public DateTime purchaseDate { get; set; }

        public Purchase(int setCustomerID, 
            int setProductID, int setQuantity, DateTime setPurchaseDate)
        {
            this.customerID = setCustomerID;
            this.productID = setProductID;
            this.quantity = setQuantity;
            this.purchaseDate = setPurchaseDate;
        }

        public Purchase()
        {

        }
    }
}
