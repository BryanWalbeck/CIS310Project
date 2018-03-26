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
    class ProductDB
    {
        public static Product GetProduct(string productCode)
        {
            SqlConnection connection = JSMusicStudioDB.GetConnection();
            string selectStatement
                = "SELECT ID, Name, Type, Price "
                + "FROM Products "
                + "WHERE ID = @ID";
            SqlCommand selectCommand =
                new SqlCommand(selectStatement, connection);
            selectCommand.Parameters.AddWithValue("@ID", productCode);

            try
            {
                connection.Open();
                SqlDataReader custReader =
                    selectCommand.ExecuteReader(CommandBehavior.SingleRow);
                if (custReader.Read())
                {
                    Product product = new Product();
                    product.ID = Int32.Parse(custReader["ID"].ToString());
                    product.productName = custReader["Name"].ToString();
                    product.productType = custReader["Type"].ToString();
                    product.productPrice = Decimal.Parse(custReader["Price"].ToString());

                    return product;
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

        public static string AddProduct(Product product)
        {
            SqlConnection connection = JSMusicStudioDB.GetConnection();
            string insertStatement =
                "INSERT Products " +
                "(Name, Type, Price) " +
                "VALUES (@Name, @Type, @Price)";
            SqlCommand insertCommand =
                new SqlCommand(insertStatement, connection);
            insertCommand.Parameters.AddWithValue(
                "@Name", product.productName);
            insertCommand.Parameters.AddWithValue(
                "@Type", product.productType);
            insertCommand.Parameters.AddWithValue(
                "@Price", product.productPrice);

            try
            {
                connection.Open();
                insertCommand.ExecuteNonQuery();
                string selectStatement =
                    "SELECT ID FROM Products WHERE Name = @Name and Type = @Type";
                SqlCommand selectCommand =
                    new SqlCommand(selectStatement, connection);
                selectCommand.Parameters.AddWithValue(
                "@Name", product.productName);
                selectCommand.Parameters.AddWithValue(
                    "@Type", product.productType);
                string productCode = Convert.ToString(selectCommand.ExecuteScalar());
                return productCode;
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

        public static bool UpdateProduct(Product oldProduct,
            Product newProduct)
        {
            SqlConnection connection = JSMusicStudioDB.GetConnection();
            string updateStatement =
                "UPDATE Products SET " +
                "Name = @NewName, " +
                "Type = @NewType, " +
                "Price = @NewPrice " +
                "WHERE ID = @OldID";
            SqlCommand updateCommand =
                new SqlCommand(updateStatement, connection);
            updateCommand.Parameters.AddWithValue(
                "@NewName", newProduct.productName);
            updateCommand.Parameters.AddWithValue(
                "@NewType", newProduct.productType);
            updateCommand.Parameters.AddWithValue(
                "@NewPrice", newProduct.productPrice);
            updateCommand.Parameters.AddWithValue(
                "@OldID", oldProduct.ID);;
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

        public static bool DeleteProduct(Product product)
        {
            SqlConnection connection = JSMusicStudioDB.GetConnection();
            string deleteStatement =
                "DELETE FROM Products " +
                "WHERE ID = @ID ";
            SqlCommand deleteCommand =
                new SqlCommand(deleteStatement, connection);
            deleteCommand.Parameters.AddWithValue(
                "@ID", product.ID);
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
