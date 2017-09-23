using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using GuviCRMSuite.Properties;
using System.Collections.Generic;
using DACLibrary.HelperClass;

namespace GuviCRMSuite.DACLibrary
{
    public class DataAccessClass
    {
        #region "Variables"

        static SqlConnection connection = null;
        static SqlDataReader dataReader = null;
        static SqlCommand cmd = null;
        #endregion

        #region"Login"
        public static bool GetLogin(string username, string password)
        {
            bool hasLogin = false;
            try
            {
                using (connection = new SqlConnection(GetConnectionString.GetConnectionDetails()))
                {
                    DataSet ds = new DataSet();

                    cmd = new SqlCommand("select count(*) haslogin from login where username = '" + username
                        + "' and password = '" + password + "'", connection);
                    connection.Open();
                    dataReader = cmd.ExecuteReader();

                    while (dataReader.HasRows && dataReader.Read())
                    {
                        if (dataReader["haslogin"].ToString() == "1")
                            hasLogin = true;
                        else
                            hasLogin = false;
                    }
                }
            }
            catch (Exception ex) { throw ex; }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
            return hasLogin;
        }
        #endregion

        #region "code for scheduler"
        public static bool AddNewEvents(SchedulerProperty schedulerPropertyObj)
        {
            bool isAdded = false; int affectedRows = 0;
            try
            {
                using (connection = new SqlConnection(GetConnectionString.GetConnectionDetails()))
                {
                    using (cmd = new SqlCommand("AddNewEvent", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@goaltitle", SqlDbType.VarChar).Value = schedulerPropertyObj.GoalTitle;
                        cmd.Parameters.AddWithValue("@goals", SqlDbType.VarChar).Value = schedulerPropertyObj.goals;
                        cmd.Parameters.AddWithValue("@createdby", SqlDbType.VarChar).Value = schedulerPropertyObj.CreatedBy;
                        cmd.Parameters.AddWithValue("@modifiedby", SqlDbType.VarChar).Value = schedulerPropertyObj.ModifiedBy;
                        cmd.Parameters.AddWithValue("@event_id", SqlDbType.VarChar).Value = schedulerPropertyObj.EventID;
                        cmd.Parameters.AddWithValue("@eventstartdttm", SqlDbType.DateTime).Value = schedulerPropertyObj.EventStartDTTM;
                        cmd.Parameters.AddWithValue("@eventenddttm", SqlDbType.DateTime).Value = schedulerPropertyObj.EventEndDTTM;

                        connection.Open();
                        affectedRows = cmd.ExecuteNonQuery();

                        if (affectedRows > 0)
                            isAdded = true;
                    }
                }
            }
            catch (Exception ex) { throw ex; }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
            return isAdded;
        }

        public static void GetEventDetailsForCalender()
        {

        }
        #endregion
    }
}
