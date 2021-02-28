using System;
using System.Collections.Generic;
using System.Text;

namespace Suricato.Model
{
    public class Account: APIInfoReturn
    {
        public string suricato_key { get; set; }
        public string mac_address { get; set; }
        public string tipo_empregado{ get; set; }
        public string matricula { get; set; }
        public string password { get; set; }
        public string versao_sistema { get; set; }
        public string cnpj { get; set; }
    }
}
