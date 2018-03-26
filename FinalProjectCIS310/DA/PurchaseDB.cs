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
    class PurchaseDB
    {
        public static Purchase GetPurchase(string purchCode)
        {
            SqlConnection connection = JSMusicStudioDB.GetConnection();
            string selectStatement
                = "SELECT ID, CustID, ProdID, Quantity, DOP "
                + "FROM Purchases "
                + "WHERE ID = @ID";
            SqlCommand selectCommand =
                new SqlCommand(selectStatement, connection);
            selectCommand.Parameters.AddWithValue("@ID", purchCode);

            try
            {
                connection.Open();
                SqlDataReader custReader =
                    selectCommand.ExecuteReader(CommandBehavior.SingleRow);
                if (custReader.Read())
                {
                    Purchase purch = new Purchase();
                    purch.ID = Int32.Parse(custReader["ID"].ToString());
                    purch.customerID = Int32.Parse(custReader["CustID"].ToString());
                    purch.productID = Int32.Parse(custReader["ProdID"].ToString());
                    purch.quantity = Int32.Parse(custReader["Quantity"].ToString());
                    purch.purchaseDate = DateTime.Parse(custReader["DOP"].ToString());

                    return purch;
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

        public static string AddPurchase(Purchase purch)
        {
            SqlConnection connection = JSMusicStudioDB.GetConnection();
            string insertStatement =
                "INSERT Purchases " +
                "(CustID, ProdID, Quantity, DOP) " +
                "VALUES (@CustID, @ProdID, @Quantity, @DOP)";
            SqlCommand insertCommand =
                new SqlCommand(insertStatement, connection);
            insertCommand.Parameters.AddWithValue(
                "@CustID", purch.customerID);
            insertCommand.Parameters.AddWithValue(
                "@ProdID", purch.productID);
            insertCommand.Parameters.AddWithValue(
                "@Quantity", purch.quantity);
            insertCommand.Parameters.AddWithValue(
                "@DOP", purch.purchaseDate);

            try
            {
                connection.Open();
                insertCommand.ExecuteNonQuery();
                string selectStatement =
                    "SELECT ID FROM Purchases WHERE CustID = @CustID and ProdID = @ProdID";
                SqlCommand selectCommand =
                    new SqlCommand(selectStatement, connection);
                selectCommand.Parameters.AddWithValue(
                "@CustID", purch.customerID);
                selectCommand.Parameters.AddWithValue(
                    "@ProdID", purch.productID);
                string purchCode = Convert.ToString(selectCommand.ExecuteScalar());
                return purchCode;
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

        public static bool UpdatePurchase(Purchase oldPurch,
            Purchase newPurch)
        {
            SqlConnection connection = JSMusicStudioDB.GetConnection();
            string updateStatement =
                "UPDATE Purchases SET " +
                "CustID = @NewCustID, " +
                "ProdID = @NewProdID, " +
                "Quantity = @NewQuantity, " +
                "DOP = @NewDOP " +
                "WHERE ID = @OldID";
            SqlCommand updateCommand =
                new SqlCommand(updateStatement, connection);
            updateCommand.Parameters.AddWithValue(
                "@NewCustID", newPurch.customerID);
            updateCommand.Parameters.AddWithValue(
                "@NewProdID", newPurch.productID);
            updateCommand.Parameters.AddWithValue(
                "@NewQuantity", newPurch.quantity);
            updateCommand.Parameters.AddWithValue(
                "@NewDOP", newPurch.purchaseDate);
            updateCommand.Parameters.AddWithValue(
                "@OldID", oldPurch.ID);
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

        public static bool DeletePurchase(Purchase purch)
        {
            SqlConnection connection = JSMusicStudioDB.GetConnection();
            string deleteStatement =
                "DELETE FROM Purchases " +
                "WHERE ID = @ID";
            SqlCommand deleteCommand =
                new SqlCommand(deleteStatement, connection);
            deleteCommand.Parameters.AddWithValue(
                "@ID", purch.ID);
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
