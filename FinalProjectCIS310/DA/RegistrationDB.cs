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
    class RegistrationDB
    {
        public static Registration GetReg(string regCode)
        {
            SqlConnection connection = JSMusicStudioDB.GetConnection();
            string selectStatement
                = "SELECT ID, CustID, LessonID, Scheduled, Completed, Canceled "
                + "FROM Registrations "
                + "WHERE ID = @ID";
            SqlCommand selectCommand =
                new SqlCommand(selectStatement, connection);
            selectCommand.Parameters.AddWithValue("@ID", regCode);

            try
            {
                connection.Open();
                SqlDataReader regReader =
                    selectCommand.ExecuteReader(CommandBehavior.SingleRow);
                if (regReader.Read())
                {
                    Registration reg = new Registration();
                    reg.ID = Int32.Parse(regReader["ID"].ToString());
                    reg.customerID = Int32.Parse(regReader["CustID"].ToString());
                    reg.lessonID = Int32.Parse(regReader["LessonID"].ToString());
                    reg.scheduleDate= DateTime.Parse(regReader["Scheduled"].ToString());
                    reg.completedLesson = regReader["Completed"].ToString();
                    reg.cancelDate = DateTime.Parse(regReader["Canceled"].ToString());

                    return reg;
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

        public static string AddReg(Registration reg)
        {
            SqlConnection connection = JSMusicStudioDB.GetConnection();
            string insertStatement =
                "INSERT Registrations " +
                "(CustID, LessonID, Scheduled, Completed, Canceled) " +
                "VALUES (@CustID, @LessonID, @Scheduled, @Completed, @Canceled)";
            SqlCommand insertCommand =
                new SqlCommand(insertStatement, connection);
            insertCommand.Parameters.AddWithValue(
                "@CustID", reg.customerID);
            insertCommand.Parameters.AddWithValue(
                "@LessonID", reg.lessonID);
            insertCommand.Parameters.AddWithValue(
                "@Scheduled", reg.scheduleDate);
            insertCommand.Parameters.AddWithValue(
                "@Completed", reg.completedLesson);
            insertCommand.Parameters.AddWithValue(
                "@Canceled", reg.cancelDate);

            try
            {
                connection.Open();
                insertCommand.ExecuteNonQuery();
                string selectStatement =
                    "SELECT ID FROM Registrations WHERE CustID = @CustID and LessonID = @LessonID";
                SqlCommand selectCommand =
                    new SqlCommand(selectStatement, connection);
                selectCommand.Parameters.AddWithValue(
                "@CustID", reg.customerID);
                selectCommand.Parameters.AddWithValue(
                    "@LessonID", reg.lessonID);
                string regCode = Convert.ToString(selectCommand.ExecuteScalar());
                return regCode;
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

        public static bool UpdateReg(Registration oldReg,
            Registration newReg)
        {
            SqlConnection connection = JSMusicStudioDB.GetConnection();
            string updateStatement =
                "UPDATE Registrations SET " +
                "CustID = @NewCustID, " +
                "LessonID = @NewLessonID, " +
                "Scheduled = @NewScheduled, " +
                "Completed = @NewCompleted, " +
                "Canceled = @NewCanceled " +
                "WHERE ID = @OldID";
            SqlCommand updateCommand =
                new SqlCommand(updateStatement, connection);
            updateCommand.Parameters.AddWithValue(
                "@NewCustID", newReg.customerID);
            updateCommand.Parameters.AddWithValue(
                "@NewLessonID", newReg.lessonID);
            updateCommand.Parameters.AddWithValue(
                "@NewScheduled", newReg.scheduleDate);
            updateCommand.Parameters.AddWithValue(
                "@NewCompleted", newReg.completedLesson);
            updateCommand.Parameters.AddWithValue(
                "@NewCanceled", newReg.cancelDate);
            updateCommand.Parameters.AddWithValue(
                "@OldID", oldReg.ID);
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

        public static bool DeleteReg(Registration reg)
        {
            SqlConnection connection = JSMusicStudioDB.GetConnection();
            string deleteStatement =
                "DELETE FROM Registrations " +
                "WHERE ID = @ID";
            SqlCommand deleteCommand =
                new SqlCommand(deleteStatement, connection);
            deleteCommand.Parameters.AddWithValue(
                "@ID", reg.ID);
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
