using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shorten.URL.Extensions;
using Shorten.URL.Services;

namespace Shorten.URL.Controllers
{
    
    [ApiController]
    public class URLController : Controller
    {
        private readonly IURLShortner _shortenerSvc;

        public URLController(IURLShortner shortenerSvc)
        {
            _shortenerSvc = shortenerSvc;
        }

        // GET api/values/5
        [HttpGet]
        [Route("{id}")]
        public ActionResult Get(string id)
        {
            var result = _shortenerSvc.getExpandedURL(id);
            return Redirect(result);
        }

        // POST api/values
        [HttpPost]
        [Route("shorten")]
        public IActionResult Post([FromForm] string value)
        {
            var baseUrl = new Uri(Microsoft.AspNetCore.Http.Extensions.UriHelper.GetDisplayUrl(Request)).GetLeftPart(System.UriPartial.Authority);
            var result = _shortenerSvc.getShortURL(value);
        
                      
            return Request.CreateResponse(StatusCodes.Status200OK, new { shortURL = baseUrl +"/"+ result });
           
        }

        


    }
}