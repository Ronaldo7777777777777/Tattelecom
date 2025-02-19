namespace Tattelecom.Entities;

public class StatusesEntity
{
    public int Id { get; set; } // идентификатор статуса (первичный ключ)
    public string Name { get; set; } // название статуса

    public StatusesEntity() { } // конструктор по умолчанию, нужен для корректной работы Entity Framework Core

    public StatusesEntity( // новый конструктор для удобной инициализации
        string name)
    {
        Name = name;
    }
}