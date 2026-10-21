using System;
using EFTemplate.Models;

namespace EFTemplate.Data;

public static class DbInitializer
{
    public static void ResetAndSeed(AppDbContext context)
    {
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        var classics = new Category
        {
            Name = "Русская классика",
            Description = "Шедевры отечественной классической литературы"
        };

        var sciFi = new Category
        {
            Name = "Научная фантастика",
            Description = "Произведения о технологиях и будущем"
        };

        var programming = new Category
        {
            Name = "Программирование",
            Description = "Литература по разработке ПО"
        };

        var book1 = new Book
        {
            Title = "Мастер и Маргарита",
            Author = "Михаил Булгаков",
            PublishYear = 1967,
            PagesCount = 480,
            Price = 650.00m,
            Category = classics,
            InventoryCard = new InventoryCard
            {
                InventoryNumber = "ИНВ-КЛ-001",
                ShelfLocation = "Стеллаж 1, Полка А"
            }
        };

        var book2 = new Book
        {
            Title = "Преступление и наказание",
            Author = "Фёдор Достоевский",
            PublishYear = 1866,
            PagesCount = 672,
            Price = 720.00m,
            Category = classics,
            InventoryCard = new InventoryCard
            {
                InventoryNumber = "ИНВ-КЛ-002",
                ShelfLocation = "Стеллаж 1, Полка Б"
            }
        };

        var book3 = new Book
        {
            Title = "Пикник на обочине",
            Author = "Аркадий и Борис Стругацкие",
            PublishYear = 1972,
            PagesCount = 256,
            Price = 490.00m,
            Category = sciFi,
            InventoryCard = new InventoryCard
            {
                InventoryNumber = "ИНВ-ФН-001",
                ShelfLocation = "Стеллаж 3, Полка В"
            }
        };

        context.Categories.AddRange(classics, sciFi, programming);
        context.Books.AddRange(book1, book2, book3);
        context.SaveChanges();

        Console.WriteLine("База данных пересоздана и наполнена\n");
    }
}
