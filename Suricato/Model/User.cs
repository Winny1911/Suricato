using System;
using System.Collections.Generic;
using System.Text;

namespace Suricato.Model
{
    public class User : APIInfoReturn
    {

        public string matricula { get; set; }

        public class ResquestAuth
        {
            public string suricato_key { get; set; }
            public string mac_address { get; set; }
            public string tipo_empregador { get; set; }
            public string matricula { get; set; }
            public string password { get; set; }
            public string versao_sistema { get; set; }
            public string empregador { get; set; }
        }
        /// <summary>
        /// return_status:
        /// return_message: token de acesso
        /// </summary>
        public class ResponseAuth : APIInfoReturn
        {

        }

        public class RequestTimeClockPoitments{
            public string token { get; set; }
            public DateTime inicio { get; set; }
            public DateTime termino { get; set; }
        }

        public class ResponseTimeClockPoitments : APIInfoReturn
        {
            public List<Model.WorkClockPointment> registroponto { get; set; }
        }

        
        
    }
}
