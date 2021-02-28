using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Suricato.Ioc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace Suricato.APIServices
{
    public class Registration
    {

        public Registration()
        {
        }

        //public Model.LicenceData GetLicenceInformation(string SuricatoKey)
        //{
        //    Model.LicenceData dadosLicenca = new Model.LicenceData();

        //    try
        //    {
        //        Dictionary<string, string> parameter = new Dictionary<string, string>();
        //        parameter.Add("suricato_key", SuricatoKey);

        //        string retorno_api = ServicesHttpFactory.Post(Routes.ATIVACAO_DE_LICENCA, parameter, "");

        //        dadosLicenca = new Wrappers.JsonToModel().ConvertJsonToModel<Model.LicenceData>(retorno_api); 

        //        return dadosLicenca;

        //    }
        //    catch (Exception err)
        //    {
        //        Console.WriteLine(err.Message);
        //        return null;
        //    }
        //}

        public Model.Licence.ResponseLicence GetLicenceInformation(string SuricatoKey)
        {
            Model.Licence.ResponseLicence licence_data = new Model.Licence.ResponseLicence();

            try
            {
                Model.Licence.RequestLicence parameter = new Model.Licence.RequestLicence() {
                     suricato_key = SuricatoKey
                };

                string retorno_api = ServicesHttpFactory.Post(Routes.ATIVACAO_DE_LICENCA, parameter, "");

                licence_data = new Wrappers.JsonToModel().ConvertJsonToModel<Model.Licence.ResponseLicence>(retorno_api);

                return licence_data;

            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return null;
            }
        }

    }
}
