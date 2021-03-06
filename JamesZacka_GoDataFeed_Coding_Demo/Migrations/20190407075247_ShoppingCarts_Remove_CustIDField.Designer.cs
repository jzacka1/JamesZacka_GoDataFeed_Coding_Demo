﻿// <auto-generated />
using System;
using JamesZacka_GoDataFeed_Coding_Demo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace JamesZacka_GoDataFeed_Coding_Demo.Migrations
{
    [DbContext(typeof(Model1))]
    [Migration("20190407075247_ShoppingCarts_Remove_CustIDField")]
    partial class ShoppingCarts_Remove_CustIDField
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.2-rtm-30932")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("JamesZacka_GoDataFeed_Coding_Demo.Models.Customers", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("JamesZacka_GoDataFeed_Coding_Demo.Models.Orders", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustomerID");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<DateTime>("OrderDate");

                    b.Property<string>("PaymentMethod")
                        .IsRequired();

                    b.Property<DateTime>("Status");

                    b.Property<double>("Total");

                    b.HasKey("ID");

                    b.HasIndex("CustomerID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("JamesZacka_GoDataFeed_Coding_Demo.Models.Products", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Manufacturer");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int?>("OrdersID");

                    b.Property<double>("Price");

                    b.Property<int>("Quantity");

                    b.Property<int?>("ShoppingCartsID");

                    b.HasKey("ID");

                    b.HasIndex("OrdersID");

                    b.HasIndex("ShoppingCartsID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("JamesZacka_GoDataFeed_Coding_Demo.Models.ShoppingCarts", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int>("CustomerID");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<double>("Total");

                    b.HasKey("ID");

                    b.HasIndex("CustomerID");

                    b.ToTable("ShoppingCarts");
                });

            modelBuilder.Entity("JamesZacka_GoDataFeed_Coding_Demo.Models.Orders", b =>
                {
                    b.HasOne("JamesZacka_GoDataFeed_Coding_Demo.Models.Customers", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("JamesZacka_GoDataFeed_Coding_Demo.Models.Products", b =>
                {
                    b.HasOne("JamesZacka_GoDataFeed_Coding_Demo.Models.Orders")
                        .WithMany("Items")
                        .HasForeignKey("OrdersID");

                    b.HasOne("JamesZacka_GoDataFeed_Coding_Demo.Models.ShoppingCarts")
                        .WithMany("Items")
                        .HasForeignKey("ShoppingCartsID");
                });

            modelBuilder.Entity("JamesZacka_GoDataFeed_Coding_Demo.Models.ShoppingCarts", b =>
                {
                    b.HasOne("JamesZacka_GoDataFeed_Coding_Demo.Models.Customers", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
