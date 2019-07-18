using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shorten.URL.Services
{
    public interface IURLShortner
    {
        string getExpandedURL(string id);

        string getShortURL(string url);
    }
}
