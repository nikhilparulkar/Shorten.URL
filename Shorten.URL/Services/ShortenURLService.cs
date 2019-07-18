using Shorten.URL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shorten.URL.Services
{
    public class ShortenURLService : IURLShortner
    {
        private readonly URLDBContext _dbContext;
        private readonly IHashService _hashSvc;
        public ShortenURLService(URLDBContext dbContext, IHashService hashSvc)
       
        {
            _dbContext = dbContext;
            _hashSvc = hashSvc;
        }

        public string getExpandedURL(string id)
        {
            var Id = Int64.Parse (Utils.Utils.Base64Decode(id));
            var temp = _dbContext.Url.Where(x => x.Id == Id).FirstOrDefault().Url1;

            return temp;
        }

        public string getShortURL(string url)
        {
            var thisItem = _dbContext.Url.Where(x => x.HashValue == _hashSvc.GetHashValue(url)).FirstOrDefault();
            if (thisItem == null)
            {
                var newID = _dbContext.Url.LastOrDefault()==null? 1: _dbContext.Url.LastOrDefault().Id + 1;
                var newItem = new Url { Url1 = url, HashValue = _hashSvc.GetHashValue(url) };
                _dbContext.Url.Add(newItem);
                _dbContext.SaveChanges();
                return (Utils.Utils.Base64Encode(newItem.Id.ToString())); 
            }
            else
            {
                return (Utils.Utils.Base64Encode(thisItem.Id.ToString()));
            }
            
            
        }
    }
}
