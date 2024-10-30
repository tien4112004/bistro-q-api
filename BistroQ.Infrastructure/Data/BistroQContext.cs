using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using BistroQ.Core.Entities;
using BistroQ.Core.Enums;
using BistroQ.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace BistroQ.Infrastructure.Data;

public partial class BistroQContext : IdentityDbContext<AppUser>
{
    public BistroQContext()
    {
    }

    public BistroQContext(DbContextOptions<BistroQContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<NutritionFact> NutritionFacts { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Table> Tables { get; set; }

    public virtual DbSet<Zone> Zones { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            var tableName = entityType.GetTableName();
            if (tableName.StartsWith("AspNet"))
            {
                entityType.SetTableName(tableName.Substring(6));
            }
        }
        
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PRIMARY");

            entity.ToTable("Category");

            entity.Property(e => e.CategoryId).ValueGeneratedOnAdd();
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<NutritionFact>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PRIMARY");

            entity.ToTable("NutritionFact");

            entity.Property(e => e.ProductId).ValueGeneratedNever();

            entity.HasOne(d => d.Product).WithOne(p => p.NutritionFact)
                .HasForeignKey<NutritionFact>(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("NutritionFact_ibfk_1");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PRIMARY");

            entity.ToTable("Order");

            entity.HasIndex(e => e.TableId, "TableId");
    
            entity.Property(e => e.OrderId).HasMaxLength(100);
            entity.Property(e => e.EndTime).HasColumnType("datetime");
            entity.Property(e => e.StartTime).HasColumnType("datetime");
            entity.Property(e => e.TotalAmount).HasPrecision(10);

            entity.HasOne(d => d.Table).WithMany(p => p.Orders)
                .HasForeignKey(d => d.TableId)
                .HasConstraintName("Order_ibfk_1")
                .OnDelete(DeleteBehavior.SetNull);
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.OrderDetailId).HasName("PRIMARY");

            entity.ToTable("OrderDetail");

            entity.HasIndex(e => e.OrderId, "OrderId");

            entity.HasIndex(e => e.ProductId, "ProductId");

            entity.Property(e => e.OrderDetailId).HasMaxLength(100);
            entity.Property(e => e.OrderId).HasMaxLength(100);
            entity.Property(e => e.PriceAtPurchase).HasPrecision(10);

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("OrderDetail_ibfk_1")
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(d => d.Product).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("OrderDetail_ibfk_2")
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PRIMARY");
            
            entity.ToTable("Product");

            entity.HasIndex(e => e.CategoryId, "CategoryId");

            entity.Property(e => e.ProductId).ValueGeneratedOnAdd();
            entity.Property(e => e.DiscountPrice).HasPrecision(10);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Price).HasPrecision(10);
            entity.Property(e => e.Unit).HasMaxLength(100);

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("Product_ibfk_1")
                .OnDelete(DeleteBehavior.SetNull);
        });

        modelBuilder.Entity<Table>(entity =>
        {
            entity.HasKey(e => e.TableId).HasName("PRIMARY");

            entity.ToTable("Table");

            entity.HasIndex(e => e.ZoneId, "ZoneId");

            entity.Property(e => e.TableId).ValueGeneratedOnAdd();

            entity.HasOne(d => d.Zone).WithMany(p => p.Tables)
                .HasForeignKey(d => d.ZoneId)
                .HasConstraintName("Table_ibfk_1")
                .OnDelete(DeleteBehavior.SetNull);
        });

        modelBuilder.Entity<Zone>(entity =>
        {
            entity.HasKey(e => e.ZoneId).HasName("PRIMARY");

            entity.ToTable("Zone");

            entity.Property(e => e.ZoneId).ValueGeneratedOnAdd();
            entity.Property(e => e.Name).HasMaxLength(100);
        });
        
        var listRoles = new List<IdentityRole>()
        {
            new IdentityRole { Id = "1", Name = BistroRoles.Admin, NormalizedName = BistroRoles.Admin.ToUpper() },
            new IdentityRole { Id = "2", Name = BistroRoles.Kitchen, NormalizedName = BistroRoles.Kitchen.ToUpper() },
            new IdentityRole { Id = "3", Name = BistroRoles.Cashier, NormalizedName = BistroRoles.Cashier.ToUpper() }
        };
        
        modelBuilder.Entity<IdentityRole>().HasData(listRoles);
        
        var hasher = new PasswordHasher<AppUser>();
        modelBuilder.Entity<AppUser>().HasData(new AppUser
            {
                Id = "1",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                PasswordHash = hasher.HashPassword(null, "admin"),
            },
            new AppUser
            {
                Id = "2",
                UserName = "kitchen",
                NormalizedUserName = "KITCHEN",
                Email = "kitchen@gmail.com",
                NormalizedEmail = "KITCHEN@GMAIL.COM",
                PasswordHash = hasher.HashPassword(null, "kitchen"),
            },
            new AppUser
            {
                Id = "3",
                UserName = "cashier",
                NormalizedUserName = "CASHIER",
                Email = "cashier@gmail.com",
                NormalizedEmail = "CASHIER@GMAIL.COM",
                PasswordHash = hasher.HashPassword(null, "cashier"),
            });

        modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "1",
                UserId = "1"
            },
            new IdentityUserRole<string>
            {
                RoleId = "2",
                UserId = "2"
            },
            new IdentityUserRole<string>
            {
                RoleId = "3",
                UserId = "3",
            });
        

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}