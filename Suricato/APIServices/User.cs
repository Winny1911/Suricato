using Suricato.Ioc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Suricato.APIServices
{
    public class User
    {
        public Model.APIInfoReturn Validate(string SuricatoKey, string Company, string AccountKey, string Email, string MacAddress, string Password)
        {
            Model.APIInfoReturn api_return_info = new Model.APIInfoReturn();

            try
            {
                Model.User.ResquestAuth parameters = new Model.User.ResquestAuth() {
                    suricato_key = SuricatoKey,
                    mac_address = MacAddress,
                    tipo_empregador = "1", //fixo
                    matricula = AccountKey,
                    password = Password,
                    versao_sistema = "ANDROID 4.0",
                    empregador = Company
                };

                string retorno_api = ServicesHttpFactory.Post(Routes.AUTENTICACAO, parameters, "");

                api_return_info = new Wrappers.JsonToModel().ConvertJsonToModel<Model.APIInfoReturn>(retorno_api);

                return api_return_info;

            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return null;
            }
        }

    }
}
