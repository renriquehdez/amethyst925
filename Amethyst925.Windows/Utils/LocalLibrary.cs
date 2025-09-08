using MaterialDesignThemes.Wpf;

namespace Amethyst925.Windows.Utils;

public static class LocalLibrary
{
    /// <summary>
    /// Modificar Tema de Aplicación
    /// </summary>
    /// <param name="isDarkTheme"></param>
    public static void ModifyTheme(bool isDarkTheme)
    {
        var paletteHelper = new PaletteHelper();
        var theme = paletteHelper.GetTheme();

        theme.SetBaseTheme(isDarkTheme ? BaseTheme.Dark : BaseTheme.Light);
        paletteHelper.SetTheme(theme);
    }
}
