using Amethyst925.Windows.Enums;
using Amethyst925.Windows.ViewModels;

namespace Amethyst925.Windows.Utils;

public static class LocalData
{
    /// <summary>
    /// Opciones del Menú Principal
    /// </summary>
    /// <returns></returns>
    public static List<MenuItemViewModel> GetMenuItems()
    {
        List<MenuItemViewModel> menuItems = new()
        {
            new MenuItemViewModel() {Title = "Sucursales", MenuItemId=MenuItemEnum.BRANCHES},
            new MenuItemViewModel() {Title = "Parámetros", MenuItemId = MenuItemEnum.PARAMETERS},
            new MenuItemViewModel() {Title = "Salir", MenuItemId = MenuItemEnum.EXIT_APPLICATION},
        };

        return menuItems;
    }
}
