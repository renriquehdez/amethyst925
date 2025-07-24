namespace Amethyst925.Core.Entities;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// Cliente
/// </summary>
public class Customer
{
    /// <summary>
    /// Código de Cliente
    /// </summary>
    [Key]
    [MaxLength(50)]
    public string Id { get; set; } = string.Empty; // RFC o identificador único

    /// <summary>
    /// Nombre del Cliente
    /// </summary>
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Dirección del Cliente
    /// </summary>
    [MaxLength(250)]
    public string Address { get; set; } = string.Empty;

    /// <summary>
    /// Teléfono del Cliente
    /// </summary>
    [MaxLength(20)]
    public string Phone { get; set; } = string.Empty;

    /// <summary>
    /// Çorreo Electrónico del Cliente
    /// </summary>
    [EmailAddress]
    [MaxLength(100)]
    public string Email { get; set; } = string.Empty;
}
