using System;
using System.Collections.Generic;
using System.Linq;
using EFTemplate.Data;
using EFTemplate.Models;

namespace EFTemplate.Demos;

public static class RelationshipsDemo
{
    public static void Run(AppDbContext db)
    {
        Console.WriteLine("\n3. Связи и каскадное удаление");

        var newCategory = new Category
        {
            Name = "Временный раздел",
            Description = "Временное хранилище",
            Books = new List<Book>
            {
                new Book
                {
                    Title = "Временная книга",
                    Author = "Автор",
                    PublishYear = 2000,
                    PagesCount = 100,
                    Price = 200.00m,
                    InventoryCard = new InventoryCard
                    {
                        InventoryNumber = "ИНВ-ВРЕМ-01",
                        ShelfLocation = "Полка 9"
                    }
                }
            }
        };

        db.Categories.Add(newCategory);
        db.SaveChanges();
        Console.WriteLine($"Категория '{newCategory.Name}' создана со связанной книгой и карточкой");

        Console.WriteLine("\nУдаляем категорию:");
        db.Categories.Remove(newCategory);
        db.SaveChanges();

        var orphanBook = db.Books.FirstOrDefault(b => b.Title == "Временная книга");
        var orphanCard = db.InventoryCards.FirstOrDefault(c => c.InventoryNumber == "ИНВ-ВРЕМ-01");

        Console.WriteLine($"Книга найдена в базе: {(orphanBook != null ? "Да" : "Нет (удалена каскадно)")}");
        Console.WriteLine($"Карточка найдена в базе: {(orphanCard != null ? "Да" : "Нет (удалена каскадно)")}");
    }
}
