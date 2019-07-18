using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shorten.URL.Services
{
    public interface IHashService
    {
        string GetHashValue(string value);
    }
}
