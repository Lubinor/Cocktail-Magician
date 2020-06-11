# CocktailМagician
Cocktail Magician is a web applcation that allows creation of recipes for innovative, exotic, awesome cocktails and follows their distribution and success in amazing bars.


## Team Members
* Lubomir Iliev - [GitHub](https://github.com/Lubinor)
* Ivo Grigorov - [GitHub](https://github.com/Grigoroff81)

## Project Description
### Access Roles
* **Non-registered users/visitors** - anonymous visitors
* **Bar Crawlers** - registered users
* **Cocktail Magicians** - site administrators

#### Unauthenticated Visitors
* Visitors have access to the home screen, the login and register pages, and can browse through all of the website content, without being able to create, modify or delete any of it.

![Alt text](https://user-images.githubusercontent.com/56739613/84328714-67e3af00-ab8b-11ea-947d-d831b80b2a08.jpg)

* Browsing through the website is done through the navigation bar, with the 4 main categories being Ingredients, Cocktails, Bars and Cities.

![Alt text](https://user-images.githubusercontent.com/56739613/84329174-a6c63480-ab8c-11ea-929b-06ffcbde19ec.jpg)

* The Ingredients page shows a list with all existing ingredients, along with all the cocktails they are part of. Clicking on an ingredient opens up a details page, where this information is displayed for this ingredient only. Each cocktail is also clickable and redirects to its own details page. 

![Alt text](https://user-images.githubusercontent.com/56739613/84329350-3370f280-ab8d-11ea-9adb-e5f2110ae97b.jpg)

* The Cocktails page shows a list with all existing cocktails, their ingredients, the bars they are offered in, and also their average rating in the form of a progress bar. Clicking on a cocktail opens up a details page, where this information is displayed for this cocktail only. Each bar is also clickable and redirects to its own details page.

![Alt text](https://user-images.githubusercontent.com/56739613/84329924-afb80580-ab8e-11ea-8c50-0cbd11a3acc5.jpg)

* The Cities page shows a list with all existing cities and their respective bars. Again, each city is clickable, with a separate page and isolated view of its details.

![Alt text](https://user-images.githubusercontent.com/56739613/84330156-4dabd000-ab8f-11ea-933e-b784ebfb089d.jpg)

* The Bars page shows all bars, the cocktails offered in each one, as well as details about the city they are in, their address, phone and average rating. Bars are also clickable for a separate view of their details.

![Alt text](https://user-images.githubusercontent.com/56739613/84330364-de82ab80-ab8f-11ea-9125-1f65e41eb664.jpg)


#### Registered Users (Bar Crawlers)

* After login, Bar Crawlers can access the same content as anonymous visitors, plus the option to:
      
     * Review bars and cocktails by giving them rating and leaving comments
     * Edit/Delete their reviews
     
     ![Alt text](https://user-images.githubusercontent.com/56739613/84330767-f60e6400-ab90-11ea-9231-2e03b0ce6993.jpg)
     
     ![Alt text](https://user-images.githubusercontent.com/56739613/84330894-4eddfc80-ab91-11ea-925f-214b947e791c.jpg)
     

#### Administrators (Cocktail Magicians)
* Admins can:
     * Manage ingredients – CRUD operations for ingredients for cocktails
     * Manage cocktails – CRUD operations for cocktails
     * Manage cities – CRUD operations for cities
     * Manage bars – CRUD operations for bars
     * Set cocktails as available in particular bars 
     
![Alt text](https://user-images.githubusercontent.com/56739613/84330996-a8462b80-ab91-11ea-8a22-5fa1fd5b7f47.jpg)

![Alt text](https://user-images.githubusercontent.com/56739613/84331042-d0ce2580-ab91-11ea-9460-27a8516817c7.jpg)

![Alt text](https://user-images.githubusercontent.com/56739613/84331149-24d90a00-ab92-11ea-8b78-bf1b10721cc2.jpg)

## Technologies
* ASP.NET Core MVC
* ASP.NET Identity
* Entity Framework Core
* MS SQL Server
* Razor
* HTML
* CSS
* Bootstrap
* JavaScript / jQuery
* AJAX
* AppVeyor


## Database Diagram

![Alt text](https://user-images.githubusercontent.com/56739613/84331475-ef80ec00-ab92-11ea-8267-1484f2ce77c3.jpg)
