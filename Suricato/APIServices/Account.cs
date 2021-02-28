using Suricato.Ioc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Suricato.APIServices
{
    public class Account
    {

        public Model.APIInfoReturn CreateAccountData(string SuricatoKey, string Company, string AccountKey, string Email, string MacAddress)
        {
            Model.APIInfoReturn account = new Model.APIInfoReturn();

            try
            {
                //SURICATO_KEY
                //MAC_ADDRESS
                //TIPO_EMPREGADO
                //MATRICULA
                //PASSWORD
                //VERSAO_SISTEMA
                //CNPJ

                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("SURICATO_KEY", SuricatoKey);
                parameters.Add("MAC_ADDRESS", MacAddress);
                parameters.Add("TIPO_EMPREGADO", "1");
                parameters.Add("MATRICULA", AccountKey);
                parameters.Add("PASSWORD", "XPTO1234");
                parameters.Add("VERSAO_SISTEMA", "ANDROID 4.0");
                parameters.Add("EMPREGADOR", Company);

                string retorno_api = ServicesHttpFactory.Post(Routes.CONTA, parameters, "");

                account = new Wrappers.JsonToModel().ConvertJsonToModel<Model.APIInfoReturn>(retorno_api);

                return account;

            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return null;
            }
        }
    }
}
