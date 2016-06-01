using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace btDesktopApp.Services
{
    public class SerializeService : ISerializer
    {
        JsonSerializer _serializer = new JsonSerializer();
        public T Deserialize<T>(string json)
        {
            try
            {
                using (StringReader sr = new StringReader(json))
                {
                    JsonTextReader jtr = new JsonTextReader(sr);
                    var obj = _serializer.Deserialize<T>(jtr);
                    return obj;
                }
            }
            catch
            {
                return default(T);
            }
        }

        public string Serialize(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
