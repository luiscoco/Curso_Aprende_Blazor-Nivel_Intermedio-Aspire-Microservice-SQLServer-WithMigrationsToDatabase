using Aspire.Hosting; // Ensure this namespace is correct
using Projects; // Make sure you're referencing the correct project namespace

var builder = DistributedApplication.CreateBuilder(args);

var sqlPassword = builder.AddParameter("sql-password");

var sqldb = builder.AddSqlServer("sql", sqlPassword, port: 1234)
                       .WithDataVolume("MyDataVolume").AddDatabase("Database");

var northernTradersCatalogAPI = builder.AddProject<Microservice_AzureSQL>("microservice-azuresql")
                                       .WithExternalHttpEndpoints()
                                       .WithReference(sqldb);

builder.AddProject<DatabaseMigrations_MigrationService>("migration")
       .WithReference(sqldb);

builder.AddProject<BlazorWebAssemblyUI>("blazorwebassemblyui").WithReference(sqldb);


builder.Build().Run();
