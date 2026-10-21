using System;
using EFTemplate.Data;
using EFTemplate.Models;

namespace EFTemplate.Demos;

public static class ChangeTracker
{
    public static void Run(AppDbContext db)
    {
        Console.WriteLine("\n2. Change Tracker");

        var book = new Book
        {
            Title = "Паттерны проектирования",
            Author = "Банда четырех",
            PublishYear = 1994,
            PagesCount = 368,
            Price = 1200.00m,
            CategoryId = 3
        };
        Console.WriteLine($"1. Новый объект: State = {db.Entry(book).State}");

        db.Books.Add(book);
        Console.WriteLine($"2. После Add: State = {db.Entry(book).State}");

        db.SaveChanges();
        Console.WriteLine($"3. После SaveChanges: State = {db.Entry(book).State}");

        book.Title = "Приемы ООП";
        Console.WriteLine($"4. После изменения свойства: State = {db.Entry(book).State}");

        db.Books.Remove(book);
        Console.WriteLine($"5. После Remove: State = {db.Entry(book).State}");

        db.SaveChanges();
        Console.WriteLine($"6. После удаления и SaveChanges: State = {db.Entry(book).State}");
    }
}
