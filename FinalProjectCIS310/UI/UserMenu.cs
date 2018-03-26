using FinalProjectCIS310;
using FinalProjectCIS310.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProjectCIS310
{
    public partial class UserMenu : Form
    {
        public UserMenu(string userName, string password, int type)
        {
            InitializeComponent();

            if (type == 2)
            {
                ResponsibleParty rp = ResponsiblePartyDB.GetRPByUserName(userName, password);
                labelName.Text = rp.firstName + "!"; //Welcome Message

                currentUserId = rp.ID;
                rpTest = true;
            }
            if(type == 1)
            {
                Customer user = CustomerDB.GetCustomerByUserName(userName, password);
                labelName.Text = user.firstName + "!"; //Welcome Message

                currentUserId = user.ID;
                rpTest = false;
            }
        }

        public bool rpTest;
        public int currentType;
        public int currentUserId;
        public int currentResponsiblePartyId;

        private void buttonMyPurchases_Click(object sender, EventArgs e)
        {
            UserPurchases userPurchases = new UserPurchases(currentUserId.ToString(), rpTest);
            //userPurchases.currentUser = currentUserId;
            userPurchases.Show();
        }

        private void buttonBuyProducts_Click(object sender, EventArgs e)
        {
            UserProducts userProducts = new UserProducts(currentUserId.ToString(), rpTest);
            userProducts.Show();
        }

        private void buttonMyLessons_Click(object sender, EventArgs e)
        {
            UserLessons userLessons = new UserLessons(currentUserId.ToString(), rpTest);
            userLessons.Show();
        }

        private void buttonAccountInfo_Click(object sender, EventArgs e)
        {
            UserInformation userInformation = new UserInformation(currentUserId.ToString());
            userInformation.Show();
        }
    }
}
