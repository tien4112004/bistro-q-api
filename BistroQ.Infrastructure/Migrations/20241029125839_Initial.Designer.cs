﻿// <auto-generated />
using System;
using BistroQ.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BistroQ.Infrastructure.Migrations
{
    [DbContext(typeof(BistroQContext))]
    [Migration("20241029125839_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("utf8mb4_0900_ai_ci")
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.HasCharSet(modelBuilder, "utf8mb4");
            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("BistroQ.Core.Entities.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("CategoryId")
                        .HasName("PRIMARY");

                    b.ToTable("Category", (string)null);
                });

            modelBuilder.Entity("BistroQ.Core.Entities.NutritionFact", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<double?>("Calories")
                        .HasColumnType("double");

                    b.HasKey("ProductId")
                        .HasName("PRIMARY");

                    b.ToTable("NutritionFact", (string)null);
                });

            modelBuilder.Entity("BistroQ.Core.Entities.Order", b =>
                {
                    b.Property<string>("OrderId")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("EndTime")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("StartTime")
                        .HasColumnType("datetime");

                    b.Property<int?>("TableId")
                        .HasColumnType("int");

                    b.Property<decimal?>("TotalAmount")
                        .HasPrecision(10)
                        .HasColumnType("decimal(10)");

                    b.HasKey("OrderId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "TableId" }, "TableId");

                    b.ToTable("Order", (string)null);
                });

            modelBuilder.Entity("BistroQ.Core.Entities.OrderDetail", b =>
                {
                    b.Property<string>("OrderDetailId")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("OrderId")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<decimal?>("PriceAtPurchase")
                        .HasPrecision(10)
                        .HasColumnType("decimal(10)");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("OrderDetailId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "OrderId" }, "OrderId");

                    b.HasIndex(new[] { "ProductId" }, "ProductId");

                    b.ToTable("OrderDetail", (string)null);
                });

            modelBuilder.Entity("BistroQ.Core.Entities.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<decimal?>("DiscountPrice")
                        .HasPrecision(10)
                        .HasColumnType("decimal(10)");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<decimal?>("Price")
                        .HasPrecision(10)
                        .HasColumnType("decimal(10)");

                    b.Property<string>("Unit")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("ProductId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "CategoryId" }, "CategoryId");

                    b.ToTable("Product", (string)null);
                });

            modelBuilder.Entity("BistroQ.Core.Entities.Table", b =>
                {
                    b.Property<int>("TableId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("TableId"));

                    b.Property<int?>("Number")
                        .HasColumnType("int");

                    b.Property<int?>("SeatsCount")
                        .HasColumnType("int");

                    b.Property<int?>("ZoneId")
                        .HasColumnType("int");

                    b.HasKey("TableId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "ZoneId" }, "ZoneId");

                    b.ToTable("Table", (string)null);
                });

            modelBuilder.Entity("BistroQ.Core.Entities.Zone", b =>
                {
                    b.Property<int>("ZoneId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("ZoneId"));

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("ZoneId")
                        .HasName("PRIMARY");

                    b.ToTable("Zone", (string)null);
                });

            modelBuilder.Entity("BistroQ.Infrastructure.Identity.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("RefreshTokenExpiryTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("Users", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "1",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "cebb5033-fcf0-4cbd-84d9-b4ba00a91d20",
                            Email = "admin@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@GMAIL.COM",
                            NormalizedUserName = "ADMIN",
                            PasswordHash = "AQAAAAIAAYagAAAAEOE1qegBsYW/LuHfXtj4jLYagS2SlFG7hrTziRV7AdUcfieW3o33WDEDUugju57rMQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "9b15f27a-a8c5-4298-9cd9-a163f5497ca8",
                            TwoFactorEnabled = false,
                            UserName = "admin"
                        },
                        new
                        {
                            Id = "2",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "c89a07c9-cfb5-40f7-a0ad-1d69a4cb7bc2",
                            Email = "kitchen@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "KITCHEN@GMAIL.COM",
                            NormalizedUserName = "KITCHEN",
                            PasswordHash = "AQAAAAIAAYagAAAAENuKG4cqOQeTHWAmSnk1WIqrEcBXI42oT8JPvhig7Rj7srIMv8lcaRUbtmHGLODuAA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "5699b74a-2f0b-4de9-8a87-2de646cad84f",
                            TwoFactorEnabled = false,
                            UserName = "kitchen"
                        },
                        new
                        {
                            Id = "3",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "7b7f764a-b504-48cf-9fca-a7b01fc63780",
                            Email = "cashier@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "CASHIER@GMAIL.COM",
                            NormalizedUserName = "CASHIER",
                            PasswordHash = "AQAAAAIAAYagAAAAELPwcMF5AiZthQQ58cHawb2COKO1SZOiAo0JmKe5C2VYBcfF5wHAEzRVonFeskoZ2A==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "5d351854-b70a-4849-a7a0-bbccec9acae8",
                            TwoFactorEnabled = false,
                            UserName = "cashier"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("Roles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "1",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "2",
                            Name = "Kitchen",
                            NormalizedName = "KITCHEN"
                        },
                        new
                        {
                            Id = "3",
                            Name = "Cashier",
                            NormalizedName = "CASHIER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("UserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "1",
                            RoleId = "1"
                        },
                        new
                        {
                            UserId = "2",
                            RoleId = "2"
                        },
                        new
                        {
                            UserId = "3",
                            RoleId = "3"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("UserTokens", (string)null);
                });

            modelBuilder.Entity("BistroQ.Core.Entities.NutritionFact", b =>
                {
                    b.HasOne("BistroQ.Core.Entities.Product", "Product")
                        .WithOne("NutritionFact")
                        .HasForeignKey("BistroQ.Core.Entities.NutritionFact", "ProductId")
                        .IsRequired()
                        .HasConstraintName("NutritionFact_ibfk_1");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("BistroQ.Core.Entities.Order", b =>
                {
                    b.HasOne("BistroQ.Core.Entities.Table", "Table")
                        .WithMany("Orders")
                        .HasForeignKey("TableId")
                        .HasConstraintName("Order_ibfk_1");

                    b.Navigation("Table");
                });

            modelBuilder.Entity("BistroQ.Core.Entities.OrderDetail", b =>
                {
                    b.HasOne("BistroQ.Core.Entities.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .HasConstraintName("OrderDetail_ibfk_1");

                    b.HasOne("BistroQ.Core.Entities.Product", "Product")
                        .WithMany("OrderDetails")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("OrderDetail_ibfk_2");

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("BistroQ.Core.Entities.Product", b =>
                {
                    b.HasOne("BistroQ.Core.Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("Product_ibfk_1");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("BistroQ.Core.Entities.Table", b =>
                {
                    b.HasOne("BistroQ.Core.Entities.Zone", "Zone")
                        .WithMany("Tables")
                        .HasForeignKey("ZoneId")
                        .HasConstraintName("Table_ibfk_1");

                    b.Navigation("Zone");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("BistroQ.Infrastructure.Identity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("BistroQ.Infrastructure.Identity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BistroQ.Infrastructure.Identity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("BistroQ.Infrastructure.Identity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BistroQ.Core.Entities.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("BistroQ.Core.Entities.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("BistroQ.Core.Entities.Product", b =>
                {
                    b.Navigation("NutritionFact");

                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("BistroQ.Core.Entities.Table", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("BistroQ.Core.Entities.Zone", b =>
                {
                    b.Navigation("Tables");
                });
#pragma warning restore 612, 618
        }
    }
}