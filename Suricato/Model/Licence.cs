using System;
using System.Collections.Generic;
using System.Text;

namespace Suricato.Model
{
    public class Licence
    {
        public string suricato_key { get; set; }
        public int usuarios { get; set; }
        public int dispositivos { get; set; }

        public class RequestLicence 
        {
            public string suricato_key { get; set; }
        }

        public class ResponseLicence:APIInfoReturn
        {
            public ResponseLicence()
            {
                empregador = new List<Company>();
            }

            public List<Company> empregador { get; set; }
        }
    }
}
 