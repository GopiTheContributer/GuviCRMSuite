using System.Collections.Generic;
using GuviCRMSuite.Properties;
using GuviCRMSuite.DACLibrary;


namespace GuviCRMSuite.BALLibrary
{
    public class SchedulerBAL
    {
        public static bool AddNewEvents(SchedulerAddEvent schedulerPropertyObj)
        {
            return SchedulerDAC.AddNewEvents(schedulerPropertyObj);
        }

        public static List<SchedulerCalenderEventData> GetEventDetailsForCalender()
        {
            return SchedulerDAC.GetEventDetailsForCalender();
        }
    }
}
