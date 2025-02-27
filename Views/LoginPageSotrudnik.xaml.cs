using Tattelecom.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Maui.Controls;

namespace Tattelecom
{
    public partial class LoginPageSotrudnik : ContentPage
    {
        public  LoginPageSotrudnik()
        {
            InitializeComponent();
        }
        private async void GoToSotrudnikPage(object sender, EventArgs e)
        {
            string login = SotrudnikLoginEntry.Text;
            string password = SotrudnikPasswordEntry.Text;
            string full_name = SotrudnikSurnameEntry.Text;
            string position = SotrudnikDolEntry.Text;
            string department = SotrudnikOtdelEntry.Text;
            string phone = SotrudnikPhoneEntry.Text;


            // Проверка на пустые поля
            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(full_name) 
                || string.IsNullOrWhiteSpace(position) || string.IsNullOrWhiteSpace(department) || string.IsNullOrWhiteSpace(phone) )
            {
                await DisplayAlert("Ошибка", "Заполните все поля!", "OK");
                return;
            }

            ApplicationDbContext db = new ApplicationDbContext();

            try
            {
                // Поиск пользователя в базе данных
                var  employe= await db.Employees.FirstOrDefaultAsync(e => e.Login == login && e.Password == password && e.Full_name == full_name 
                && e.Position == position && e.Department == department && e.Phone == phone);

                if (employe == null)
                {
                    await DisplayAlert("Ошибка", "Неверные данные!", "OK");
                    return;
                }

                // Успешная авторизация
                await DisplayAlert("Успех", "Вы успешно вошли!", "OK");
                await Shell.Current.GoToAsync("//MainPage");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ошибка", $"Произошла ошибка: {ex.Message}", "OK");
            }
        }

        private async void GoToMenuExitPage(object sender, EventArgs e)
        {
            // Переход на страницу входа
            await Shell.Current.GoToAsync("//LoginPage");
        }

    }
}