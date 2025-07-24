namespace Amethyst925.Core.Entities;

using System;
using System.ComponentModel.DataAnnotations.Schema;

public class Price
{
    /// <summary>
    /// Código de Precio
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Código de Joya
    /// </summary>
    public string JewelryId { get; set; } = string.Empty;

    /// <summary>
    /// Monto
    /// </summary>
    [Column(TypeName = "decimal(18,2)")]
    public decimal Amount { get; set; } // con 2 decimales

    /// <summary>
    /// Fecha Efectiva del Precio
    /// </summary>
    public DateTime EffectiveDate { get; set; }

    /// <summary>
    /// Fecha Expiración
    /// </summary>
    public DateTime? ExpirationDate { get; set; }


    // Foreign Key's
    [ForeignKey(nameof(JewelryId))]
    public virtual Jewelry Jewelry { get; set; }
}
