Install-Package Microsoft.EntityFrameworkCore
Install-Package Microsoft.EntityFrameworkCore.Design
Install-Package Npgsql.EntityFrameworkCore.PostgreSQL

Add-Migration InitialCreate
Update-Database
