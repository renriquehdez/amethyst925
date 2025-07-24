namespace Amethyst925.Core.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/// <summary>
/// Tipo de Metal
/// </summary>
public class MetalType
{
    /// <summary>
    /// Código del Tipo de Metal
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id { get; set; }

    /// <summary>
    /// Nombre del Tipo de Metal
    /// </summary>
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Descripción del Tipo de Metal
    /// </summary>
    [MaxLength(250)]
    public string Description { get; set; } = string.Empty;
}
