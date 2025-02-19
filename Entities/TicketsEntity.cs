﻿namespace Tattelecom.Entities;

public class TicketsEntity
{
    public int Id { get; set; }                     // идентификатор заявки (первичный ключ)
    public int User_id { get; set; }                 // идентификатор пользователя (внешний ключ)
    public string Title { get; set; }                // заголовок заявки
    public string Description { get; set; }          // описание проблемы
    public int Category_id { get; set; }             // идентификатор категории (внешний ключ)
    public DateTime Preferred_time { get; set; }     // удобное время визита
    public int Status_id { get; set; }          // статус заявки (по умолчанию "Открыта")
    public string Priority { get; set; } // приоритет (low/medium/high)
    public DateTime Created_at { get; set; }         // дата создания
    public DateTime? Closed_at { get; set; }         // дата закрытия (null, если не закрыта)

    public TicketsEntity() { } // Конструктор по умолчанию

    // Основной конструктор для инициализации
    public TicketsEntity(
        int userId,
        string title,
        string description,
        int category_id,
        DateTime preferredTime,
        string priority = "medium",
        int statusId = 1)
    {
        User_id = userId;
        Title = title;
        Description = description;
        Category_id = category_id;
        Preferred_time = preferredTime;
        Priority = priority;
        Status_id = statusId;
        Created_at = DateTime.Now; // Автоматическая установка времени создания
    }
}