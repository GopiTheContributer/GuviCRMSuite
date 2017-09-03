using System.Web.Http;
using GuviCRMSuite.BALLibrary;
using System.Web.Cors;

namespace GuviCRMSuite
{
    public class LoginController : ApiController
    {
        [HttpGet]
        public string GetMethod()
        {
            return "This one is working fine";
        }

        [HttpPost]
        //[System.Web.Http.HttpPost]
        public bool ValidateLogin(string username, string password)
        {
            return BusinessAccessClass.GetLoginDetails(username, password);
        }
    }
}
