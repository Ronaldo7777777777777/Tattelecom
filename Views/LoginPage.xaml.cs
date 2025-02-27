using Tattelecom.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Maui.Controls;

namespace Tattelecom
{
    public partial class LoginPage : ContentPage
    {

        public LoginPage()
        {
            InitializeComponent();
  
        }

        private async void Auth_Button(object sender, EventArgs e)
        {
            string login = userLogin.Text;
            string password = userPassword.Text;

            // Проверка на пустые поля
            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
            {
                await DisplayAlert("Ошибка", "Заполните все поля!", "OK");
                return;
            }
            // В методе Auth_Button класса LoginPage:

            ApplicationDbContext db = new ApplicationDbContext();

            try
            {
                // Поиск пользователя в базе данных
                var user = await db.Users.FirstOrDefaultAsync(u => u.Login == login && u.Password == password);

                if (user == null)
                {
                    await DisplayAlert("Ошибка", "Неверный логин или пароль!", "OK");
                    return;
                }

                if (user != null)
                {
                    // Передаем ID пользователя на страницу создания заявки
                    await Shell.Current.GoToAsync($"{nameof(CreateTicketPage)}?userId={user.Id}");

                    // Успешная авторизация
                    await DisplayAlert("Успех", "Вы успешно вошли!", "OK");
                    await Shell.Current.GoToAsync("//CreateTicketPage");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ошибка", $"Произошла ошибка: {ex.Message}", "OK");
            }
        }

        private async void Go_To_Registration_Button(object sender, EventArgs e)
        {
            // Переход на страницу регистрации
            await Shell.Current.GoToAsync("//RegistrationPage");
        }

        private async void Go_To_Sotrudnik_Button(object sender, EventArgs e)
        {
            // Переход на страницу для персонала
            await Shell.Current.GoToAsync("//LoginPageSotrudnik");
        }
    }
}