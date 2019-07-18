# Shorten.URL

This is project aims to provide URL shortening service, along the lines of something like tinyurl.com or bit.ly.
It exposes two public RestFul endpoint 1) Shorten a Long URL 2) redirects the short URL to expanded actual page

This project is build on .Net Code 2.1.

Endpoint exponsed by project are as follows :

1. GET : /{url} : This endpoint queries the database for any short URL. 
            Response : Http (302) 
             
            example :(GET)https://shortenurl20190718121531.azurewebsites.net/Mw== will redirect it to
             https://www.abc.net.au/radio/programs/the-signal/human-extinction/11319420

2. POST : /shorten : This endpoint creates a short url for a URL passed as  Form parameter.
      Body:  "Content-Type": "application/x-www-form-urlencoded"
          {
            "value": "<URL to be shortened>"
          }
      Response http(200) : 
          {
            "shortURL": "https://shortenurl20190718121531.azurewebsites.net/MQ=="
          }
      Response http(500) : Internal Service Error
          
 
 Also Include in project in Unit test project to test internal services.
 
 Also Included a Postman script to test both end point.
