using System.ComponentModel.DataAnnotations;

namespace Amethyst925.Core.Entities;

/// <summary>
/// Tipo de Movimiento
/// </summary>
public class MovementType
{
    /// <summary>
    /// Código del Tipo de Movimiento
    /// </summary>
    [MaxLength(2)]
    public string Id { get; set; }

    /// <summary>
    /// Nombre del Tipo de Movimiento
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Descripción del Tipo de Movimiento
    /// </summary>
    [MaxLength(250)]
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Signo del Movimiento de Inventario
    /// </summary>
    [MaxLength(1)]
    public string InventorySing { get; set; } // + suma, - resta, =  nada
}
