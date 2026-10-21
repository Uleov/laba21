using System;
using EFTemplate.Data;
using EFTemplate.Demos;

using (var db = new AppDbContext())
{
    DbInitializer.ResetAndSeed(db);

    CrudOperations.Run(db);
    ChangeTracker.Run(db);
    RelationshipsDemo.Run(db);
}

Console.WriteLine("\nНажмите любую клавишу для завершения...");
if (!Console.IsInputRedirected)
{
    Console.ReadKey();
}
