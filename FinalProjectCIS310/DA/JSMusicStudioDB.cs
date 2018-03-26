using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectCIS310.DA
{
    class JSMusicStudioDB
    {
        public static SqlConnection GetConnection()
        {
            string connectionString =
                @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\bwalb885\Desktop\FinalProject_BryanWalbeck\FinalProjectCIS310\DA\JSMusicStudioDatabase.mdf";
                //Full Path Works: 
                //Drag the .mdf from the Solution explorer and add it after AttachDbFilename:=
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }
    }
}