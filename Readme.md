# GroceryShopsAPI

GroceryShopsAPI is a simple Web API built with .NET Core to manage grocery shop data, including clients, products, and purchases.

## Features

- Manage clients: Retrieve client birthdays.
- Analyze purchases: List recent buyers, and view popular product categories for specific clients.

## Prerequisites

- .NET Core 6.0 or higher.
- Microsoft SQL Server.
- Visual Studio 2022 or newer.

## Setup Instructions

1. **Clone the Repository:**

   ```bash
   git clone https://github.com/Lexxxxxxa/GroceryShopsAPI.git
   cd GroceryShopsAPI
   ```

2. **Configure the Database Connection:**

   - Open `appsettings.json` and update the connection string:
     ```json
     "ConnectionStrings": {
         "DefaultConnection": "Server=Put_Your_Server;Database=GroceryShopDB;Trusted_Connection=True;TrustServerCertificate=True"
     }
     ```

3. **Restore NuGet Packages:**
   Run the following command in the terminal or package manager console:

   ```bash
   dotnet restore
   ```

4. **Apply Migrations and Seed Data:**
   Run the following commands to set up the database:

   ```bash
   dotnet ef migrations add InitialCreate
   dotnet ef database update
   ```

5. **Run the Application:**
   Use the following command to start the server:

   ```bash
   dotnet run
   ```

## API Endpoints

### Clients

- **GET** `/api/clients/birthdays?date=YYYY-MM-DD`: List clients whose birthdays are on the given date.
- **GET** `/api/clients/recent-buyers?days=N`: List recent buyers from the last N days.
- **GET** `/api/clients/popular-categories?clientId=ID`: View popular product categories for a client.

## Technologies Used

- .NET Core 6.0
- Entity Framework Core
- Microsoft SQL Server

## Notes

- Ensure the SQL Server instance allows connections and the provided connection string is valid.
- Update `TrustServerCertificate=True` in the connection string if required for your SQL Server.

