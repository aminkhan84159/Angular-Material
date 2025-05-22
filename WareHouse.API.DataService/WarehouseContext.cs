using Microsoft.EntityFrameworkCore;

namespace Warehouse.API.DataService.Models;

public partial class WarehouseContext : DbContext
{
    public WarehouseContext()
    {
    }

    public WarehouseContext(DbContextOptions<WarehouseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductDetail> ProductDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DT002\\SQLEXPRESS;Database=Warehouse;Trusted_Connection=true;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK_Product_ProductId");

            entity.ToTable("Product");

            entity.HasIndex(e => e.Title, "UQ_Product_Title").IsUnique();

            entity.Property(e => e.Brand).HasMaxLength(100);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Category).HasMaxLength(100);
            entity.Property(e => e.ChangedOn).HasColumnType("datetime");
            entity.Property(e => e.CreatedBy).HasDefaultValue(1);
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Title).HasMaxLength(100);
        });

        modelBuilder.Entity<ProductDetail>(entity =>
        {
            entity.HasKey(e => e.ProductDetailId).HasName("PK_ProductDetail_ProductDetailId");

            entity.Property(e => e.ChangedOn).HasColumnType("datetime");
            entity.Property(e => e.CreatedBy).HasDefaultValue(1);
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Rating).HasColumnType("decimal(2, 1)");
            entity.Property(e => e.Warranty).HasMaxLength(100);
            entity.Property(e => e.Weight).HasColumnType("decimal(6, 2)");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_ProductDetail_ProductId__Product_ProductId");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
