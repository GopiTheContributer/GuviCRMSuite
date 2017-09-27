using System;
using System.Data;
using System.Data.SqlClient;
using DACLibrary.HelperClass;

namespace GuviCRMSuite.DACLibrary
{
    public class LoginDAC
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
    }
}
