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
    class LessonsDB
    {
        public static Lessons GetLesson(string lessonCode)
        {
            SqlConnection connection = JSMusicStudioDB.GetConnection();
            string selectStatement
                = "SELECT ID, Name, Type, Price, Length "
                + "FROM Lessons "
                + "WHERE ID = @ID";
            SqlCommand selectCommand =
                new SqlCommand(selectStatement, connection);
            selectCommand.Parameters.AddWithValue("@ID", lessonCode);

            try
            {
                connection.Open();
                SqlDataReader custReader =
                    selectCommand.ExecuteReader(CommandBehavior.SingleRow);
                if (custReader.Read())
                {
                    Lessons lesson = new Lessons();
                    lesson.ID = Int32.Parse(custReader["ID"].ToString());
                    lesson.lessonName = custReader["Name"].ToString();
                    lesson.lessonType = custReader["Type"].ToString();
                    lesson.lessonPrice = Decimal.Parse(custReader["Price"].ToString());
                    lesson.lessonLength = Int32.Parse(custReader["Length"].ToString());

                    return lesson;
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

        public static string AddLesson(Lessons lesson)
        {
            SqlConnection connection = JSMusicStudioDB.GetConnection();
            string insertStatement =
                "INSERT Lessons " +
                "(Name, Type, Price, Length) " +
                "VALUES (@Name, @Type, @Price, @Length)";
            SqlCommand insertCommand =
                new SqlCommand(insertStatement, connection);
            insertCommand.Parameters.AddWithValue(
                "@Name", lesson.lessonName);
            insertCommand.Parameters.AddWithValue(
                "@Type", lesson.lessonType);
            insertCommand.Parameters.AddWithValue(
                "@Price", lesson.lessonPrice);
            insertCommand.Parameters.AddWithValue(
                "@Length", lesson.lessonLength);

            try
            {
                connection.Open();
                insertCommand.ExecuteNonQuery();
                string selectStatement =
                    "SELECT ID FROM Lessons WHERE Name = @Name and Type = @Type";
                SqlCommand selectCommand =
                    new SqlCommand(selectStatement, connection);
                selectCommand.Parameters.AddWithValue(
                "@Name", lesson.lessonName);
                selectCommand.Parameters.AddWithValue(
                    "@Type", lesson.lessonType);
                string lessonCode = Convert.ToString(selectCommand.ExecuteScalar());
                return lessonCode;
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

        public static bool UpdateLesson(Lessons oldLesson,
            Lessons newLesson)
        {
            SqlConnection connection = JSMusicStudioDB.GetConnection();
            string updateStatement =
                "UPDATE Lessons SET " +
                "Name = @NewName, " +
                "Type = @NewType, " +
                "Price = @NewPrice, " +
                "Length = @NewLength " +
                "WHERE ID = @OldID";
            SqlCommand updateCommand =
                new SqlCommand(updateStatement, connection);
            updateCommand.Parameters.AddWithValue(
                "@NewName", newLesson.lessonName);
            updateCommand.Parameters.AddWithValue(
                "@NewType", newLesson.lessonType);
            updateCommand.Parameters.AddWithValue(
                "@NewPrice", newLesson.lessonPrice);
            updateCommand.Parameters.AddWithValue(
                "@NewLength", newLesson.lessonLength);
            updateCommand.Parameters.AddWithValue(
                "@OldID", oldLesson.ID);;
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

        public static bool DeleteProduct(Lessons lesson)
        {
            SqlConnection connection = JSMusicStudioDB.GetConnection();
            string deleteStatement =
                "DELETE FROM Lessons " +
                "WHERE ID = @ID";
            SqlCommand deleteCommand =
                new SqlCommand(deleteStatement, connection);
            deleteCommand.Parameters.AddWithValue(
                "@ID", lesson.ID);
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
