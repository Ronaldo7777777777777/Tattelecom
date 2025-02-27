namespace Tattelecom.Entities;

public class TicketsEntity
{
    public int Id { get; set; }                     // идентификатор заявки (первичный ключ)
    public string Login_id { get; set; }                 // идентификатор пользователя (внешний ключ)
    public string Title { get; set; }                // заголовок заявки
    public string Description { get; set; }          // описание проблемы
    public int Category_id { get; set; }             // идентификатор категории (внешний ключ)
    public DateTime Preferred_time { get; set; }     // удобное время визита
    public int Status_id { get; set; }          // статус заявки (по умолчанию "Открыта")
    public DateTime Created_at { get; set; }         // дата создания
    public DateTime? Closed_at { get; set; }         // дата закрытия (null, если не закрыта)


    // Навигационные свойства (если используются)
    public UsersEntity User { get; set; }

    // Конструктор по умолчанию (обязателен для EF Core)
    public TicketsEntity() { }

    // Основной конструктор для инициализации
    public TicketsEntity(
        string loginId,
        string title,
        string description,
        int categoryid,
        DateTime preferredTime,
        int statusId = 1)
    {
        Login_id = loginId;
        Title = title;//заполняет пользователь
        Description = description;//заполняет пользователь
        Category_id = categoryid;
        Preferred_time = preferredTime;//заполняет пользователь
        Status_id = statusId;
        Created_at = DateTime.Now; // Автоматическая установка времени создания
    }


}