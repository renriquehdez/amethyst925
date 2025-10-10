using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Amethyst925.Core.Entities;

/// <summary>
/// Encabezado de Factura
/// </summary>
public class Invoice
{
    /// <summary>
    /// Código de Factura
    /// </summary>
    [Key]
    public Guid Id { get; set; }

    /// <summary>
    /// Número Interno de Factura
    /// </summary>
    public string InternalInvoiceId { get; set; }

    /// <summary>
    /// Código de Cliente
    /// </summary>
    [MaxLength(50)]
    public string CustomerId { get; set; } = string.Empty;

    /// <summary>
    /// Código de Sucursal
    /// </summary>
    public int BranchId { get; set; }

    /// <summary>
    /// Fecha Factura
    /// </summary>
    public DateTime InvoiceDate { get; set; }

    /// <summary>
    /// Subtotal
    /// </summary>
    [Column(TypeName = "decimal(18,2)")]
    public decimal Subtotal { get; set; } // con 2 decimales

    /// <summary>
    /// Impuesto
    /// </summary>
    [Column(TypeName = "decimal(18,2)")]
    public decimal Tax { get; set; } // con 2 decimales

    /// <summary>
    /// Total
    /// </summary>
    [Column(TypeName = "decimal(18,2)")]
    public decimal Total { get; set; } // con 2 decimales

    /// <summary>
    /// Creado por
    /// </summary>
    public string CreatedBy { get; set; } = string.Empty;

    // Foreign Key's
    [ForeignKey(nameof(CustomerId))]
    public virtual Customer Customer { get; set; }

    [ForeignKey(nameof(BranchId))]
    public virtual Branch Branch { get; set; }

    // Other Objects
    public virtual ICollection<InvoiceDetail> Details { get; set; }
}
