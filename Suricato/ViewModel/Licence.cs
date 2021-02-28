using System;
using System.Collections.Generic;
using System.Text;

namespace Suricato.ViewModel
{
    public class Licence
    {

        public void LicenceRegistration(string SuricatoKey)
        {
            try
            {
                Persistence.Data.LicenceLocalData =  new APIServices.Registration().GetLicenceInformation(SuricatoKey);
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }
    }
}
