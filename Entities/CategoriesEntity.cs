namespace Tattelecom.Entities;

public class CategoriesEntity
{
    public int Id { get; set; } // идентификатор категории (первичный ключ)
    public string Name { get; set; } // название категории

    public CategoriesEntity() { } // конструктор по умолчанию, нужен для корректной работы Entity Framework Core

    public CategoriesEntity( // новый конструктор для удобной инициализации
        string name)
    {
        Name = name;
    }
}