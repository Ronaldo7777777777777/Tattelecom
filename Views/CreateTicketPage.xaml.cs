using Tattelecom.DatabaseContext;
using Tattelecom.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Maui.Controls;

namespace Tattelecom
{
    public partial class CreateTicketPage : ContentPage
    {
        public CreateTicketPage()
        {
            InitializeComponent();

        }

        private async void CreateTicketButton_Clicked(object sender, EventArgs e)
        {
            string title = TitleEntry.Text;
            string description = DescriptionEntry.Text;
            string categoryName = CategoryPicker.SelectedItem?.ToString();
            DateTime preferredTime = PreferredTimePicker.Date;

            if (string.IsNullOrWhiteSpace(title) ||
                string.IsNullOrWhiteSpace(description) ||
                string.IsNullOrWhiteSpace(categoryName))
            {
                await DisplayAlert("Ошибка", "Заполните все поля!", "OK");
                return;
            }

            using (var db = new ApplicationDbContext())
            {

                if (ApplicationData.CurrentUser == null)
                {
                    await DisplayAlert("Ошибка", "Пользователь не авторизован!","ОК");
                    return;
                }
                try
                {
                    var category = await db.Categories.FirstOrDefaultAsync(c => c.Name == categoryName)?? new CategoriesEntity(categoryName);
                    if (category.Id == 0)
                    {
                        db.Categories.Add(category);
                        await db.SaveChangesAsync();
                    }
                    var status = await db.Statuses .FirstOrDefaultAsync(s => s.Name == "Открыта")?? new StatusesEntity("Открыта");
                    if (status.Id == 0)
                    {
                        db.Statuses.Add(status);
                        await db.SaveChangesAsync();
                    }



                    var ticket = new TicketsEntity(
                        loginId: ApplicationData.CurrentUser.Login, 
                        title: title,
                        description: description,
                        categoryid: category.Id,
                        preferredTime: preferredTime,
                        statusId: status.Id
                    );

                    db.Tickets.Add(ticket);
                    await db.SaveChangesAsync();

                    await DisplayAlert("Успех", "Заявка создана!", "OK");
                    await Shell.Current.GoToAsync("..");
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Ошибка", ex.Message, "OK");
                }
            }
        }
    }
}