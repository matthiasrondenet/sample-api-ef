dotnet ef migrations add Initial --startup-project Infrastructure.Change.Generate
dotnet ef database update --startup-project Infrastructure.Change.Generate

