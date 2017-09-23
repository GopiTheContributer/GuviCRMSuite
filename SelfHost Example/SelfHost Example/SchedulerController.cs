using System.Web.Http;
using GuviCRMSuite.BALLibrary;
using GuviCRMSuite.Properties;
using System.Collections.Generic;

namespace GuviCRMSuite
{
    public class SchedulerController : ApiController
    {
        [HttpPost]
        public void AddNewEvent([FromBody]SchedulerProperty schedulerPropertyObj)
        {
            BusinessAccessClass.AddNewEvents(schedulerPropertyObj);
        }

        [HttpGet]
        public static void GetEventDetailsForCalender()
        {
            BusinessAccessClass.GetEventDetailsForCalender();
        }
    }
}