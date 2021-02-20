1. dotnet new webapi -o companyApi
2. dotnet run
3. dotnet add package Microsoft.EntityFrameworkCore.SqlServer //no se va a usar mas
4. dotnet add package Microsoft.EntityFrameworkCore.InMemory //no se va a usar mas
5. dotnet add package Npgsql
6. dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
7. dotnet add package EFCore.NamingConventions
8. dotnet tool install --global dotnet-ef
9. dotnet add package Microsoft.EntityFrameworkCore.Design
10. dotnet ef migrations add InitialMigration
11. dotnet ef database update
12. dotnet ef migrations add (lo q se agregue)

NOTAS: 
volver a una migracion especifica: dotnet ef database update InitialMigration


En la carpeta Models cada clase dentro de la carpeta representa una tabla en la base de datos  

DbContext en options van los conections strings

Modelo es una entidad y va en plural 

Startup: se conecta la configuracion a la base de datos

En controllers se CRUD y listan

IEnumerable = lista de objetos tipo branch q se puede iterar

preguntar por el -k
@
metodo PUT remplaza un elemento en la base de datos 

using System.Linq; => Permite hacer operaciones WHERE 



