using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shorten.URL.Extensions
{
    public static class HttpRequestExtensions
    {
        public static IActionResult CreateResponse(this HttpRequest request, int status, object content)
        {
            return new ObjectResult(content)
            {
                StatusCode = status
            };
        }
    }
}
