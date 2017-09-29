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

        public static List<SchedulerCalenderEventData> GetAEventDetailForCalender(string goalId)
        {
            return SchedulerDAC.GetAEventDetailForCalender(goalId);
        }

        public static bool DeleteEvent(string id)
        {
            return SchedulerDAC.DeleteEvent(id);
        }

        public static bool UpdateEvent(SchedulerAddEvent schedulerPropertyObj)
        {
            return SchedulerDAC.UpdateEvent(schedulerPropertyObj);
        }
    }
}
