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
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Amethyst;Trusted_Connection=True;"));

        services.AddScoped<IBranchService, BranchService>();

        services.AddTransient<BranchView>(); // Registrar BranchView como servicio transitorio
        services.AddSingleton<MainWindow>();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        // Asegurar que la base de datos esté creada
        using var scope = ServiceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        dbContext.Database.EnsureCreated();

        // Mostrar la ventana de sucursales (puedes cambiarlo a MainWindow si prefieres)
        var branchView = ServiceProvider.GetRequiredService<BranchView>();
        branchView.Show();
    }
}
