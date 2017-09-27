using System.Collections.Generic;
using GuviCRMSuite.Properties;
using GuviCRMSuite.DACLibrary;

namespace GuviCRMSuite.BALLibrary
{
    public class BusinessAccessClass
    {
        #region "Code for Login controller"
        public static bool GetLoginDetails(string username, string password)
        {
            return LoginDAC.GetLogin(username, password);
        }
        #endregion
    }
}
