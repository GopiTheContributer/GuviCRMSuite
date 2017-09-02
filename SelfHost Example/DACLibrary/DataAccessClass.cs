using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using GuviCRMSuite.Properties;
using System.Collections.Generic;

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
                string connectionString = ConfigurationManager.ConnectionStrings["CRMSuiteConStr"].ToString();
                connection = new SqlConnection(connectionString);

                using (connection = new SqlConnection(connectionString))
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

        public static List<Products> GetProductsDetails()
        {
            List<Products> lstProductsObject = new List<Products>();
            Products productProperty = null;
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["CRMSuiteConStr"].ToString();
                connection = new SqlConnection(connectionString);

                using (connection = new SqlConnection(connectionString))
                {
                    DataSet ds = new DataSet();

                    cmd = new SqlCommand("select Product, CompanyName, Price from products order by CompanyName asc", connection);
                    connection.Open();
                    dataReader = cmd.ExecuteReader();

                    while (dataReader.HasRows && dataReader.Read())
                    {
                        productProperty = new Products();
                        productProperty.CompanyName = dataReader["CompanyName"].ToString();
                        productProperty.Product = dataReader["Product"].ToString();
                        productProperty.Price = Convert.ToInt64(dataReader["Price"]);
                        lstProductsObject.Add(productProperty);
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
            return lstProductsObject;
        }

        public static Products GetProductsDetail(int productId)
        {
            Products productProperty = new Products();
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["CRMSuiteConStr"].ToString();
                connection = new SqlConnection(connectionString);

                using (connection = new SqlConnection(connectionString))
                {
                    DataSet ds = new DataSet();

                    cmd = new SqlCommand("select Product, CompanyName, Price from products where id = " + productId + "", connection);
                    connection.Open();
                    dataReader = cmd.ExecuteReader();

                    while (dataReader.HasRows && dataReader.Read())
                    {
                        productProperty.CompanyName = dataReader["CompanyName"].ToString();
                        productProperty.Product = dataReader["Product"].ToString();
                        productProperty.Price = Convert.ToInt64(dataReader["Price"]);
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
            return productProperty;
        }
    }
}
