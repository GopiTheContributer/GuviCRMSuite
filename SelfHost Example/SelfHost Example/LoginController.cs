using System.Web.Http;
using Owin;
using System.Web.Http.Owin;
using GuviCRMSuite.BALLibrary;

namespace GuviCRMSuite
{
    public class LoginController : ApiController
    {
        [HttpGet]
        public string GetTest()
        {
            return "success";
        }
        [HttpPost]
        //public bool GetValidateLogin(string username, string password)
        public bool ValidateLogin(string username, string password)
        {
            //string username = "admin"; string password = "admin";
            return BusinessAccessClass.GetLoginDetails(username, password);
        }
    }
}
