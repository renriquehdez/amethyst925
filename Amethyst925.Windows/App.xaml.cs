namespace Amethyst925.Windows;

using Amethyst925.Data;
using Amethyst925.Services;
using Amethyst925.Windows.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public IServiceProvider ServiceProvider { get; private set; }

    public App()
    {
        var services = new ServiceCollection();
        ConfigureServices(services);
        ServiceProvider = services.BuildServiceProvider();
    }

    private void ConfigureServices(IServiceCollection services)
    {
        string conn = $"Data Source=LS2C-5CD2011ZY4\\SQLEXPRESS22;"
            + $"Initial Catalog=Amethyst925;"
            + $"User Id=sa;"
            + $"Password=fb9tbu%3StLFRJ;"
            + "MultipleActiveResultSets=true;TrustServerCertificate=True;ConnectRetryCount=0;Connection Timeout=120";

        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(conn));

        services.AddScoped<IBranchService, BranchService>();

        services.AddSingleton<MainWindow>();
        services.AddTransient<BranchView>();    // Registrar BranchView como servicio transitorio
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        // Asegurar que la base de datos esté creada
        //using var scope = ServiceProvider.CreateScope();
        //var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        //dbContext.Database.EnsureCreated();
        // Migración de la BD
        using (var scope = ServiceProvider.CreateScope())
        using (var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>())
        {
            dbContext.Database.Migrate();
            dbContext.Database.EnsureCreated();
        }

        // Mostrar la ventana principal
        var mainWindow = ServiceProvider.GetRequiredService<BranchView>();
        mainWindow.Show();
    }
}
