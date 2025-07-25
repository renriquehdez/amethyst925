using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Amethyst925.Core.Entities;

/// <summary>
/// Promoción
/// </summary>
public class Promotion
{
    /// <summary>
    /// Código de Promoción
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    /// <summary>
    /// Nombre de Promoción
    /// </summary>
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Descripción de Promoción
    /// </summary>
    [MaxLength(250)]
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Porcentaje de Descuento
    /// </summary>
    public decimal DiscountPercentage { get; set; } // con 2 decimales

    /// <summary>
    /// Fecha Inicial del Descuento
    /// </summary>
    public DateTime StartDate { get; set; }

    /// <summary>
    /// Fecha Final del Descuento
    /// </summary>
    public DateTime EndDate { get; set; }

    /// <summary>
    /// Está Activa la Promoción
    /// </summary>
    public bool IsActive { get; set; }
}
