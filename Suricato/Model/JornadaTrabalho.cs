using System;
using System.Collections.Generic;
using System.Text;

namespace Suricato.Model
{
    public class JornadaTrabalho: APIInfoReturn
    {
        public string suricato_key { get; set; }
        public List<WorkDay> jornada { get; set; } 
    }
}
