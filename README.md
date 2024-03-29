# SETUP

## 1. Clone the Repository
## 2. Configure appsettings.json

  - Create an appsettings.json file in the root directory. See the template below:

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
    "TodoDbConnectionString": "<Your Database Connection String>"
  }
}
```
- Replace <Your Database Connection String> with your actual connection string for your database (Azure SQL or local SQL Server).

## 3. Install SQL Server and SQL Server Management Studio (SSMS)

   - Download and install SQL Server from [here](https://www.microsoft.com/en-us/sql-server/sql-server-downloads).
   - Download and install SQL Server Management Studio (SSMS) from [here](https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16).


## 5. Build
- Open the solution in your preferred IDE (Visual Studio, Visual Studio Code, etc.).
run Build.

## 6. Code-First Approach
 For the code-first approach, follow these steps:

- Open the Package Manager Console.
- Run Add-Migration <MigrationName> to scaffold a migration.
- Run Update-Database to apply the migration and create the database.

## 7. Run the App

## Relevant Links: 
- [Getting Started with Entity Framework Core](https://learn.microsoft.com/en-us/ef/core/get-started/overview/first-app?tabs=netcore-cli)
- [Azure SQL](https://learn.microsoft.com/en-us/azure/azure-sql/database/sql-database-paas-overview?view=azuresql)
- [ASP.NET Core Web API](https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-8.0&tabs=visual-studio)

