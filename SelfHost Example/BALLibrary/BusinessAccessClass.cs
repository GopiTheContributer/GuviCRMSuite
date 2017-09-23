using System.Collections.Generic;
using GuviCRMSuite.Properties;
using GuviCRMSuite.DACLibrary;

namespace GuviCRMSuite.BALLibrary
{
    public class BusinessAccessClass
    {
        #region "code for scheduler controller"
        public static bool AddNewEvents(SchedulerProperty schedulerPropertyObj)
        {
            return DataAccessClass.AddNewEvents(schedulerPropertyObj);
        }

        public static void GetEventDetailsForCalender()
        {
            return DataAccessClass.GetEventDetailsForCalender();
        }
        #endregion

        #region "Code for Login controller"
        public static bool GetLoginDetails(string username, string password)
        {
            return DataAccessClass.GetLogin(username, password);
        }
        #endregion
    }
}
