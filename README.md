# Installing App

## Prerequisites

- .NET 7.0
- Angular 16.2
- Node.js 18.17.1
- MS SQL Server (SSMS)

## Installation Steps

1. **Angular Modules Installation**:
    - Navigate to the client folder using the terminal.
    - Run the following command:
      ```
      npm install
      ```

2. **Setup API Connection**:
    - In the API folder, locate the `appsettings.Development.json` file.
    - Modify the `DefaultConnection` value to point to your server by adjusting the `server` property.

3. **Starting the Server**:
    - Navigate to the API folder using the terminal.
    - Start the server using the command:
      ```
      dotnet watch
      ```
    - Once the server starts, copy the localhost URL displayed to your clipboard.

4. **Connect the Client to API**:
    - In the client folder, locate the `environment.development.ts` file.
    - Modify the `apiUrl` property to the URL you copied from the previous step.

5. **Starting the Client**:
    - Navigate to the client folder using the terminal.
    - Start the client using the command:
      ```
      ng serve
      ```
    - Once the client starts, open your web browser and navigate to:
      ```
      http://localhost:4200/
      ```

Enjoy using the app!
