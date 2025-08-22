using Amethyst925.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Amethyst925.Data;

public class AppDbContext : DbContext
{
    #region Catálogos
    public DbSet<Branch> Branches { get; set; }
    public DbSet<MetalType> MetalTypes { get; set; }
    public DbSet<JewelryType> JewelryTypes { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Jewelry> Jewelries { get; set; }
    public DbSet<MovementType> MovementTypes { get; set; }
    #endregion

    #region Procesos
    public DbSet<Price> Prices { get; set; }
    public DbSet<Promotion> Promotions { get; set; }
    public DbSet<InventoryMovement> InventoryMovements { get; set; }
    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<InvoiceDetail> InvoiceDetails { get; set; }
    #endregion

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region Catálogos
        modelBuilder.Entity<Branch>().ToTable("Branch");
        modelBuilder.Entity<MetalType>().ToTable("MetalType");
        modelBuilder.Entity<JewelryType>().ToTable("JewelryType");
        modelBuilder.Entity<Customer>().ToTable("Customer");
        modelBuilder.Entity<Jewelry>().ToTable("Jewelry");
        modelBuilder.Entity<MovementType>().ToTable("MovementType");
        #endregion

        #region Procesos
        modelBuilder.Entity<Price>().ToTable("Price");
        modelBuilder.Entity<Promotion>().ToTable("Promotion");
        modelBuilder.Entity<InventoryMovement>().ToTable("InventoryMovement");
        modelBuilder.Entity<Invoice>().ToTable("Invoice");
        modelBuilder.Entity<InvoiceDetail>().ToTable("InvoiceDetail");
        #endregion

        #region Índices Adicionales
        modelBuilder.Entity<Invoice>()
            .HasIndex(i => i.InternalInvoiceId, "IDX_InternalInvoiceId");
        #endregion

        #region Configuración de decimales
        modelBuilder.Entity<Jewelry>()
            .Property(j => j.Weight)
            .HasPrecision(18, 2);

        modelBuilder.Entity<Jewelry>()
            .Property(j => j.Cost)
            .HasPrecision(18, 2);

        modelBuilder.Entity<Price>()
            .Property(p => p.Amount)
            .HasPrecision(18, 2);

        modelBuilder.Entity<Promotion>()
            .Property(p => p.DiscountPercentage)
            .HasPrecision(5, 2);

        modelBuilder.Entity<Invoice>()
            .Property(i => i.Subtotal)
            .HasPrecision(18, 2);

        modelBuilder.Entity<Invoice>()
            .Property(i => i.Tax)
            .HasPrecision(18, 2);

        modelBuilder.Entity<Invoice>()
            .Property(i => i.Total)
            .HasPrecision(18, 2);

        modelBuilder.Entity<InvoiceDetail>()
            .Property(d => d.UnitPrice)
            .HasPrecision(18, 2);

        modelBuilder.Entity<InvoiceDetail>()
            .Property(d => d.Discount)
            .HasPrecision(18, 2);

        modelBuilder.Entity<InvoiceDetail>()
            .Property(d => d.Total)
            .HasPrecision(18, 2);
        #endregion

        #region Configuración de relaciones y restricciones
        modelBuilder.Entity<InventoryMovement>()
            .HasOne(im => im.Jewelry)
            .WithMany()
            .OnDelete(DeleteBehavior.Restrict);
        #endregion

        #region Datos iniciales
        modelBuilder.Entity<Branch>().HasData(
            new Branch { Id = 1, Name = "Tacachico", Address = "5 Av. Sur, Plaza Villa Nueva, Local 7" });

        modelBuilder.Entity<MovementType>().HasData(
            new MovementType { Id = "E", Name = "Entrada", Description = "Entrada de inventario", InventorySing = '+' },
            new MovementType { Id = "S", Name = "Salida", Description = "Salida de inventario", InventorySing = '-' },
            new MovementType { Id = "V", Name = "Venta", Description = "Venta a cliente", InventorySing = '-' },
            new MovementType { Id = "D", Name = "Donación", Description = "Donación o pérdida", InventorySing = '-' },
            new MovementType { Id = "AP", Name = "Ajuste Positivo", Description = "Ajuste de inventario a favor", InventorySing = '+' },
            new MovementType { Id = "AN", Name = "Ajuste Negativo", Description = "Ajuste de inventario en contra", InventorySing = '-' }
        );
        #endregion

        base.OnModelCreating(modelBuilder);
    }
}
