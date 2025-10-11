using Amethyst925.Services;
using Amethyst925.Windows.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace Amethyst925.Windows.Views
{
    /// <summary>
    /// Interaction logic for BranchView.xaml
    /// </summary>
    public partial class BranchView : Window
    {
        public BranchView()
        {
            InitializeComponent();

            DataContext = new BranchViewModel(
                ((App)Application.Current).ServiceProvider.GetRequiredService<IBranchService>());
        }
    }
}
