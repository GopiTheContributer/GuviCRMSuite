using System.Web.Http;
using GuviCRMSuite.BALLibrary;
using GuviCRMSuite.Properties;
using System.Collections.Generic;

namespace GuviCRMSuite
{
    public class SchedulerController : ApiController
    {
        [HttpPost]
        public bool AddNewEvent([FromBody]SchedulerAddEvent schedulerPropertyObj)
        {
            return SchedulerBAL.AddNewEvents(schedulerPropertyObj);
        }

        [HttpGet]
        public List<SchedulerCalenderEventData> GetEventDetailsForCalender()
        {
            return SchedulerBAL.GetEventDetailsForCalender();
        }
    }
}