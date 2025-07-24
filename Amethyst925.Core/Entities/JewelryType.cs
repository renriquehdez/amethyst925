namespace Amethyst925.Core.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/// <summary>
/// Tipo de Joyería
/// </summary>
public class JewelryType
{
    /// <summary>
    /// Código del Tipo de Joyería
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id { get; set; }


    /// <summary>
    /// Nombre del Tipo de Joyería
    /// </summary>
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Descripción del Tipo de Joyería
    /// </summary>
    [MaxLength(250)]
    public string Description { get; set; } = string.Empty;
}
