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

            entity.HasOne(d => d.Table)
                .WithOne(t => t.Order)
                .HasForeignKey<Order>(d => d.TableId)
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
            
            entity.HasOne(d => d.User)
                .WithOne(p => p.Table)
                .HasForeignKey<AppUser>(d => d.TableId)
                .HasConstraintName("Table_ibfk_2")
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
            new IdentityRole { Id = "3", Name = BistroRoles.Cashier, NormalizedName = BistroRoles.Cashier.ToUpper() },
            new IdentityRole { Id = "4", Name = BistroRoles.Client, NormalizedName = BistroRoles.Client.ToUpper() }
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
            },
            new AppUser
            {
                Id = "4",
                UserName = "client1",
                NormalizedUserName = "CLIENT1",
                Email = "client1@gmail.com",
                NormalizedEmail = "CLIENT1@GMAIL.COM",
                PasswordHash = hasher.HashPassword(null, "client"),
                TableId = 1
            },
            new AppUser
            {
                Id = "5",
                UserName = "client2",
                NormalizedUserName = "CLIENT2",
                Email = "client2@gmail.com",
                NormalizedEmail = "CLIENT2@GMAIL.COM",
                PasswordHash = hasher.HashPassword(null, "client"),
                TableId = 2
            },
            new AppUser
            {
                Id = "6",
                UserName = "client3",
                NormalizedUserName = "CLIENT3",
                Email = "client3@gmail.com",
                NormalizedEmail = "CLIENT3@GMAIL.COM",
                PasswordHash = hasher.HashPassword(null, "client"),
                TableId = 3
            },
            new AppUser
            {
                Id = "7",
                UserName = "client4",
                NormalizedUserName = "CLIENT4",
                Email = "client4@gmail.com",
                NormalizedEmail = "CLIENT4@GMAIL.COM",
                PasswordHash = hasher.HashPassword(null, "client"),
                TableId = 4
            },
            new AppUser
            {
                Id = "8",
                UserName = "client5",
                NormalizedUserName = "CLIENT5",
                Email = "client5@gmail.com",
                NormalizedEmail = "CLIENT5@GMAIL.COM",
                PasswordHash = hasher.HashPassword(null, "client"),
                TableId = 5
            },
            new AppUser
            {
                Id = "9",
                UserName = "client6",
                NormalizedUserName = "CLIENT6",
                Email = "client6@gmail.com",
                NormalizedEmail = "CLIENT6@GMAIL.COM",
                PasswordHash = hasher.HashPassword(null, "client"),
                TableId = 6
            },
            new AppUser
            {
                Id = "10",
                UserName = "client7",
                NormalizedUserName = "CLIENT7",
                Email = "client7@gmail.com",
                NormalizedEmail = "CLIENT7@GMAIL.COM",
                PasswordHash = hasher.HashPassword(null, "client"),
                TableId = 7
            },
            new AppUser
            {
                Id = "11",
                UserName = "client8",
                NormalizedUserName = "CLIENT8",
                Email = "client8@gmail.com",
                NormalizedEmail = "CLIENT8@GMAIL.COM",
                PasswordHash = hasher.HashPassword(null, "client"),
                TableId = 8
            },
            new AppUser
            {
                Id = "12",
                UserName = "client9",
                NormalizedUserName = "CLIENT9",
                Email = "client9@gmail.com",
                NormalizedEmail = "CLIENT9@GMAIL.COM",
                PasswordHash = hasher.HashPassword(null, "client"),
                TableId = 9
            },
            new AppUser
            {
                Id = "13",
                UserName = "client10",
                NormalizedUserName = "CLIENT10",
                Email = "client10@gmail.com",
                NormalizedEmail = "CLIENT10@GMAIL.COM",
                PasswordHash = hasher.HashPassword(null, "client"),
                TableId = 10
            }
        );

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
            },
            new IdentityUserRole<string>
            {
                RoleId = "4",
                UserId = "4",
            }
            );

        var listZone = new List<Zone>()
        {
            new Zone { ZoneId = 1, Name = "Inside" },
            new Zone { ZoneId = 2, Name = "Backyard" },
            new Zone { ZoneId = 3, Name = "Outside" },
            new Zone { ZoneId = 4, Name = "VIP" }
        };
        
        modelBuilder.Entity<Zone>().HasData(listZone);

        var listTable = new List<Table>()
        {
            new Table { TableId = 1, ZoneId = 1, Number = 1, SeatsCount = 4 },
            new Table { TableId = 2, ZoneId = 1, Number = 2, SeatsCount = 4 },
            new Table { TableId = 3, ZoneId = 1, Number = 3, SeatsCount = 8 },
            new Table { TableId = 4, ZoneId = 1, Number = 4, SeatsCount = 6 },
            new Table { TableId = 5, ZoneId = 2, Number = 1, SeatsCount = 2 },
            new Table { TableId = 6, ZoneId = 2, Number = 2, SeatsCount = 2 },
            new Table { TableId = 7, ZoneId = 2, Number = 3, SeatsCount = 3 },
            new Table { TableId = 8, ZoneId = 2, Number = 4, SeatsCount = 3 },
            new Table { TableId = 9, ZoneId = 3, Number = 1, SeatsCount = 3 },
            new Table { TableId = 10, ZoneId = 3, Number = 2, SeatsCount = 2 },
        };
        
        modelBuilder.Entity<Table>().HasData(listTable);

        var listOrder = new List<Order>()
        {
            new Order
            {
                OrderId = "1", TableId = null, StartTime = new DateTime(2024, 10, 1, 12, 0, 0),
                EndTime = new DateTime(2024, 10, 1, 13, 0, 0),
                TotalAmount = 100
            },
            new Order
            {
                OrderId = "2", TableId = null, StartTime = new DateTime(2024, 10, 1, 12, 0, 0),
                EndTime = new DateTime(2024, 10, 1, 13, 0, 0),
                TotalAmount = 200
            },
            new Order
            {
                OrderId = "3", TableId = null, StartTime = new DateTime(2024, 10, 1, 12, 0, 0),
                EndTime = new DateTime(2024, 10, 1, 13, 0, 0),
                TotalAmount = 300
            },
            new Order
            {
                OrderId = "4", TableId = null, StartTime = new DateTime(2024, 10, 1, 12, 0, 0),
                EndTime = new DateTime(2024, 10, 1, 13, 0, 0),
                TotalAmount = 400
            },
            new Order
            {
                OrderId = "5", TableId = 1, StartTime = DateTime.Now, EndTime = null,
                TotalAmount = 500
            },
            new Order
            {
                OrderId = "6", TableId = 2, StartTime = DateTime.Now, EndTime = null,
                TotalAmount = 600
            },
        };
        
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}