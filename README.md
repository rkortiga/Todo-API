# SETUP

## 1. Clone the Repository
- Clone the repository by running `git clone https://github.com/rkortiga/Todo-API.git` in your terminal. You can also download the repository as a zip file and extract it.

## 2. Delete the Migrations folder
- You will have to delete this folder as you will be running your migration in the next steps

## 3. Install SQL Server and SQL Server Management Studio (SSMS)
- Download and install SQL Server from [here](https://www.microsoft.com/en-us/sql-server/sql-server-downloads).
- Download and install SQL Server Management Studio (SSMS) from [here](https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16).

## 4. Configure appsettings.json
- Create an appsettings.json file in the root directory. See the image and template below:
    ![image](https://github.com/rkortiga/Todo-API/assets/125756155/b9f369bd-8bdc-4bb4-9356-92f59dbf088c)

```
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "<Your Database Connection String>"
  }
}
```
- Replace <Your Database Connection String> with your actual connection string for your database (Azure SQL or local SQL Server).

## 5. Build
- Open the solution in your preferred IDE (Visual Studio, Visual Studio Code, etc.) and then Run Build. <br>
    ### Note (If you are using Visual Studio Code)
    > You have to install Entity Framework Core Tools if you haven't done so already. Navigate to the root directory, and then install the tools by running `dotnet tool install --global dotnet-ef` in your terminal.
    > 
    > Next, open the Program.cs file, and specify the Swagger JSON endpoint by adding the code in the `app.UseSwaggerUI()` method.
    >
    ```
        c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Todo_API v1");
            c.RoutePrefix = string.Empty;
        }
    ```
    > It should look like this: <br>
    > ![image](https://github.com/rkortiga/Todo-API/assets/125756155/85197f14-b85a-44a3-99a5-4da75ddb3a4b)


## 7. Code-First Approach
 For the code-first approach, follow these steps:

- Open the Package Manager Console.
- Run `Add-Migration <MigrationName>` to scaffold a migration.
- Run `Update-Database` to apply the migration and create the database.<br>
    ### Note (If you are using Visual Studio Code)
    > Add the migration and update the database by running the commands `dotnet ef migrations add <MigrationName>` and `dotnet ef database update` in your terminal respectively.

## 8. Run the App

   ### Note (If you are using Visual Studio Code)
   > You can run the program by running the commands `dotnet build` and then `dotnet run` in your terminal respectively.
   > Then open the port that your program is listening to. Typically, you'll see a message like "Now listening on: https://localhost:xxxx" or "Now listening on: http://localhost:xxxx" in the terminal output, where "xxxx" is the port number assigned to your application. Like the image below:
   > 
   > ![image](https://github.com/rkortiga/Todo-API/assets/125756155/d3bea879-33b4-4445-bf3d-9ae9a2ab6196)


## Relevant Links: 
- [Getting Started with Entity Framework Core](https://learn.microsoft.com/en-us/ef/core/get-started/overview/first-app?tabs=netcore-cli)
- [Azure SQL](https://learn.microsoft.com/en-us/azure/azure-sql/database/sql-database-paas-overview?view=azuresql)
- [ASP.NET Core Web API](https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-8.0&tabs=visual-studio)
- [SQL Server technical documentation](https://learn.microsoft.com/en-us/sql/sql-server/?view=sql-server-ver15)
- [ASP.NET Core web API documentation with Swagger / OpenAPI](https://learn.microsoft.com/en-us/aspnet/core/tutorials/web-api-help-pages-using-swagger?view=aspnetcore-8.0)

