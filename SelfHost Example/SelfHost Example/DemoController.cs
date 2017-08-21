using System.Web.Http;
using GuviCRMSuite.BALLibrary;
using GuviCRMSuite.Properties;
using System.Collections.Generic;

namespace GuviCRMSuite
{
    public class DemoController : ApiController
    {
        #region "Variable"
        BusinessAccessClass BALObject = new BALLibrary.BusinessAccessClass();
        #endregion

        // GET api/demo 
        public List<Products> GetProductsDetails()
        {
           return  BusinessAccessClass.GetProductsDetails();
        }

        // GET api/demo/5 
        public Products GetExample(int id)
        {
            return BusinessAccessClass.GetProductDetail(id);
        }
    }
}