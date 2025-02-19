namespace Tattelecom.Entities;

public class EmployeesEntity
{
    public int Id { get; set; }                 // идентификатор сотрудника (первичный ключ)
    public string Login { get; set; }           // логин для входа
    public string Password { get; set; }        // пароль
    public string Full_name { get; set; }       // ФИО сотрудника
    public string Position { get; set; }        // должность
    public string Department { get; set; }      // отдел/подразделение
    public string Phone { get; set; }           // контактный телефон
    public bool Is_admin { get; set; }          // флаг администратора

    public EmployeesEntity() { }                // конструктор по умолчанию

    // Конструктор для инициализации
    public EmployeesEntity(
        string login,
        string password,
        string fullName,
        string position,
        string department,
        string phone,
        bool isAdmin = false)
    {
        Login = login;
        Password = password;
        Full_name = fullName;
        Position = position;
        Department = department;
        Phone = phone;
        Is_admin = isAdmin;
    }
}