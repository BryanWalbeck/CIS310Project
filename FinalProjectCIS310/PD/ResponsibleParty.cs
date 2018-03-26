using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinalProjectCIS310
{
    public class ResponsibleParty
    {
        public int ID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string phoneNumber { get; set; }
        public string address { get; set; }
        public string email { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public int discount { get; set; }

        public ResponsibleParty(string setFirstName, string setLastName, 
            string setPhoneNumber, string setAddress, string setEmail, string setUserName,
            string setPassword, int setDiscount)
        {
            this.firstName = setFirstName;
            this.lastName = setLastName;
            this.phoneNumber = setPhoneNumber;
            this.address = setAddress;
            this.email = setEmail;
            this.userName = setUserName;
            this.password = setPassword;
            this.discount = setDiscount;
        }

        public ResponsibleParty()
        {

        }
    }
}