## 1. Summary

I have completed all the sub-tasks of the assignment and added my own ideas.

### Project:
- Implemented access protection for API methods using a randomly generated encryption key.
- Ability to create a contract by specifying **Production Facility** and **Process Equipment Type**. 
  - Business validation returns errors in the following cases:
    - **Production Facility** not found.
    - **Process Equipment Type** not found.
    - **Equipment Quantity** must be greater than 0.
    - Checks for available space in the selected **Production Facility**. If space is insufficient, a **BadRequest** is returned with a detailed error message.
  - An **Async background processor** is implemented during contract creation, which does not block the main request and handles logging.
  
- Implemented methods:
  - **GetContract** and **DeleteContract**.
  - **GetFullContract**, which, through a foreign key, uses `Include` with the **ProcessEquipmentTypes** and **ProductionFacilities** tables so that the user can see the full contract with the selected **Equipment**, **Production Facility**, and **Equipment Quantity**.

### Additional Features:
- Added implementation for contract update requests by the user:
  - The user can create an update request, which is stored in a separate table.
  - Requests can be deleted if they are no longer relevant.
  - There is a list of all update requests that can be viewed.
  
- All business logic is validated, as in the first case.

### Cascade Delete Configuration Between Related Tables via Fluent API:
1. For **ProcessEquipmentTypes** and **ProductionFacilities**, the **Restrict** option is set, meaning that if there is a contract registered with certain **Process Equipment Type** and **Production Facility**, the data cannot be deleted.
2. For **Contract Update Requests**, the **Cascade** option is set, meaning that if a contract is deleted, the related update requests become outdated and are automatically deleted.

### Testing:
- Unit tests were written using a mocked repository and **AutoFixture**.
- Tests were written for two main controllers:
  - **CreateContract**.
  - **CreateContractUpdateRequest**.
    
## 2. Link to the Deployed Web API

The Web API is deployed and can be accessed via the following link:

[Web API Swagger UI](https://equipmentleaseservice-e5gfhtfwachrgcgz.northeurope-01.azurewebsites.net/swagger/index.html)

The API access key is provided in the `secrets.pdf`.

## 3. Setup Local Instructions

1. clone this repository - git clone
      ```
   In the `AppSettings.json` file, insert the API access key and the connection string to the database:
   - Connection string:
     ```
     Server=(localdb)\\MSSQLLocalDB;Database=EquipmentPlacementDB;Trusted_Connection=True;TrustServerCertificate=True
     ```

3. Go to the **Package Manager Console**, select the **Infrastructure** project, and run the following command:
Update-Database
Now the project is set up locally and can be tested.

## 4. Project Architecture

### a. Technologies:
- ASP.NET Core
- Entity Framework Core
- MS SQL
- Azure SQL Databases and Azure App Services
- xUnit

### b. Architecture:
The project is written using **Clean Architecture** and is divided into software layers:
- The **Controller** receives the requests.
- The **Service** processes the logic and issues commands to the **Repository**.
- The **Repository** retrieves data from the database.


## 5. Database and Schema

### a. Tables:
There are 4 tables in the database:
- **ProductionFacilities**
- **ProcessEquipmentTypes**
- **EquipmentPlacementContracts**
- **ContractUpdateRequests**

### Relationships:

- **ContractUpdateRequest → EquipmentPlacementContract**
  - **ContractId**: Many-to-One (Multiple requests for a single contract).
  
- **EquipmentPlacementContract → ProductionFacility**
  - **ProductionFacilityCode**: Many-to-One (Multiple contracts for a single production facility).
  
- **EquipmentPlacementContract → ProcessEquipmentType**
  - **ProcessEquipmentTypeCode**: Many-to-One (Multiple contracts for a single equipment type).
  
- **ProcessEquipmentType → EquipmentPlacementContract**
  - One-to-Many (One equipment type — many contracts).
  
- **ProductionFacility → EquipmentPlacementContract**
  - One-to-Many (One production facility — many contracts).

![database-schema](https://github.com/user-attachments/assets/c4240a11-1869-40a5-88f4-bd157a525ffd)

## 6. End-to-End Request Flow

The request processing flow is as follows:
- The user sends a request.
- The controller processes the request.
- Data validation and business logic are applied.
- The database is updated.
- Asynchronous processing takes place.
- The result is returned to the user.

