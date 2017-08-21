using System.Collections.Generic;
using GuviCRMSuite.Properties;
using GuviCRMSuite.DACLibrary;

namespace GuviCRMSuite.BALLibrary
{
    public class BusinessAccessClass
    {
        public static List<Products> GetProductsDetails()
        {
           return  DataAccessClass.GetProductsDetails();            
        }

        public static Products GetProductDetail(int productId)
        {
            return DataAccessClass.GetProductsDetail(productId);
        }
    }
}
