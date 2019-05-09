using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAuto.ICacheService
{
    interface ICache
    {
        int Insert();
        object Get(string key);
        T Get<T>(string key);
    }
}
