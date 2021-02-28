using System;
using System.Collections.Generic;
using System.Text;

namespace Suricato.UI.Controls
{
    public class PinControlEvents: EventArgs
    {
        public enum ACTIONS { GO_NEXT_VIEW, PINS_NOT_MATCH  }
        public ACTIONS action;
        public string pin;
        public PinControlEvents(ACTIONS DoAction, string Pin)
        {
            action = DoAction;
            pin = Pin;
        }
    }
}
