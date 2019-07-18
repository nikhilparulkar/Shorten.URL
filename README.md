# Shorten.URL

This is project exposes two public RestFul endpoint 1) Shorten a Long URL 2) redirects the short URL to expanded actual page

This project is build on .Net Code 2.1.

Endpoint exponsed by project are as follows :

1. GET /{url} : This endpoint queries the database for any short URL. 
            example :(GET)https://shortenurl20190718121531.azurewebsites.net/MJ== will redirect it to
            https://stackoverflow.com/questions/35203019/how-can-i-send-an-ajax-request-on-button-click-from-a-form-with-2-buttons

2. POST /shorten: This endpoint creates a short url for URL passed as  "Content-Type": "application/x-www-form-urlencoded"
         Body: ("Content-Type": "application/x-www-form-urlencoded")
          {
            "value": "<URL to be shortened>"
          }
      Response 200 : 
          {
            "shortURL": "https://shortenurl20190718121531.azurewebsites.net/MQ=="
          }
          
 
 Also Include in project in Unit test project to test internal services.
