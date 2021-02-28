using System;
using System.Collections.Generic;
using System.Text;

namespace Suricato.Model
{
    /// <summary>
    /// Espelho de Ponto
    /// </summary>
    public class TimeClock
    {
        public class RequestTimeClockPointments
        {
            public string token { get; set; }
            public DateTime inicio { get; set; }
            public DateTime termino { get; set; }
        }
       
        public class ResponseTimeClockPointments : APIInfoReturn
        {
            public List<WorkClockPointment> registroponto { get; set; }
        }
    }
}
