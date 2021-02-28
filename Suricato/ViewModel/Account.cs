using System;
using System.Collections.Generic;
using System.Text;

namespace Suricato.ViewModel
{
    public class Account
    {
        public Model.APIInfoReturn CreateAccount(string SuricatoKey, string Company, string AccountKey, string Email)
        {
            try
            {
                return new APIServices.Account().CreateAccountData(SuricatoKey, Company, AccountKey, Email, new Helpers.Device().GetDeviceMacAddress());
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return null;
            }
        }
    }
}
