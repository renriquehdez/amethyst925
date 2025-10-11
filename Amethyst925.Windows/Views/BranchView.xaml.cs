using Amethyst925.Services;
using Amethyst925.Windows.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace Amethyst925.Windows.Views
{
    /// <summary>
    /// Interaction logic for BranchViewxaml.xaml
    /// </summary>
    public partial class BranchView : Window, IDisposable
    {
        public BranchView()
        {
            InitializeComponent();

            // Obtener el ViewModel a través del contenedor de dependencias
            var branchService = ((App)Application.Current).ServiceProvider.GetRequiredService<IBranchService>();

            Title = "Administración de Sucursales";
            DataContext = new BranchViewModel(branchService);
        }

        public void Dispose() { }

        private void BtnClose_Click(object sender, RoutedEventArgs e) => Close();
    }
}
