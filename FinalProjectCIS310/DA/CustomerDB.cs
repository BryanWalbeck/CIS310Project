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
    class CustomerDB
    {
        public static Customer GetCustomer(string custCode)
        {
            SqlConnection connection = JSMusicStudioDB.GetConnection();
            string selectStatement
                = "SELECT ID, RPID, First, Last, Phone, Address, Email, [User], Password "
                + "FROM Customers "
                + "WHERE ID = @ID";
            SqlCommand selectCommand =
                new SqlCommand(selectStatement, connection);
            selectCommand.Parameters.AddWithValue("@ID", custCode);

            try
            {
                connection.Open();
                SqlDataReader custReader =
                    selectCommand.ExecuteReader(CommandBehavior.SingleRow);
                if (custReader.Read())
                {
                    Customer c = new Customer();
                    c.ID = Int32.Parse(custReader["ID"].ToString());
                    c.responsiblePartyID = Int32.Parse(custReader["RPID"].ToString());
                    c.firstName = custReader["First"].ToString();
                    c.lastName = custReader["Last"].ToString();
                    c.phoneNumber = custReader["Phone"].ToString();
                    c.address = custReader["Address"].ToString();
                    c.email = custReader["Email"].ToString();
                    c.userName = custReader["User"].ToString();
                    c.password = custReader["Password"].ToString();

                    return c;
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

        public static Customer GetCustomerByUserName(string userName, string password)
        {
            SqlConnection connection = JSMusicStudioDB.GetConnection();
            string selectStatement
                = "SELECT ID, RPID, First, Last, Phone, Address, Email, [User], Password "
                + "FROM Customers "
                + "WHERE [User] = @User"
                + "  AND [Password] = @Password";
            SqlCommand selectCommand =
                new SqlCommand(selectStatement, connection);
            selectCommand.Parameters.AddWithValue("@User", userName);
            selectCommand.Parameters.AddWithValue("@Password", password);

            try
            {
                connection.Open();
                SqlDataReader custReader =
                    selectCommand.ExecuteReader(CommandBehavior.SingleRow);
                if (custReader.Read())
                {
                    Customer c = new Customer();
                    c.ID = Int32.Parse(custReader["ID"].ToString());
                    c.responsiblePartyID = Int32.Parse(custReader["RPID"].ToString());
                    c.firstName = custReader["First"].ToString();
                    c.lastName = custReader["Last"].ToString();
                    c.phoneNumber = custReader["Phone"].ToString();
                    c.address = custReader["Address"].ToString();
                    c.email = custReader["Email"].ToString();
                    c.userName = custReader["User"].ToString();
                    c.password = custReader["Password"].ToString();

                    return c;
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

        public static string AddCustomer(Customer c)
        {
            SqlConnection connection = JSMusicStudioDB.GetConnection();
            string insertStatement =
                "INSERT Customers " +
                "(RPID, First, Last, Phone, Address, Email, [User], Password) " +
                "VALUES (@RPID, @First, @Last, @Phone, @Address, @Email, @User, @Password)";
            SqlCommand insertCommand =
                new SqlCommand(insertStatement, connection);
            insertCommand.Parameters.AddWithValue(
                "@RPID", c.responsiblePartyID);
            insertCommand.Parameters.AddWithValue(
                "@First", c.firstName);
            insertCommand.Parameters.AddWithValue(
                "@Last", c.lastName);
            insertCommand.Parameters.AddWithValue(
                "@Phone", c.phoneNumber);
            insertCommand.Parameters.AddWithValue(
                "@Address", c.address);
            insertCommand.Parameters.AddWithValue(
                "@Email", c.email);
            insertCommand.Parameters.AddWithValue(
                "@User", c.userName);
            insertCommand.Parameters.AddWithValue(
                "@Password", c.password);

            try
            {
                connection.Open();
                insertCommand.ExecuteNonQuery();
                string selectStatement =
                    "SELECT ID FROM Customers WHERE First = @First and Last = @Last";
                SqlCommand selectCommand =
                    new SqlCommand(selectStatement, connection);
                selectCommand.Parameters.AddWithValue(
                "@First", c.firstName);
                selectCommand.Parameters.AddWithValue(
                    "@Last", c.lastName);
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

        public static bool UpdateCustomer(Customer oldCust,
            Customer newCust)
        {
            SqlConnection connection = JSMusicStudioDB.GetConnection();
            string updateStatement =
                "UPDATE Customers SET " +
                "RPID = @NewRPID, " +
                "First = @NewFirst, " +
                "Last = @NewLast, " +
                "Phone = @NewPhone, " +
                "Address = @NewAddress, " +
                "Email = @NewEmail, " +
                "[User] = @NewUser, " +
                "Password = @NewPassword " +
                "WHERE ID = @OldID";
            SqlCommand updateCommand =
                new SqlCommand(updateStatement, connection);
            updateCommand.Parameters.AddWithValue(
                "@NewRPID", newCust.responsiblePartyID);
            updateCommand.Parameters.AddWithValue(
                "@NewFirst", newCust.firstName);
            updateCommand.Parameters.AddWithValue(
                "@NewLast", newCust.lastName);
            updateCommand.Parameters.AddWithValue(
                "@NewPhone", newCust.phoneNumber);
            updateCommand.Parameters.AddWithValue(
                "@NewAddress", newCust.address);
            updateCommand.Parameters.AddWithValue(
                "@NewEmail", newCust.email);
            updateCommand.Parameters.AddWithValue(
                "@NewUser", newCust.userName);
            updateCommand.Parameters.AddWithValue(
                "@NewPassword", newCust.password);
            updateCommand.Parameters.AddWithValue(
                "@OldID", oldCust.ID);
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

        public static bool DeleteCustomer(Customer c)
        {
            SqlConnection connection = JSMusicStudioDB.GetConnection();
            string deleteStatement =
                "DELETE FROM Customers " +
                "WHERE ID = @ID";
            SqlCommand deleteCommand =
                new SqlCommand(deleteStatement, connection);
            deleteCommand.Parameters.AddWithValue(
                "@ID", c.ID);
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
    }
}
