namespace Amethyst925.Core.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Branch
{
    /// <summary>
    /// Código Sucursal
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id { get; set; }

    /// <summary>
    /// Nombre de la Sucursal
    /// </summary>
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Dirección de la Sucursal
    /// </summary>
    [MaxLength(250)]
    public string Address { get; set; } = string.Empty;

    /// <summary>
    /// Teléfono de la Sucursal
    /// </summary>
    [MaxLength(50)]
    public string Phone { get; set; } = string.Empty;

    /// <summary>
    /// Correo Electrónico
    /// </summary>
    [MaxLength(50)]
    public string Email { get; set; } = string.Empty;
}
