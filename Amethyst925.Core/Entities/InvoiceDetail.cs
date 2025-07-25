using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Amethyst925.Core.Entities;

/// <summary>
/// Detalle de Factura
/// </summary>
public class InvoiceDetail
{
    /// <summary>
    /// Código del Detalle de Factura
    /// </summary>
    [Key]
    public Guid Id { get; set; }

    /// <summary>
    /// Código de Factura
    /// </summary>
    public Guid InvoiceId { get; set; }

    /// <summary>
    /// Código de Joya
    /// </summary>
    [MaxLength(50)]
    public string JewelryId { get; set; } = string.Empty;

    /// <summary>
    /// Cantidad
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// Precio Unitario
    /// </summary>
    [Column(TypeName = "decimal(18,2)")]
    public decimal UnitPrice { get; set; } // con 2 decimales

    /// <summary>
    /// Descuento
    /// </summary>
    [Column(TypeName = "decimal(18,2)")]
    public decimal Discount { get; set; } // con 2 decimales

    /// <summary>
    /// Total
    /// </summary>
    [Column(TypeName = "decimal(18,2)")]
    public decimal Total { get; set; } // con 2 decimales

    // Foreign Key's
    [ForeignKey(nameof(InvoiceId))]
    public virtual Invoice Invoice { get; set; }

    [ForeignKey(nameof(JewelryId))]
    public virtual Jewelry Jewelry { get; set; }
}
