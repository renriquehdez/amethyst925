using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Amethyst925.Core.Entities;

/// <summary>
/// Movimiento de Inventario
/// </summary>
public class InventoryMovement
{
    /// <summary>
    /// Código del Movimiento de Inventario
    /// </summary>
    [Key]
    public Guid Id { get; set; }

    /// <summary>
    /// Código del Tipo de Movimiento
    /// </summary>
    [MaxLength(2)]
    public string MovementTypeId { get; set; }

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
    /// Fecha del Movimiento
    /// </summary>
    public DateTime MovementDate { get; set; }

    /// <summary>
    /// Notas del Movimiento
    /// </summary>
    public string Notes { get; set; } = string.Empty;

    /// <summary>
    /// Código de Sucursal
    /// </summary>
    public int BranchId { get; set; }

    public string CreatedBy { get; set; } = string.Empty;

    // Foreign Key's
    [ForeignKey(nameof(MovementTypeId))]
    public virtual MovementType MovementType { get; set; }

    [ForeignKey(nameof(JewelryId))]
    public virtual Jewelry Jewelry { get; set; }

    [ForeignKey(nameof(BranchId))]
    public virtual Branch Branch { get; set; }
}
