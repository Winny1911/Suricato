using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.IO;

namespace Suricato.Wrappers
{
    public class JsonToModel
    {

        JsonSerializerSettings serializer;

        public JsonToModel()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");

            serializer = new JsonSerializerSettings
            {
                DateFormatString = "dd/MM/yyyy",
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };

        }

        public T ConvertJsonToModel<T>(string JsonString) where T : class
        {
            try
            {
                if (!string.IsNullOrEmpty(JsonString))
                {
                    return JsonConvert.DeserializeObject<T>(JsonString, serializer);
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return null;
            }
            return null;
        }
    }
}
