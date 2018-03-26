using FinalProjectCIS310.DA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectCIS310
{
    class AdministratorDB
    {
        public static Administrator GetAdmin(string userName, string password)
        {
            SqlConnection connection = JSMusicStudioDB.GetConnection();
            string selectStatement
                = "SELECT ID, [User], Password "
                + "FROM Administrator "
                + "WHERE [User] = @User"
                + "  AND [Password] = @Password";
            SqlCommand selectCommand =
                new SqlCommand(selectStatement, connection);
            selectCommand.Parameters.AddWithValue("@User", userName);
            selectCommand.Parameters.AddWithValue("@Password", password);

            try
            {
                connection.Open();
                SqlDataReader adminReader =
                    selectCommand.ExecuteReader(CommandBehavior.SingleRow);
                if (adminReader.Read())
                {
                    Administrator a = new Administrator();
                    a.ID = Int32.Parse(adminReader["ID"].ToString());
                    a.userName = adminReader["User"].ToString();
                    a.password = adminReader["Password"].ToString();

                    return a;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
