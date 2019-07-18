# Shorten.URL

This is project aims to provide URL shortening service, along the lines of something like tinyurl.com or bit.ly.
It exposes two public RestFul endpoints :

1) Shorten a Long URL 
2) redirects the short URL to expanded actual page

This project is build on .Net Code 2.1.

Endpoint exponsed by project are as follows :

Endpoint 1 :
POST : /shorten : This endpoint creates a short url for a URL passed as Form parameter.

      Body:  "Content-Type": "application/x-www-form-urlencoded"
          {
            "value": "<URL to be shortened>"
          }
       Success  :Response http(200) : 
          {
            "shortURL": "https://shortenurl20190718121531.azurewebsites.net/MQ=="
          }
       Fail : Response http(500) : Internal Service Error

Endpoint 2.
GET : /{url} : This endpoint if invoked with ShortURL as received in above response (Endpoint 1),then redirects to full                                inflated Original URL 

      Success Response : Http (302) 
      Fail  : Response : HTTP (500)
           
             
      example :(GET)https://shortenurl20190718121531.azurewebsites.net/Mw== will redirect it to
       https://www.abc.net.au/radio/programs/the-signal/human-extinction/11319420       
 
 Also Include in project is a Unit test project to test internal services.
 
 Also Included a Postman script to test both end point.Import these script in latest version of Postman.
 
 This Service is also Hosted on azure and endpoint are:
 
 GET :  https://shortenurl20190718121531.azurewebsites.net/{URL}
 
 POST : https://shortenurl20190718121531.azurewebsites.net/shorten (pass value as form parameter)
