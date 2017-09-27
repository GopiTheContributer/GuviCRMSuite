using System;

namespace GuviCRMSuite.Properties
{
    public class SchedulerAddEvent
    {
        public string GoalTitle { get; set; }
        public string goals { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public string EventID { get; set; }
        public DateTime EventStartDTTM { get; set; }
        public DateTime EventEndDTTM { get; set; }
    }

    public class SchedulerCalenderEventData
    {
        public string Title { get; set; }
        public string Start { get; set; }
        public string End { get; set; }

    }
}
