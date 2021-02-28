using System;
using System.Collections.Generic;
using System.Text;

namespace Suricato.Persistence
{
    public class Session
    {
        private static Session _instance;
        public static Session Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Session();
                }
                return _instance;
            }
        }

        private static string _pin;
        public string Pin
        {
            get
            {
                return _pin;
            }
            set
            {
                _pin = value;
            }
        }

    }
}
