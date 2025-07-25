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
    public char Id { get; set; } // 'E' Entrada, 'S' Salida, etc.

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
    public bool InventorySing { get; set; } // + suma, - resta, =  nada
}
