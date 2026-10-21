using System;

namespace EFTemplate.Models;

public class InventoryCard
{
    public int Id { get; set; }
    public string InventoryNumber { get; set; } = string.Empty;
    public string ShelfLocation { get; set; } = string.Empty;
    public DateTime RegistrationDate { get; set; } = DateTime.Now;

    public int BookId { get; set; }
    public Book? Book { get; set; }
}
