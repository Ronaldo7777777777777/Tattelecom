using Tattelecom;
using Tattelecom.DatabaseContext;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder.UseMauiApp<App>().ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        // Регистрируем сервисы
        builder.Services.AddDbContext<ApplicationDbContext>();
        builder.Services.AddTransient<LoginPage>(); // вход страницы логина
        builder.Services.AddTransient<RegistrationPage>(); // Регистрация страницы логина
        builder.Services.AddTransient<LoginPageSotrudnik>(); // вход сотрудника
        builder.Services.AddTransient<CreateTicketPage>(); // вход логина

        return builder.Build();
    }
}