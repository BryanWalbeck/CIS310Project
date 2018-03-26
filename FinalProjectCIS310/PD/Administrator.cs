using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectCIS310
{
    public class Administrator
    {
        public int ID { get; set; }
        public string userName { get; set; }
        public string password { get; set; }

        public Administrator(string setUserName,
            string setPassword)
        {
            this.userName = setUserName;
            this.password = setPassword;
        }

        public Administrator()
        {

        }
    }
}
