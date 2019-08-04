# comodo4server

### Technology:
###### The applicatin is created with `Asp.Net Core Web Api`, language `C#`.
###### Data base - `MongoDb`.
###### Connectin to Data base - `C# mongo driver`.
###### Api documentation - `Swagger`.
###### For logger - `nLog` library.

## Before starting application server preconditions has to be met !!!
###### 1. MongoDb has to be install.
###### 2. Execute command `mongoimport --db comodo4db --collection Infos --type json --file "[file path]/comodo4db.json" --jsonArray` this comand will create databese and import data into collection.


## How to start application server:
###### 1. Clone project with command `git clone https://github.com/adrimrutra/Application-Development.git` 
###### 2. Open Command Prompt, navigate to the `Application-Development/Application-Development` directory, execute command `dotnet restore` - this will install all the nesesery libraries.
###### 3. Execute command `dotnet user-secrets set ConnectionString "mongodb://localhost:27017"` 
###### 4. Execute command `dotnet user-secrets set Database "comodo4db"` this will create environment variables.
###### 5. Execute `dotnet run` command, this will start sever on `https://localhost:5000`.
