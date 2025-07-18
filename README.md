# BlogApp Project  
A project I developed to publish my blog posts on my own website (fatihemrekilinc.xyz).
<br>
[trReadmeHere](https://github.com/fatihemregit/blogApp/blob/master/README_TR.md)
## Project Purpose  
To publish my blog posts on my own website, and thereby both share my writings and improve my web development skills.

## Tasks Completed in This Commit  
- Implementation of Role-Based Authorization system  
- Creation of a dynamic layout file  
- Configuration of the Writer Registration Page to run only once using role-based authorization  
- Setup of a Safe Delete Mechanism  
- Development of a Custom NullChecker and its use in null check codes  

## Project Journal  

### Day 1 (26.06.2025)  
- Project created  
- Unnecessary files removed from the project (Controllers/HomeController.cs, Models/ErrorViewModel, Views/Home, Views/Shared/_Layout.cshtml, Views/Shared/Error.cshtml)  
- GitHub settings configured for the project  
- Project README files created (README.md, README_TR.md)  

### Day 2 (27.06.2025)  
- Layout file created (Views/Shared/_Layout.cshtml) and its content implemented  
- Turkish README file updated (README_TR.md)  
- Removed the pre-installed Bootstrap library and added a new version  
- Installed necessary libraries for the project (Microsoft.AspNetCore.Identity, Microsoft.AspNetCore.Identity.EntityFrameworkCore, Microsoft.EntityFrameworkCore, Microsoft.EntityFrameworkCore.Design, Microsoft.EntityFrameworkCore.SqlServer, Microsoft.EntityFrameworkCore.Tools)  

### Day 3 (29.06.2025)  
- Database connection string added (secrets.json)  
- Created the required `ApplicationDbContext` class for the database  
- Created `AppUser` and `AppRole` classes required for authentication  
- Wrote extension methods needed for authentication operations (Utils/Extensions/MainExtensions.cs) and used them in `Program.cs`  
- Database migrations completed  

### Day 4 (12.07.2025)  
- Installed AutoMapper library, wrote profile class, and added necessary code block for configuration as an extension method  
- Created `Business` folder and set up its internal structure for business logic  
- Implemented `IAuthUserService` and `IAuthRoleService` interfaces  
- Implemented `AuthUserService` class by inheriting from `IAuthUserService`, and completed related classes  
- Implemented `AuthRoleService` class by inheriting from `IAuthRoleService`, and completed related classes  

### Day 5 (13.07.2025)  
- Setup custom exception infrastructure and applied it to classes in the `Business` folder  
- Implemented `Blog` and `Writer` classes and established relationships between their tables  

### Day 6 (14.07.2025)  
- Implemented `IBlogRepository` and `IWriterRepository` interfaces  
- Implemented `BlogRepository` class by inheriting from `IBlogRepository`, and completed related classes  
- Implemented `WriterRepository` class by inheriting from `IWriterRepository`, and completed related classes  

### Day 7 (15.07.2025)  
- Implemented `IBlogService` and `IWriterService` interfaces  
- Implemented `BlogService` class by inheriting from `IBlogService`, and completed related classes  
- Implemented `WriterService` class by inheriting from `IWriterService`, and completed related classes  

### Day 8 (16.07.2025)  
- Implemented `AuthUserController` and `AuthRoleController` classes and made necessary adjustments in other classes  
- Implemented helper classes required for `AuthUserController` and `AuthRoleController`  

### Day 9 (17.07.2025)  
- Implemented `WriterController` class and made necessary adjustments in other classes  
- Implemented helper classes required for `WriterController`  
- Installed the editor plugin (TinyMCE) required for writing blog posts  
- Implemented `BlogController` class and made necessary adjustments in other classes  
- Implemented helper classes required for `BlogController`  

### Day 10 (18.07.2025)  
- Implemented Role-Based Authorization system  
- Created a dynamic layout file (users only see authorized pages in the top bar)  
- Configured the Writer Registration Page to be accessible only once using role-based authorization  
- Setup of Safe Delete Mechanism  
- Developed a Custom NullChecker and used it in null check codes  

