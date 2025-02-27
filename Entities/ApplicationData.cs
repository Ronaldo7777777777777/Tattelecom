using Tattelecom.Entities;

public static class ApplicationData
{
    // Статическое поле для хранения данных текущего пользователя
    public static UsersEntity CurrentUser { get; set; } = null!;
}