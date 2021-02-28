using System;
using System.Collections.Generic;
using System.Text;

namespace Suricato.Model
{
    public class Company: APIInfoReturn
    {
        public Company(){
            licenca = new Licence();
        }
        public Licence licenca { get; set; }
        public int codigo_empregador_suricato { get; set; }
        public string razao_social { get; set; }
        public string empregador { get; set; }
    }
}
