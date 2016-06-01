using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btDesktopApp.Services
{
    public interface ISerializer
    {
        string Serialize(object obj);
        T Deserialize<T>(string json);
    }
}
