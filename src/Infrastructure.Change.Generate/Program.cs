using System;
using Infrastructure.Change.Generate;

Console.WriteLine("...");

using var context = new DesignTimeDbContextFactory().CreateDbContext(Array.Empty<string>());
context.Database.EnsureCreated();

Console.WriteLine("...");
