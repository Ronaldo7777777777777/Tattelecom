using Tattelecom.DatabaseContext;

namespace Tattelecom;

public partial class App : Application
{
    public App(ApplicationDbContext dbContext)
    {
        InitializeComponent();

        MainPage = new AppShell();
    }
}

