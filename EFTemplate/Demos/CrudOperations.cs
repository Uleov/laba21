using System;
using EFTemplate.Data;
using EFTemplate.Models;

namespace EFTemplate.Demos;

public static class CrudOperations
{
    public static void Run(AppDbContext db)
    {
        Console.WriteLine("1. CRUD операции");

        Console.WriteLine("\nДобавление книги:");
        var newBook = new Book
        {
            Title = "Чистый код",
            Author = "Роберт Мартин",
            PublishYear = 2008,
            PagesCount = 464,
            Price = 1500.00m,
            CategoryId = 3
        };
        db.Books.Add(newBook);
        db.SaveChanges();
        Console.WriteLine($"Книга добавлена с Id: {newBook.Id}");

        Console.WriteLine("\nПоиск по Id:");
        var book = db.Books.Find(newBook.Id);
        Console.WriteLine($"Найдена: {book?.Title} ({book?.Author}), Цена: {book?.Price}");

        Console.WriteLine("\nОбновление цены:");
        if (book != null)
        {
            book.Price = 1750.00m;
            db.SaveChanges();
            Console.WriteLine($"Новая цена сохранена: {book.Price}");
        }

        Console.WriteLine("\nУдаление книги:");
        if (book != null)
        {
            db.Books.Remove(book);
            db.SaveChanges();
            Console.WriteLine("Книга удалена");
        }
    }
}
