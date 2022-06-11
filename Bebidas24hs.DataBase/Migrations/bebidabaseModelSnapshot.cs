﻿// <auto-generated />
using System;
using Bebidas24hs.DataBase.data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Bebidas24hs.DataBase.Migrations
{
    [DbContext(typeof(bebidabase))]
    partial class bebidabaseModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Bebidas24hs.DataBase.data.database.Pedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(120)
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("codpedido")
                        .HasMaxLength(4)
                        .HasColumnType("int");

                    b.Property<string>("descripcion")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime>("fechacreacion")
                        .HasMaxLength(120)
                        .HasColumnType("datetime2");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("valorcompra")
                        .HasMaxLength(8)
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Id" }, "Entity_Id")
                        .IsUnique();

                    b.HasIndex(new[] { "codpedido" }, "Pedido_Codpedido")
                        .IsUnique();

                    b.ToTable("pedidos");
                });

            modelBuilder.Entity("Bebidas24hs.DataBase.data.database.Producto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(120)
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<string>("Nombreproducto")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int?>("PedidoId")
                        .HasColumnType("int");

                    b.Property<string>("Proveedor")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("Valorproducto")
                        .HasMaxLength(4)
                        .HasColumnType("int");

                    b.Property<int>("codproducto")
                        .HasMaxLength(4)
                        .HasColumnType("int");

                    b.Property<DateTime>("fechacreacion")
                        .HasMaxLength(120)
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("PedidoId");

                    b.HasIndex(new[] { "Id" }, "Entity_Id")
                        .IsUnique()
                        .HasDatabaseName("Entity_Id1");

                    b.HasIndex(new[] { "codproducto" }, "Producto_Codproducto")
                        .IsUnique();

                    b.ToTable("productos");
                });

            modelBuilder.Entity("Bebidas24hs.DataBase.data.database.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(120)
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("fechacreacion")
                        .HasMaxLength(120)
                        .HasColumnType("datetime2");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<string>("pasword")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Id" }, "Entity_Id")
                        .IsUnique()
                        .HasDatabaseName("Entity_Id2");

                    b.HasIndex(new[] { "pasword" }, "Usuario_Pasword")
                        .IsUnique();

                    b.ToTable("usuarios");
                });

            modelBuilder.Entity("Bebidas24hs.DataBase.data.database.Producto", b =>
                {
                    b.HasOne("Bebidas24hs.DataBase.data.database.Pedido", null)
                        .WithMany("Producto")
                        .HasForeignKey("PedidoId");
                });

            modelBuilder.Entity("Bebidas24hs.DataBase.data.database.Pedido", b =>
                {
                    b.Navigation("Producto");
                });
#pragma warning restore 612, 618
        }
    }
}
