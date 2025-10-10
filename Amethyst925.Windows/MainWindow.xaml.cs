using Amethyst925.Data;
using Amethyst925.Windows.Enums;
using Amethyst925.Windows.Structures;
using Amethyst925.Windows.Utils;
using Amethyst925.Windows.ViewModels;
using Amethyst925.Windows.Views;
using MaterialDesignThemes.Wpf;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

namespace Amethyst925.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AppDbContext _dbContext;
        private readonly PaletteHelper paletteHelper = new();

        public MainWindow()
        {
            InitializeComponent();

            Title = $"{Application.Current.Resources["strMainMenu"]} :: {Application.Current.Resources["strCompanyName"]} :: v.{MyConstants.APP_VERSION}";
            LblUserApp.Content = $"{App.Current.Properties[AppParameter.USERNAME_PIN]} | {App.Current.Properties[AppParameter.USER_PROFILENAME]}";

            // Carga Accesos Directos
            MenuItemsListBox.ItemsSource = LocalData.GetMenuItems();

            // Contexto
            if (_dbContext is null)
                _dbContext = new();
        }

        /// <summary>
        /// Cerrar Aplicación
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCloseApp_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult resp = MessageBox.Show("¿Desea apagar el equipo?", MyConstants.TXT_QUESTION, MessageBoxButton.YesNoCancel);

            switch (resp)
            {
                case MessageBoxResult.Yes:
                    {
                        // Apagar PC
                        Process.Start("shutdown", "/s /f /t 0");
                        break;
                    }
                case MessageBoxResult.No:
                    {
                        // Solo salir de Aplicación
                        CheckMenuOption(MenuItemEnum.EXIT_APPLICATION);
                        break;
                    }
                default:
                    break;
            }
        }

        /// <summary>
        ///  Valida opción de Menú a Ejecutar
        /// </summary>
        /// <param name="menuItem"></param>
        private void CheckMenuOption(MenuItemEnum menuItem)
        {
            switch (menuItem)
            {
                case MenuItemEnum.EXIT_APPLICATION:
                    {
                        // Cerrar Aplicación
                        Application.Current.Shutdown();
                        break;
                    }
                //case MenuItemEnum.PARAMETERS:
                //    {
                //        // Pantalla de Parametrización
                //        using (ParameterWindow w = new())
                //        {
                //            w.Owner = this;
                //            w.ShowDialog();
                //        }

                //        break;
                //    }
                //case MenuItemEnum.FLOOR_PRODUCTION:
                //    {
                //        // Orden de Producción

                //        bool useOrderProduction = App.Current.Properties[AppParameter.APP_USAR_ORDEN]!.ToString()! == ((int)AnswerEnum.Si).ToString().Trim();
                //        OrderType orderType = useOrderProduction ? OrderType.Production : OrderType.ManualProduction;

                //        using (FloorProductionWindow w = new(_dbContext, orderType))
                //        {
                //            w.Owner = this;
                //            w.ShowDialog();
                //        }

                //        break;
                //    }
                case MenuItemEnum.BRANCHES:
                    {
                        // Sucursales
                        using (BranchView w = new())
                        {
                            w.Owner = this;
                            w.ShowDialog();
                        }

                        break;
                    }
                //case MenuItemEnum.DRIVER:
                //    {
                //        // Pantalla de Parametrización
                //        using (DriverWindow w = new(_dbContext))
                //        {
                //            w.Owner = this;
                //            w.ShowDialog();
                //        }

                //        break;
                //    }
                //case MenuItemEnum.PICKING:
                //    {
                //        // Pantalla de Parametrización
                //        using (FloorProductionWindow w = new(_dbContext, OrderType.Picking))
                //        {
                //            w.Owner = this;
                //            w.ShowDialog();
                //        }

                //        break;
                //    }
                default:
                    break;
            }
        }

        /// <summary>
        /// Acceso a opción de Parámetros
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnParameters_Click(object sender, RoutedEventArgs e)
        {
            CheckMenuOption(MenuItemEnum.PARAMETERS);
        }

        #region Events
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            Application.Current.Shutdown();
        }
        #endregion

        private void TglTheme_Click(object sender, RoutedEventArgs e)
        {
            LocalLibrary.ModifyTheme(TglTheme.IsChecked == true);
        }

        /// <summary>
        /// Apertura de PopupBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnOpenPopupBox(object sender, RoutedEventArgs e)
        {
            var theme = paletteHelper.GetTheme();

            if ((bool)(TglTheme.IsChecked = theme.GetBaseTheme() == BaseTheme.Dark))
            {
                TglTheme.IsChecked = true;
            }
            else
            {
                TglTheme.IsChecked = false;
            }
        }

        private void MenuToggleButton_OnClick(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItemsListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            // Cierra el Menú
            MenuToggleButton.IsChecked = false;

            ListBoxItem? lbi = (sender as ListBox)!.SelectedItem as ListBoxItem;
            MenuItemViewModel? mi = (MenuItemViewModel)MenuItemsListBox.SelectedItem;

            if (lbi is null && mi is null)
                return;

            // Verifica la Opción a Ejecutar
            CheckMenuOption((MenuItemEnum)mi.MenuItemId!);

            // Desmarcar última opción seleccionada
            MenuItemsListBox.SelectedItem = null;
        }

        private void UIElement_OnPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var dependencyObject = Mouse.Captured as DependencyObject;

            while (dependencyObject != null)
            {
                if (dependencyObject is ScrollBar) return;
                dependencyObject = VisualTreeHelper.GetParent(dependencyObject);
            }

            MenuToggleButton.IsChecked = false;
        }

        /// <summary>
        /// Opción Catálogos-Sucursales
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BranchMenuItem_Click(object sender, RoutedEventArgs e) => CheckMenuOption(MenuItemEnum.BRANCHES);
    }
}