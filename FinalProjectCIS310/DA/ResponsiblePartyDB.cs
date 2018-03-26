using FinalProjectCIS310;
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
    class ResponsiblePartyDB
    {
        public static ResponsibleParty GetRP(string rpCode)
        {
            SqlConnection connection = JSMusicStudioDB.GetConnection();
            string selectStatement
                = "SELECT ID, First, Last, Phone, Address, Email, [User], Password, Discount "
                + "FROM ResponsibleParties "
                + "WHERE ID = @ID";
            SqlCommand selectCommand =
                new SqlCommand(selectStatement, connection);
            selectCommand.Parameters.AddWithValue("@ID", rpCode);

            try
            {
                connection.Open();
                SqlDataReader custReader =
                    selectCommand.ExecuteReader(CommandBehavior.SingleRow);
                if (custReader.Read())
                {
                    ResponsibleParty rp = new ResponsibleParty();
                    rp.ID = Int32.Parse(custReader["ID"].ToString());
                    rp.firstName = custReader["First"].ToString();
                    rp.lastName = custReader["Last"].ToString();
                    rp.phoneNumber = custReader["Phone"].ToString();
                    rp.address = custReader["Address"].ToString();
                    rp.email = custReader["Email"].ToString();
                    rp.userName = custReader["User"].ToString();
                    rp.password = custReader["Password"].ToString();
                    rp.discount = Int32.Parse(custReader["Discount"].ToString());

                    return rp;
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

        public static string AddRP(ResponsibleParty rp)
        {
            SqlConnection connection = JSMusicStudioDB.GetConnection();
            string insertStatement =
                "INSERT ResponsibleParties " +
                "(First, Last, Phone, Address, Email, [User], Password, Discount) " +
                "VALUES (@First, @Last, @Phone, @Address, @Email, @User, @Password, @Discount )";
            SqlCommand insertCommand =
                new SqlCommand(insertStatement, connection);
            insertCommand.Parameters.AddWithValue(
                "@First", rp.firstName);
            insertCommand.Parameters.AddWithValue(
                "@Last", rp.lastName);
            insertCommand.Parameters.AddWithValue(
                "@Phone", rp.phoneNumber);
            insertCommand.Parameters.AddWithValue(
                "@Address", rp.address);
            insertCommand.Parameters.AddWithValue(
                "@Email", rp.email);
            insertCommand.Parameters.AddWithValue(
                "@User", rp.userName);
            insertCommand.Parameters.AddWithValue(
                "@Password", rp.password);
            insertCommand.Parameters.AddWithValue(
                "@Discount", rp.discount);

            try
            {
                connection.Open();
                insertCommand.ExecuteNonQuery();
                string selectStatement =
                    "SELECT ID FROM ResponsibleParties WHERE First = @First and Last = @Last";
                SqlCommand selectCommand =
                    new SqlCommand(selectStatement, connection);
                selectCommand.Parameters.AddWithValue(
                "@First", rp.firstName);
                selectCommand.Parameters.AddWithValue(
                    "@Last", rp.lastName);
                string rpCode = Convert.ToString(selectCommand.ExecuteScalar());
                return rpCode;
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

        public static bool UpdateRP(ResponsibleParty oldRP,
            ResponsibleParty newRP)
        {
            SqlConnection connection = JSMusicStudioDB.GetConnection();
            string updateStatement =
                "UPDATE ResponsibleParties SET " +
                "First = @NewFirst, " +
                "Last = @NewLast, " +
                "Phone = @NewPhone, " +
                "Address = @NewAddress, " +
                "Email = @NewEmail, " +
                "[User] = @NewUser, " +
                "Password = @NewPassword, " +
                "Discount = @NewDiscount " +
                "WHERE ID = @OldID";
            SqlCommand updateCommand =
                new SqlCommand(updateStatement, connection);
            updateCommand.Parameters.AddWithValue(
                "@NewFirst", newRP.firstName);
            updateCommand.Parameters.AddWithValue(
                "@NewLast", newRP.lastName);
            updateCommand.Parameters.AddWithValue(
                "@NewPhone", newRP.phoneNumber);
            updateCommand.Parameters.AddWithValue(
                "@NewAddress", newRP.address);
            updateCommand.Parameters.AddWithValue(
                "@NewEmail", newRP.email);
            updateCommand.Parameters.AddWithValue(
                "@NewUser", newRP.userName);
            updateCommand.Parameters.AddWithValue(
                "@NewPassword", newRP.password);
            updateCommand.Parameters.AddWithValue(
                "@NewDiscount", newRP.discount);
            updateCommand.Parameters.AddWithValue(
                "@OldID", oldRP.ID);
            try
            {
                connection.Open();
                int count = updateCommand.ExecuteNonQuery();
                if (count > 0)
                    return true;
                else
                    return false;
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

        public static bool DeleteRP(ResponsibleParty rp)
        {
            SqlConnection connection = JSMusicStudioDB.GetConnection();
            string deleteStatement =
                "DELETE FROM ResponsibleParties " +
                "WHERE ID = @ID";
            SqlCommand deleteCommand =
                new SqlCommand(deleteStatement, connection);
            deleteCommand.Parameters.AddWithValue(
                "@ID", rp.ID);
            try
            {
                connection.Open();
                int count = deleteCommand.ExecuteNonQuery();
                if (count > 0)
                    return true;
                else
                    return false;
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

        public static ResponsibleParty GetRP(string userName, string password)
        {
            SqlConnection connection = JSMusicStudioDB.GetConnection();
            string selectStatement
                = "SELECT ID, [User], Password "
                + "FROM ResponsibleParties "
                + "WHERE [User] = @User"
                + "  AND [Password] = @Password";
            SqlCommand selectCommand =
                new SqlCommand(selectStatement, connection);
            selectCommand.Parameters.AddWithValue("@User", userName);
            selectCommand.Parameters.AddWithValue("@Password", password);

            try
            {
                connection.Open();
                SqlDataReader rpReader =
                    selectCommand.ExecuteReader(CommandBehavior.SingleRow);
                if (rpReader.Read())
                {
                    ResponsibleParty rp = new ResponsibleParty();
                    rp.ID = Int32.Parse(rpReader["ID"].ToString());
                    rp.userName = rpReader["User"].ToString();
                    rp.password = rpReader["Password"].ToString();

                    return rp;
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

        public static ResponsibleParty GetRPByUserName(string userName, string password)
        {
            SqlConnection connection = JSMusicStudioDB.GetConnection();
            string selectStatement
                = "SELECT ID, First, Last, Phone, Address, Email, [User], Password, Discount "
                + "FROM ResponsibleParties "
                + "WHERE [User] = @User"
                + "  AND [Password] = @Password";
            SqlCommand selectCommand =
                new SqlCommand(selectStatement, connection);
            selectCommand.Parameters.AddWithValue("@User", userName);
            selectCommand.Parameters.AddWithValue("@Password", password);

            try
            {
                connection.Open();
                SqlDataReader rpReader =
                    selectCommand.ExecuteReader(CommandBehavior.SingleRow);
                if (rpReader.Read())
                {
                    ResponsibleParty rp = new ResponsibleParty();
                    rp.ID = Int32.Parse(rpReader["ID"].ToString());
                    rp.firstName = rpReader["First"].ToString();
                    rp.lastName = rpReader["Last"].ToString();
                    rp.phoneNumber = rpReader["Phone"].ToString();
                    rp.address = rpReader["Address"].ToString();
                    rp.email = rpReader["Email"].ToString();
                    rp.userName = rpReader["User"].ToString();
                    rp.password = rpReader["Password"].ToString();
                    rp.discount = Int32.Parse(rpReader["Discount"].ToString());

                    return rp;
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
