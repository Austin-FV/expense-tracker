# Expense Tracker

ASP.NET Core Expense Tracker built with MVC structure to view income, expenses and visualize overall spending.

## Requirements
 - Microsoft Visual Studio
 - SQL Server installed locally
 - Microsoft SQL Server Management Studio

### Setting up Microsoft SQL Server with Entity Framework

 - Manage NuGet Packages in Dependencies
 - - Install EntityFrameworkCore (with current version of ASP.NET Core)
 - - Install EntityFrameworkCore.SqlServer
 - - Install EntityFrameworkCore.Tools
 - To change the SQL Server used go to [Modifying SQL Server](#modifying-sql-server-location).
 - If you want to use the default local sql server settings skip ahead to [Migrating the DB](#migrating-the-db) below.

<details>

<summary>

### Understanding the DB Structure

</summary>

There are two classes, Transaction and Category.

View `Category.cs` and `Transaction.cs` in the `Models` folder to view the model classes of the DB that will be migrated. You can see how these classes interact here.

`ApplicationDbContext.cs` is another class that inherits from the base class `DbContext`. This will be used with the Entity Framework to create the database. This instance is created through **Dependency Injection**. 
This is done through the `Program.cs` file as shown below, which selects that it is using SQL server with the `ApplicationDbContext`.
```
builder.Services.AddDbContext<ApplicationDbContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection")));
```
</details>

<details>

<summary>

### __Modifying SQL Server Location__ 

</summary>

In `appsettings.js` you can see where the database will be created in "DevConnection"
```
"ConnectionStrings": {
  "DevConnection": "Server=(local);Database=TransactionDB;Trusted_Connection=True;MultipleActiveResultSets=True;"
}
```
The sql server is currently set to local, but this can be changed and modified. Ex. `Server=(local)\\sql;`  
The Database name can be changed here as well to whatever you please.\

</details>

### Migrating the DB
 - Build the project
 - Open Package Manager Console
 - Enter command: `Add-Migration "Initial Create"`
 - Enter command: `Update-Database`
 - View Microsoft SQL Server Management Studio and check if "TransactionDB" is found under Databases.
 - From here you can confirm that the designs match up with the classes.