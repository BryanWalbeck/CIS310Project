using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectCIS310
{
    public class Customer
    {
        public int ID { get; set; }
        public int responsiblePartyID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string phoneNumber { get; set; }
        public string address { get; set; }
        public string email { get; set; }
        public string userName { get; set; }
        public string password { get; set; }

        public Customer(int setResponsiblePartyID, string setFirstName, string setLastName,
            string setPhoneNumber, string setAddress, string setEmail, string setUserName,
            string setPassword)
        {
            this.responsiblePartyID = setResponsiblePartyID;
            this.firstName = setFirstName;
            this.lastName = setLastName;
            this.phoneNumber = setPhoneNumber;
            this.address = setAddress;
            this.email = setEmail;
            this.userName = setUserName;
            this.password = setPassword;
        }

        public Customer()
        {

        }
    }
}
