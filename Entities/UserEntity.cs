namespace Tattelecom.Entities;

public class UsersEntity
{
    public int Id { get; set; }                 // идентификатор пользователя (первичный ключ)
    public string Login { get; set; }            // логин (уникальный)
    public string Password { get; set; }         // пароль
    public string Surname { get; set; }
    public string Name { get; set; } 
    public string Phone { get; set; }            // контактный телефон
    public string? Email { get; set; }           // электронная почта (опционально)
    public string Address { get; set; }          // адрес подключения услуг
    public DateTime Created_at { get; set; }     // дата регистрации

    public UsersEntity() { }                     // конструктор по умолчанию

    // Основной конструктор для инициализации
    public UsersEntity(
        string login,
        string password,
        string surname,
        string name,
        string phone,
        string address,
        string? email = null)
    {
        Login = login;
        Password = password;
        Surname = surname;
        Name = name;    
        Phone = phone;
        Address = address;
        Email = email;
        Created_at = DateTime.Now;               // автоматическая установка времени регистрации
    }
}