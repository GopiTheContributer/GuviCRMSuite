using System.Configuration;

namespace DACLibrary.HelperClass
{
    public class GetConnectionString
    {
        //Singleton implementation
        private GetConnectionString() { }

        private static string connectionString = null;
        private static readonly object threadCheckObject = new object();

        public static string GetConnectionDetails()
        {
            if (connectionString == null)
            {
                lock (threadCheckObject)
                {
                    if (connectionString == null)
                        connectionString = ConfigurationManager.ConnectionStrings["CRMSuiteConStr"].ToString();
                }
            }
            return connectionString;
        }
    }
}
