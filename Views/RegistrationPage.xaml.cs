using Tattelecom.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Tattelecom.Entities;

namespace Tattelecom
{
    public partial class RegistrationPage : ContentPage
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }

        public void GoToRegistrationPage(object sender, EventArgs e)
        {
            string login = UserLoginEntry.Text;
            string password = UserPasswordEntry.Text;
            string password2 = UserRepeatPasswordEntry.Text;
            string surname = UserSurnameEntry.Text;
            string name = UserNameEntry.Text;
            string phone = UserPhoneEntry.Text;
            string email = UserEmailEntry.Text;
            string address = UserAddressEntry.Text;

            bool isUserLoginEmpty = string.IsNullOrWhiteSpace(login);
            if (isUserLoginEmpty)
            {
                AppShell.Current.DisplayAlert("������", "��������� ��� ����!", "��");
                return;
            }

            bool isUserPasswordEmpty = string.IsNullOrWhiteSpace(password);
            if (isUserPasswordEmpty)
            {
                AppShell.Current.DisplayAlert("������", "��������� ��� ����!", "��");
                return;
            }

            bool isUserRepeatPasswordEmpty = string.IsNullOrWhiteSpace(password2);
            if (isUserRepeatPasswordEmpty)
            {
                AppShell.Current.DisplayAlert("������", "��������� ��� ����!", "��");
                return;
            }

            bool isUserSurnameEmpty = string.IsNullOrWhiteSpace(surname);
            if (isUserSurnameEmpty)
            {
                AppShell.Current.DisplayAlert("������", "��������� ��� ����!", "��");
                return;
            }

            bool isUserNameEmpty = string.IsNullOrWhiteSpace(name);
            if (isUserNameEmpty)
            {
                AppShell.Current.DisplayAlert("������", "��������� ��� ����!", "��");
                return;
            }

            bool isUserPhoneEmpty = string.IsNullOrWhiteSpace(phone);
            if (isUserPhoneEmpty)
            {
                AppShell.Current.DisplayAlert("������", "��������� ��� ����!", "��");
                return;
            }

            bool isUserEmailEmpty = string.IsNullOrWhiteSpace(email);
            if (isUserEmailEmpty)
            {
                AppShell.Current.DisplayAlert("������", "��������� ��� ����!", "��");
                return;
            }

            bool isUserAddresslEmpty = string.IsNullOrWhiteSpace(address);
            if (isUserAddresslEmpty)
            {
                AppShell.Current.DisplayAlert("������", "��������� ��� ����!", "��");
                return;
            }

            ApplicationDbContext db = new ApplicationDbContext();

            bool isUserExistByName = db.Users.Any(u => u.Login == login);
            if (isUserExistByName)
            {
                AppShell.Current.DisplayAlert("������", "���� ����� �����, ������� ������", "��");
                return;
            }

            bool isPasswordRepeatSucceded = password == password2;
            if (!isPasswordRepeatSucceded)
            {
                AppShell.Current.DisplayAlert("������", "������ �� ���������!", "��");
                return;
            }

            db.Users.Add(new UsersEntity(login, password, surname, name, phone, address, email));
            db.SaveChanges();

            AppShell.Current.DisplayAlert("�����", "����������� ��������!", "��");

            // ������� ����� ����� �������� �����������
            UserLoginEntry.Text = string.Empty;
            UserPasswordEntry.Text = string.Empty;
            UserRepeatPasswordEntry.Text = string.Empty;
            UserSurnameEntry.Text = string.Empty;
            UserNameEntry.Text = string.Empty;
            UserPhoneEntry.Text = string.Empty;
            UserEmailEntry.Text = string.Empty;
            UserAddressEntry.Text = string.Empty;

            AppShell.Current.GoToAsync("..", true);
        }

        private void GoToMenuExitPage(object sender, EventArgs e)
        {
            AppShell.Current.GoToAsync("//LoginPage");
        }
    }
}