using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shorten.URL.Services
{
    public interface IDBAccess
    {
        void update();

        void get();
    }
}
