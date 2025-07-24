using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Amethyst925.Core.Entities;

/// <summary>
/// Joyería
/// </summary>
public class Jewelry
{
    /// <summary>
    /// Código de Joya
    /// </summary>
    [Key]
    [MaxLength(50)]
    public string Id { get; set; }


    /// <summary>
    /// Nombre de Joya
    /// </summary>
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;


    /// <summary>
    /// Descripción de Joya
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Código Tipo de Metal
    /// </summary>
    public int MetalTypeId { get; set; }

    /// <summary>
    /// Código Tipo de Joyería
    /// </summary>
    public int JewelryTypeId { get; set; }

    /// <summary>
    /// Peso Aproximado de Joya
    /// </summary>
    /// 
    [Column(TypeName = "decimal(18,2)")]
    public decimal Weight { get; set; } // en gramos, con 2 decimales

    /// <summary>
    /// Costo de Joya
    /// </summary>
    /// 
    [Column(TypeName = "decimal(18,2)")]
    public decimal Cost { get; set; } // costo, con 2 decimales

    /// <summary>
    /// Cantidad en Inventario
    /// </summary>
    public int QuantityInStock { get; set; }


    // Foreign Key's
    [ForeignKey(nameof(MetalTypeId))]
    public virtual MetalType MetalType { get; set; }

    [ForeignKey(nameof(JewelryTypeId))]
    public virtual JewelryType JewelryType { get; set; }
}
