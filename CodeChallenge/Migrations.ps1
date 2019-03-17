#Go to the DAL project

cd .\CodeChallenge.DAL

dotnet ef migrations add InitialMigration -v -s ..\CodeChallenge.Api\CodeChallenge.Api.csproj

cd ..