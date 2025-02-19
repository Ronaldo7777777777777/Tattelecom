namespace Tattelecom.Entities;

public class AssignmentsEntity
{
    public int Id { get; set; } // идентификатор назначения (первичный ключ)
    public int Ticket_id { get; set; } // идентификатор заявки (внешний ключ)
    public int Employee_id { get; set; } // идентификатор сотрудника (внешний ключ)
    public DateTime AssignedAt { get; set; } // дата назначения
    public DateTime? CompletedAt { get; set; } // дата завершения (может быть null, если заявка еще не завершена)

    public AssignmentsEntity() { } // конструктор по умолчанию, нужен для корректной работы Entity Framework Core

    public AssignmentsEntity( // новый конструктор для удобной инициализации
        int ticketid,
        int employeeid,
        DateTime assignedAt,
        DateTime? completedAt = null)
    {
        Ticket_id = ticketid;
        Employee_id = employeeid;
        AssignedAt = assignedAt;
        CompletedAt = completedAt;
    }
}