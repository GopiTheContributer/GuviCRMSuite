using System.Web.Http;
using GuviCRMSuite.BALLibrary;
using System.Web.Cors;

namespace GuviCRMSuite
{
    public class LoginController : ApiController
    {
        [HttpPost]
        public bool ValidateLogin(string username, string password)
        {
            return BusinessAccessClass.GetLoginDetails(username, password);
        }
    }
}
