using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using NUnit.Framework;
using NUnitTestProject;
using Shorten.URL.Models;
using Shorten.URL.Services;
using Shorten.URL.Utils;
using System;
using System.IO;
using System.Linq;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        // Test whether URL passed to 'ShortenURLService' is corretly stored in DB 
        public void CheckShortenURL()
        {
            var jsonText = File.ReadAllText(System.IO.Path.GetFullPath(@"..\..\..\appsettings.json"));
            var connectionString = JsonConvert.DeserializeObject<Config> (jsonText);
            var thisMD5Svc = new MD5HashService();
            var thisDb = new URLDBContext(connectionString.ConnectionStrings);
            string testURL = "https://www.abc.net.au/news/2019-07-18/caleb-ewan-delivers-a-stage-winner-in-his-debut-tour/11320128?section=sport";
            var svc = new ShortenURLService(thisDb, thisMD5Svc);
            var result =svc.getShortURL(testURL);
            var id = Int64.Parse(Utils.Base64Decode(result));
            
            Assert.AreEqual(testURL,thisDb.Url.Where(x => x.Id == id).FirstOrDefault().Url1);
 
        }

        [Test]
        //Check service does not create duplicate records
        // Test whether exiting URL passed to 'ShortenURLService' is does not create another records
        //instead it returns the existing record DB 
        public void CheckDuplicateRecordsAreNotCreated()
        {
            var jsonText = File.ReadAllText(System.IO.Path.GetFullPath(@"..\..\..\appsettings.json"));
            var connectionString = JsonConvert.DeserializeObject<Config>(jsonText);
            var thisMD5Svc = new MD5HashService();
            var thisDb = new URLDBContext(connectionString.ConnectionStrings);
            var countBefore = thisDb.Url.Count();
            string testURL = "https://www.abc.net.au/news/2019-07-18/caleb-ewan-delivers-a-stage-winner-in-his-debut-tour/11320128?section=sport";
            var svc = new ShortenURLService(thisDb, thisMD5Svc);
            var result = svc.getShortURL(testURL);
            var id = Int64.Parse(Utils.Base64Decode(result));
            var countAfter = thisDb.Url.Count();
            Assert.AreEqual(testURL, thisDb.Url.Where(x => x.Id == id).FirstOrDefault().Url1);
            Assert.AreEqual(countBefore, countAfter);

        }

        [Test]
        //Check service does not create duplicate records
   
        public void checkExpandedURL()
        {
            var jsonText = File.ReadAllText(System.IO.Path.GetFullPath(@"..\..\..\appsettings.json"));
            var connectionString = JsonConvert.DeserializeObject<Config>(jsonText);
            var thisMD5Svc = new MD5HashService();
            var thisDb = new URLDBContext(connectionString.ConnectionStrings);
            
            string testURL = "https://www.abc.net.au/news/2019-07-18/caleb-ewan-delivers-a-stage-winner-in-his-debut-tour/11320128?section=sport";
            var svc = new ShortenURLService(thisDb, thisMD5Svc);
            var result = svc.getShortURL(testURL);
            var actualResult = svc.getExpandedURL(result);

       
            Assert.AreEqual(testURL, actualResult);

        }
    }
}