using System;
using System.Collections.Generic;
using System.Text;

namespace Suricato.ViewModel
{
    public class User
    {
        public Model.APIInfoReturn Validate(string SuricatoKey, string Company, string AccountKey, string Email, string Password)
        {
            try
            {
                return new APIServices.User().Validate(SuricatoKey, Company, AccountKey, Email, new Helpers.Device().GetDeviceMacAddress(), Password);
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return null;
            }
        }
    }
}
