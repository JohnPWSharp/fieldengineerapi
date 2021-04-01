# Field Engineer Web API

This repo stores the code for a simple Web API that presents information helpful to heating engineers working in the field to maintain and fix furnaces in domestic settings. This API supports the document **The fusion development approach to building power apps**. In the document, the development of a Power App, which integrates with this Web API, is described.

This repo also includes the JSON definition for the Logic App created in the document.

## Prerequisites

- PowerShell
- .NET 5.0
- git
- Visual Studio Code
- Azure Tools for Visual Studio Code
- Azure subscription
- Azure CLI

## Set up an Azure SQL Database server

The Web API requires three SQL databases:

- ScheduleDB. This database stores appointment details.
- InventoryDB. This database stores information about boiler parts and their stock numbers.
- KnowledgeBaseDB. This database stores technical tips on each boiler part.

You can set up these databases in Azure SQL Database by following these steps:

1. Start PowerShell and navigate to a directory where you want to keep the source code.
1. To clone the source code, enter this command:

    <!-- TODO: Update this URL, when we know the final repo location -->
    ```powershell
    git clone https://github.com/alistairmatthews/fieldengineerapi.git
    cd fieldengineerapi
    ```

1. To log into your Azure subscription run this command, and enter your credentials:

    ```powershell
    az login
    ```

1. To create an Azure SQL Database server, run this command, and then enter a resource group name, SQL server name, and an Azure location, such as **westus**:

    ```powershell
    .\databasesetup.ps1
    ```

<!-- TODO: execute the SQL scripts here. -->

1. Log into the Azure portal, and navigate to **All resources**. Select the SQL Server you created in the previous step.
1. Under **Security** select, **Firewalls and virtual networks**.
1. Select **Add client IP**.
1. Under **Allow Azure services and resources to access this server**, select **Yes**, and then select **Save**.

## Configure the Web API and create databases

1. In your local **PowerShell** instance, start Visual Studio Code:

    ```powershell
    code .
    ```

1. Open **appsettings.json**. There are three connections strings in the file. In each connection string, replace **fieldengineersqlserver** with the name of the SQL server you created above.
1. Open **appsettings.Development.json**. In each connection string, replace **fieldengineersqlserver** with the name of the SQL server you created above.

<!-- TODO: Remove these calls when the SQL Scripts are complete -->

1. To create the databases by using Entity Framework, run these commands:

    ```powershell
    dotnet tool install --global dotnet-ef
    dotnet ef migrations add InitialDeployment --context InventoryContext --output-dir Migrations/Inventory
    dotnet ef database update --context InventoryContext
    dotnet ef migrations add InitialDeployment --context ScheduleContext --output-dir Migrations/Schedule
    dotnet ef database update --context ScheduleContext
    dotnet ef migrations add InitialDeployment --context KnowledgeBaseContext --output-dir Migrations/KnowledgeBase
    dotnet ef database update --context KnowledgeBaseContext
    ```

## Deploy the Web API in the Azure App Service

1. In Visual Studio Code, press **CTRL + SHIFT + P**, type **Azure: Sign-In** and then press **Enter**.
1. In the browser window, sign into Azure with your usual credentials, and then close the browser window.
1. To open the Azure Tools, press **CTRL + SHIFT + A** and then select the **APP SERVICE** window.
1. Right-click your subscription, and then select **Create New Web API**.
1. Enter a name for the Web API and then press **Enter**.
1. Select the **.NET 5** runtime stack and then select the **Free** pricing tier. Azure creates the new Web API.
1. Right-click the new Web API, and then select **Deploy to Web App**.
1. In the Visual Studio Code dialog, select **Deploy**. Visual Studio Code deploys the Web API to Azure.

## Example API calls

You can examine and experiment with the Field Engineer Web API by using the Swagger user interface:

**http://&lt;yourapi&gt;.azurewebsites.net/swagger**

To issue requests to the Web API, you can use the **curl** tool.

To return a list of all parts that field engineers can use, use this command:

```powershell
curl -x GET "http://<yourapi>.azurewebsites.net/api/boilerparts" -H "accept: text/plain"
```

To return a list of all appointments for all engineers, use:

```powershell
curl -x GET "http://<yourapi>.azurewebsites.net/api/appointments" -H "accept: text/plain"
```

To return a list of all engineers, use:

```powershell
curl -x GET "http://<yourapi>.azurewebsites.net/api/scehduleengineer" -H "accept: text/plain"
```

To create a new appointment, use:

```powershell
curl -X POST "https://<yourapi>.azurewebsites.net/api/Appointments" 
    -H "accept: text/plain" -H "Content-Type: application/json" 
    -d "{\"customerId\":1,\"problemDetails\":\"string\",\"engineerId\": <Guid>,\"startDateTime\":\"2021-03-22T14:23:45.434Z\"}
```

To see a list of all customers and obtain their IDs, use:

```powershell
curl -x GET "http://<yourapi>.azurewebsites.net/api/customers" -H "accept: text/plain"
```

To see a list of all the problems and solutions for a given customer, use:

```powershell
curl -X GET "https://<yourapi>.azurewebsites.net/api/Customers/<customersid>/Notes" -H  "accept: text/plain"
```

To see a list of all open orders, use:

```powershell
curl -X GET "https://<yourapi>.azurewebsites.net/api/Orders/Open" -H  "accept: text/plain"
```