# traveller2guider
Web application with ASP.NET technology in MVC architecrure.
It is a simple project that I am still working on it. The application has got 3 types of users, the first type of user is the "Traveller"
and the second type of user is "Guider". The third type of user is "Admin" and "SuperAdmin" whcih is for adminstration use. The treveller 
is typing the place that he want to visit (i.e. arcehological places, city, or anything) and based on the place that he typed, guiders are 
showing near that place in distance of 100 km. Then the traveller can book a trip with a guider that he likes. After the booking a
notification will notify the guider for the guide, after that the guider has got the chance to accept or reject the reservation. If the
reservation is accepted from the guider then, a conversation is created automatically beetween the traveller and guider.
Traveller can see the profile of guider check his abilities, his knowledge, his photo profile, his activities that he offers and so more.
On the other hand guider can customize his profile, adding skills that he has got and providing a list of activities that he offers.
After the services of the guider to the traveller which has booked the trip with him, the application is giving the chance to the traveller
to rate and comment about the services. Ratings and comments are only amvailable after the full service of the guider.

This application uses MVC technology in Razor view, Entity Framework, linq and fluent API techniques, triggers, ajax calls, geolocation Google API and so more.
The databse diagram:
![img](https://github.com/KarenNersesian/traveller2guider/blob/master/traveller2guiderDatabaseDiagram.png)
