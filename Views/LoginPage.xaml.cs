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

            // �������� �� ������ ����
            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
            {
                await DisplayAlert("������", "��������� ��� ����!", "OK");
                return;
            }
            // � ������ Auth_Button ������ LoginPage:

            ApplicationDbContext db = new ApplicationDbContext();

            try
            {
                // ����� ������������ � ���� ������
                var user = await db.Users.FirstOrDefaultAsync(u => u.Login == login && u.Password == password);

                if (user == null)
                {
                    await DisplayAlert("������", "�������� ����� ��� ������!", "OK");
                    return;
                }

                if (user != null)
                {
                    // �������� ID ������������ �� �������� �������� ������
                    await Shell.Current.GoToAsync($"{nameof(CreateTicketPage)}?userId={user.Id}");

                    // �������� �����������
                    await DisplayAlert("�����", "�� ������� �����!", "OK");
                    await Shell.Current.GoToAsync("//CreateTicketPage");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("������", $"��������� ������: {ex.Message}", "OK");
            }
        }

        private async void Go_To_Registration_Button(object sender, EventArgs e)
        {
            // ������� �� �������� �����������
            await Shell.Current.GoToAsync("//RegistrationPage");
        }

        private async void Go_To_Sotrudnik_Button(object sender, EventArgs e)
        {
            // ������� �� �������� ��� ���������
            await Shell.Current.GoToAsync("//LoginPageSotrudnik");
        }
    }
}