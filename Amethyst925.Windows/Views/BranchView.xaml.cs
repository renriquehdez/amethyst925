using Amethyst925.Services;
using Amethyst925.Windows.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace Amethyst925.Windows.Views
{
    /// <summary>
<<<<<<< HEAD
    /// Interaction logic for BranchView.xaml
    /// </summary>
    public partial class BranchView : Window
=======
    /// Interaction logic for BranchViewxaml.xaml
    /// </summary>
    public partial class BranchView : Window, IDisposable
>>>>>>> 80c13e6a1ef980734bc9c8aa23c4a695e7f6a197
    {
        public BranchView()
        {
            InitializeComponent();

<<<<<<< HEAD
            DataContext = new BranchViewModel(
                ((App)Application.Current).ServiceProvider.GetRequiredService<IBranchService>());
        }
=======
            // Obtener el ViewModel a través del contenedor de dependencias
            var branchService = ((App)Application.Current).ServiceProvider.GetRequiredService<IBranchService>();
            DataContext = new BranchViewModel(branchService);
        }

        public void Dispose() { }

        private void BtnClose_Click(object sender, RoutedEventArgs e) => Close();
>>>>>>> 80c13e6a1ef980734bc9c8aa23c4a695e7f6a197
    }
}
