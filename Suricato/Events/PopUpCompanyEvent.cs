using System;
using System.Collections.Generic;
using System.Text;

namespace Suricato.Events
{
    public class PopUpCompanyEvent : EventArgs
    {
        public string companySuricatoId { get; set; }

        public PopUpCompanyEvent(string SuricatoId)
        {
            companySuricatoId = SuricatoId;
        }
    }
}
