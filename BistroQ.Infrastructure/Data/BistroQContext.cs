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

    public virtual DbSet<Order?> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

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

            entity.Property(e => e.OrderId).ValueGeneratedOnAdd();

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

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => e.OrderItemId).HasName("PRIMARY");

            entity.Property(e => e.OrderItemId).ValueGeneratedOnAdd();

            entity.ToTable("OrderItem");

            entity.HasIndex(e => e.OrderId, "OrderId");

            entity.HasIndex(e => e.ProductId, "ProductId");

            entity.Property(e => e.OrderItemId).HasMaxLength(100);
            entity.Property(e => e.OrderId).HasMaxLength(100);
            entity.Property(e => e.PriceAtPurchase).HasPrecision(10);

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("OrderItem_ibfk_1")
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(d => d.Product).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("OrderItem_ibfk_2")
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

            entity.HasOne(d => d.Image)
                .WithOne(p => p.Product)
                .HasForeignKey<Product>(d => d.ImageId)
                .HasConstraintName("Product_ibfk_2")
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

        modelBuilder.Entity<Image>(entity =>
        {
            entity.HasKey(e => e.ImageId).HasName("PRIMARY");

            entity.ToTable("Image");

            entity.Property(e => e.ImageId).ValueGeneratedOnAdd();
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
            },
            new IdentityUserRole<string>
            {
                RoleId = "4",
                UserId = "5",
            },
            new IdentityUserRole<string>
            {
                RoleId = "4",
                UserId = "6",
            },
            new IdentityUserRole<string>
            {
                RoleId = "4",
                UserId = "7",
            },
            new IdentityUserRole<string>
            {
                RoleId = "4",
                UserId = "8",
            },
            new IdentityUserRole<string>
            {
                RoleId = "4",
                UserId = "9",
            },
            new IdentityUserRole<string>
            {
                RoleId = "4",
                UserId = "10",
            },
            new IdentityUserRole<string>
            {
                RoleId = "4",
                UserId = "11",
            },
            new IdentityUserRole<string>
            {
                RoleId = "4",
                UserId = "12",
            },
            new IdentityUserRole<string>
            {
                RoleId = "4",
                UserId = "13",
            }
        );

        var listZone = new List<Zone>()
        {
            new Zone { ZoneId = 1, Name = "Inside" },
            new Zone { ZoneId = 2, Name = "Backyard" },
            new Zone { ZoneId = 3, Name = "Outside" },
            new Zone { ZoneId = 4, Name = "VIP" }
        };


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

        var listCategories = new Category[]
        {
            new Category
            {
                CategoryId = 1, Name = "Dry"
            },
            new Category
            {
                CategoryId = 2, Name = "Broth-based"
            },
        };

        var listProducts = new Product[]
        {
            new Product
            {
                ProductId = 1, Name = "Bun Bo Hue", Price = 50000, DiscountPrice = 0, Unit = "Bowl", CategoryId = 2,
                ImageId = Guid.Parse("00000000-0000-0000-0000-000000000001")
            },
            new Product
            {
                ProductId = 2, Name = "Pho", Price = 50000, DiscountPrice = 0, Unit = "Bowl", CategoryId = 2,
                ImageId = Guid.Parse("00000000-0000-0000-0000-000000000002")
            },
            new Product
            {
                ProductId = 3, Name = "Banh Mi", Price = 25000, DiscountPrice = 0, Unit = "Piece", CategoryId = 1,
                ImageId = Guid.Parse("00000000-0000-0000-0000-000000000003")
            },
            new Product
            {
                ProductId = 4, Name = "Banh Xeo", Price = 35000, DiscountPrice = 0, Unit = "Piece", CategoryId = 1,
                ImageId = Guid.Parse("00000000-0000-0000-0000-000000000004")
            },
            new Product
            {
                ProductId = 5, Name = "Banh Canh", Price = 40000, DiscountPrice = 0, Unit = "Bowl", CategoryId = 2,
                ImageId = Guid.Parse("00000000-0000-0000-0000-000000000005")
            },
            new Product
            {
                ProductId = 6, Name = "Banh Cuon", Price = 30000, DiscountPrice = 0, Unit = "Plate", CategoryId = 1,
                ImageId = Guid.Parse("00000000-0000-0000-0000-000000000006")
            },
            new Product
            {
                ProductId = 7, Name = "Com Chien", Price = 25000, DiscountPrice = 0, Unit = "Plate", CategoryId = 1,
                ImageId = Guid.Parse("00000000-0000-0000-0000-000000000007")
            },
            new Product
            {
                ProductId = 8, Name = "Bun Rieu", Price = 45000, DiscountPrice = 0, Unit = "Bowl", CategoryId = 2,
                ImageId = Guid.Parse("00000000-0000-0000-0000-000000000008")
            },
            new Product
            {
                ProductId = 9, Name = "Bun Thit Nuong", Price = 40000, DiscountPrice = 0, Unit = "Bowl", CategoryId = 2,
                ImageId = Guid.Parse("00000000-0000-0000-0000-000000000009")
            },
            new Product
            {
                ProductId = 10, Name = "Mi Xao", Price = 45000, DiscountPrice = 0, Unit = "Plate", CategoryId = 1,
                ImageId = Guid.Parse("00000000-0000-0000-0000-000000000010")
            },
        };

        var listImages = new Image[]
        {
            new Image
            {
                ImageId = Guid.Parse("00000000-0000-0000-0000-000000000001"), ContentType = "image/jpeg",
                Name = "bun-bo-hue.jpg",
            },
            new Image
            {
                ImageId = Guid.Parse("00000000-0000-0000-0000-000000000002"), ContentType = "image/jpeg",
                Name = "pho.jpg",
            },
            new Image
            {
                ImageId = Guid.Parse("00000000-0000-0000-0000-000000000003"), ContentType = "image/jpeg",
                Name = "banh-mi.jpg",
            },
            new Image
            {
                ImageId = Guid.Parse("00000000-0000-0000-0000-000000000004"), ContentType = "image/jpeg",
                Name = "banh-xeo.jpg",
            },
            new Image
            {
                ImageId = Guid.Parse("00000000-0000-0000-0000-000000000005"), ContentType = "image/jpeg",
                Name = "banh-canh.jpg",
            },
            new Image
            {
                ImageId = Guid.Parse("00000000-0000-0000-0000-000000000006"), ContentType = "image/jpeg",
                Name = "banh-cuon.jpg",
            },
            new Image
            {
                ImageId = Guid.Parse("00000000-0000-0000-0000-000000000007"), ContentType = "image/jpeg",
                Name = "com-chien.jpg",
            },
            new Image
            {
                ImageId = Guid.Parse("00000000-0000-0000-0000-000000000008"), ContentType = "image/jpeg",
                Name = "bun-rieu.jpg",
            },
            new Image
            {
                ImageId = Guid.Parse("00000000-0000-0000-0000-000000000009"), ContentType = "image/jpeg",
                Name = "bun-thit-nuong.jpg",
            },
            new Image
            {
                ImageId = Guid.Parse("00000000-0000-0000-0000-000000000010"), ContentType = "image/jpeg",
                Name = "mi-xao.jpg",
            },
        };

        var listOrderDetail = new List<OrderItem>()
        {
            new OrderItem
            {
                OrderItemId = "101",
                OrderId = "1",
                ProductId = 1,
                Status = OrderItemStatus.InProgress,
                Quantity = 2,
                PriceAtPurchase = listProducts.First(p => p.ProductId == 1).Price,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            },
            new OrderItem
            {
                OrderItemId = "102",
                OrderId = "1",
                ProductId = 2,
                Status = OrderItemStatus.InProgress,
                Quantity = 1,
                PriceAtPurchase = listProducts.First(p => p.ProductId == 2).Price,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            },
            new OrderItem
            {
                OrderItemId = "103",
                OrderId = "1",
                ProductId = 3,
                Status = OrderItemStatus.InProgress,
                Quantity = 1,
                PriceAtPurchase = listProducts.First(p => p.ProductId == 3).Price,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            },
            new OrderItem
            {
                OrderItemId = "104",
                OrderId = "1",
                ProductId = 4,
                Status = OrderItemStatus.Pending,
                Quantity = 2,
                PriceAtPurchase = listProducts.First(p => p.ProductId == 4).Price,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            },
            new OrderItem
            {
                OrderItemId = "105",
                OrderId = "1",
                Status = OrderItemStatus.Completed,
                ProductId = 5,
                Quantity = 1,
                PriceAtPurchase = listProducts.First(p => p.ProductId == 5).Price,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            },
            new OrderItem
            {
                OrderItemId = "106",
                OrderId = "1",
                ProductId = 6,
                Status = OrderItemStatus.Pending,
                Quantity = 3,
                PriceAtPurchase = listProducts.First(p => p.ProductId == 6).Price,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            },
            new OrderItem
            {
                OrderItemId = "107",
                OrderId = "1",
                ProductId = 7,
                Status = OrderItemStatus.InProgress,
                Quantity = 1,
                PriceAtPurchase = listProducts.First(p => p.ProductId == 7).Price,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            },
            new OrderItem
            {
                OrderItemId = "108",
                OrderId = "1",
                ProductId = 8,
                Status = OrderItemStatus.InProgress,
                Quantity = 2,
                PriceAtPurchase = listProducts.First(p => p.ProductId == 8).Price,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            },
            new OrderItem
            {
                OrderItemId = "201",
                OrderId = "2",
                ProductId = 3,
                Status = OrderItemStatus.Completed,
                Quantity = 3,
                PriceAtPurchase = listProducts.First(p => p.ProductId == 3).Price,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            },
            new OrderItem
            {
                OrderItemId = "202",
                OrderId = "2",
                ProductId = 4,
                Status = OrderItemStatus.Completed,
                Quantity = 2,
                PriceAtPurchase = listProducts.First(p => p.ProductId == 4).Price,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            },
            new OrderItem
            {
                OrderItemId = "203",
                OrderId = "2",
                ProductId = 5,
                Status = OrderItemStatus.InProgress,
                Quantity = 1,
                PriceAtPurchase = listProducts.First(p => p.ProductId == 5).Price,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            },
            new OrderItem
            {
                OrderItemId = "204",
                OrderId = "2",
                ProductId = 6,
                Status = OrderItemStatus.Pending,
                Quantity = 1,
                PriceAtPurchase = listProducts.First(p => p.ProductId == 6).Price,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            },
            new OrderItem
            {
                OrderItemId = "205",
                OrderId = "2",
                ProductId = 7,
                Status = OrderItemStatus.Pending,
                Quantity = 2,
                PriceAtPurchase = listProducts.First(p => p.ProductId == 7).Price,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            },
            new OrderItem
            {
                OrderItemId = "301",
                OrderId = "3",
                ProductId = 4,
                Quantity = 1,
                Status = OrderItemStatus.InProgress,
                PriceAtPurchase = listProducts.First(p => p.ProductId == 4).Price,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            },
            new OrderItem
            {
                OrderItemId = "302",
                OrderId = "3",
                ProductId = 5,
                Quantity = 2,
                Status = OrderItemStatus.Completed,
                PriceAtPurchase = listProducts.First(p => p.ProductId == 5).Price,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            },
            new OrderItem
            {
                OrderItemId = "401",
                OrderId = "4",
                ProductId = 6,
                Quantity = 1,
                Status = OrderItemStatus.Completed,
                PriceAtPurchase = listProducts.First(p => p.ProductId == 6).Price,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            },
            new OrderItem
            {
                OrderItemId = "501",
                OrderId = "5",
                ProductId = 7,
                Quantity = 2,
                Status = OrderItemStatus.Completed,
                PriceAtPurchase = listProducts.First(p => p.ProductId == 7).Price,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            },
            new OrderItem
            {
                OrderItemId = "601",
                OrderId = "6",
                ProductId = 8,
                Quantity = 1,
                Status = OrderItemStatus.Completed,
                PriceAtPurchase = listProducts.First(p => p.ProductId == 8).Price,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            }
        };

        var listOrder = new List<Order>()
        {
            new Order
            {
                OrderId = "1", TableId = 1, StartTime = DateTime.Now,
                PeopleCount = 5,
                EndTime = null,
                Status = OrderStatus.InProgress,
                TotalAmount = listOrderDetail.Where(od => od.OrderId == "1").Sum(od => od.PriceAtPurchase * od.Quantity)
            },
            new Order
            {
                OrderId = "2", TableId = 6, StartTime = DateTime.Now,
                PeopleCount = 2,
                EndTime = null,
                Status = OrderStatus.InProgress,
                TotalAmount = listOrderDetail.Where(od => od.OrderId == "2").Sum(od => od.PriceAtPurchase * od.Quantity)
            },
            new Order
            {
                OrderId = "3", TableId = 2, StartTime = DateTime.Now,
                PeopleCount = 4,
                EndTime = null,
                Status = OrderStatus.InProgress,
                TotalAmount = listOrderDetail.Where(od => od.OrderId == "3").Sum(od => od.PriceAtPurchase * od.Quantity)
            },
            new Order
            {
                OrderId = "4", TableId = null, StartTime = new DateTime(2024, 10, 1, 12, 0, 0),
                EndTime = new DateTime(2024, 10, 1, 13, 0, 0),
                Status = OrderStatus.Completed,
                TotalAmount = listOrderDetail.Where(od => od.OrderId == "4").Sum(od => od.PriceAtPurchase * od.Quantity)
            },
            new Order
            {
                OrderId = "5", TableId = null, StartTime = new DateTime(2024, 10, 1, 12, 0, 0),
                EndTime = new DateTime(2024, 10, 1, 13, 0, 0),
                Status = OrderStatus.Completed,
                TotalAmount = listOrderDetail.Where(od => od.OrderId == "5").Sum(od => od.PriceAtPurchase * od.Quantity)
            },
            new Order
            {
                OrderId = "6", TableId = null, StartTime = new DateTime(2024, 10, 1, 12, 0, 0),
                EndTime = new DateTime(2024, 10, 1, 13, 0, 0),
                Status = OrderStatus.Completed,
                TotalAmount = listOrderDetail.Where(od => od.OrderId == "6").Sum(od => od.PriceAtPurchase * od.Quantity)
            },
        };


        modelBuilder.Entity<Table>().HasData(listTable);

        modelBuilder.Entity<Zone>().HasData(listZone);

        modelBuilder.Entity<Category>().HasData(listCategories);

        modelBuilder.Entity<Image>().HasData(listImages);

        modelBuilder.Entity<Product>().HasData(listProducts);

        modelBuilder.Entity<OrderItem>().HasData(listOrderDetail);

        modelBuilder.Entity<Order>().HasData(listOrder);

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}