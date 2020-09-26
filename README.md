# MongoDB with .Net Core

The implementation is of a sample use case, of a Country database. The database has information of all the countries in the world.

The information includes,

* Country Name

* ISO Codes

* Geo Co-Ordinates

* Flag

  
The information is stored in MongoDB in the form of documents in collection, retrieved using MongoDB client in .Net & provided back over an REST API built in .Net Core 3.1. To view the information a simple Blazor web application is implemented which displays the information.

  

### MongoDB

The database is CountryDB. There are two collections in the database

| Name | Usage  |
|--|--|
| Country  | Stores the country basic information |
| Flag | Stores images of the flags of the country. The images are stored in binary format. |


Sample Country Document
```
{

"_id":{"$oid":"5f6f1c2fa04c3173a5824803"},

"StatusType":1,

"Alpha3Code":"IND",

"Alpha2Code":"IN",

"Name":"India",

"OfficialName":"Republic of India",

"Latitude":"20.46549519",

"Longitude":"78.50146222",

"Zoom":4

}
```
### REST API

The data is exposed over an Web API build with .Net Core 3.1. The solution uses repository pattern to access the data from the database.

 * Retrieve list of countries :
```
GET api/country/list
```
 * Retrieve Country Information :
```
GET api/country/Id
```
 * Retrieve flag :
```
GET api/flag/Id
```
### Running the application
Refer below links for MongoDB
 * https://docs.mongodb.com/manual/installation/  
* https://docs.mongodb.com/manual/tutorial/install-mongodb-on-windows

**Optional**

After the server is up & running,
Collections & database can be created via mongo shell 
* https://docs.mongodb.com/manual/mongo

```
use CountryDB
db.createCollection("Country")
db.createCollection("Flag")
```
Compass is an GUI based tool for working with MongoDB  
* https://www.mongodb.com/products/compass

  

**Rest API : Basics.Countries.Service**
```
dotnet run Basics.Countries.Service.csproj
```

*To seed sample data execute the **Basics.Countries.ConsoleApp** or execute [http://localhost:5000/api/seeding/run](http://localhost:5000/api/seeding/run) endpoint on the API URL.*

**Sample Client App : Basics.Countries.BlazorApp**
 

```
dotnet run Basics.Countries.BlazorApp.csproj
```
The application is default configured to run on 5010 port. http://localhost:5010