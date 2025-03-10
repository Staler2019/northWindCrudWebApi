#!/bin/sh

cd ../northWindCrudApi.Data
dotnet ef dbcontext scaffold "server=localhost;Database=NorthWind;MultipleActiveResultSets=True;TrustServerCertificate=True;User=SA;" Microsoft.EntityFrameworkCore.SqlServer -o Data -c ApplicationDbContext -f

cd ../scripts