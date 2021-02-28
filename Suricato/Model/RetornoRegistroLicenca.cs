using System;
using System.Collections.Generic;
using System.Text;

namespace Suricato.Model
{
    public class LicenceData : APIInfoReturn
    {
        public LicenceData()
        {
            empregador = new List<Company>();
        }

        public List<Company> empregador { get; set; }
    }
}
