# Лабораторная работа: Изучение Entity Framework Core
## Тема: Информационная система Библиотека

Данный проект представляет собой реализацию лабораторной работы по изучению технологии ORM Entity Framework Core и встраиваемой базы данных SQLite

Проект адаптирован под предметную область Библиотека на основе шаблона и методических указаний

---

## Модели данных

Category (Жанр литературы):
Id, Name, Description, Books

Book (Книга фонда):
Id, Title, Author, PublishYear, PagesCount, Price, CategoryId, Category, InventoryCard

InventoryCard (Инвентарная карточка):
Id, InventoryNumber, ShelfLocation, RegistrationDate, BookId, Book

---

## Реализованные сценарии

### 1. Базовый CRUD

Добавление, чтение по Id, обновление и удаление книги:

```csharp
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

var book = db.Books.Find(newBook.Id);

book.Price = 1750.00m;
db.SaveChanges();

db.Books.Remove(book);
db.SaveChanges();
```

### 2. Отслеживание состояний (Change Tracker)

Отслеживание состояний объекта через db.Entry().State:

```csharp
var book = new Book
{
    Title = "Паттерны проектирования",
    Author = "Банда четырех",
    PublishYear = 1994,
    PagesCount = 368,
    Price = 1200.00m,
    CategoryId = 3
};

db.Books.Add(book);
db.SaveChanges();

book.Title = "Приемы ООП";

db.Books.Remove(book);
db.SaveChanges();
```

### 3. Связи и каскадное удаление

Создание связанных сущностей и каскадное удаление:

```csharp
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

db.Categories.Remove(newCategory);
db.SaveChanges();
```

---

## Запуск проекта

Запуск в Visual Studio:
Открыть файл EFTemplate.sln и нажать Ctrl + F5

Запуск через .NET CLI:
```bash
dotnet run --project EFTemplate/EFTemplate.csproj
```

---

## Стек технологий

Язык: C#
Платформа: .NET
ORM: Entity Framework Core
СУБД: SQLite
