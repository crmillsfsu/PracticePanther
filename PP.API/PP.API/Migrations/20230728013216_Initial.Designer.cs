﻿//// <auto-generated />
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Infrastructure;
//using Microsoft.EntityFrameworkCore.Metadata;
//using Microsoft.EntityFrameworkCore.Migrations;
//using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
//using PP.API.Database;

//#nullable disable

//namespace PP.API.Migrations
//{
//    [DbContext(typeof(EfContext))]
//    [Migration("20230728013216_Initial")]
//    partial class Initial
//    {
//        /// <inheritdoc />
//        protected override void BuildTargetModel(ModelBuilder modelBuilder)
//        {
//#pragma warning disable 612, 618
//            modelBuilder
//                .HasAnnotation("ProductVersion", "7.0.9")
//                .HasAnnotation("Relational:MaxIdentifierLength", 128);

//            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

//            modelBuilder.Entity("PP.Library.Models.Client", b =>
//                {
//                    b.Property<int>("Id")
//                        .ValueGeneratedOnAdd()
//                        .HasColumnType("int");

//                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

//                    b.Property<string>("Name")
//                        .IsRequired()
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<string>("Property1")
//                        .IsRequired()
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<string>("Property10")
//                        .IsRequired()
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<string>("Property2")
//                        .IsRequired()
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<string>("Property3")
//                        .IsRequired()
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<string>("Property4")
//                        .IsRequired()
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<string>("Property5")
//                        .IsRequired()
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<string>("Property6")
//                        .IsRequired()
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<string>("Property7")
//                        .IsRequired()
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<string>("Property8")
//                        .IsRequired()
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<string>("Property9")
//                        .IsRequired()
//                        .HasColumnType("nvarchar(max)");

//                    b.HasKey("Id");

//                    b.ToTable("Clients");
//                });

//            modelBuilder.Entity("PP.Library.Models.Project", b =>
//                {
//                    b.Property<int>("Id")
//                        .ValueGeneratedOnAdd()
//                        .HasColumnType("int");

//                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

//                    b.Property<int>("ClientId")
//                        .HasColumnType("int");

//                    b.Property<string>("Name")
//                        .HasColumnType("nvarchar(max)");

//                    b.HasKey("Id");

//                    b.HasIndex("ClientId");

//                    b.ToTable("Project");
//                });

//            modelBuilder.Entity("PP.Library.Models.Project", b =>
//                {
//                    b.HasOne("PP.Library.Models.Client", "Client")
//                        .WithMany("Projects")
//                        .HasForeignKey("ClientId")
//                        .OnDelete(DeleteBehavior.Cascade)
//                        .IsRequired();

//                    b.Navigation("Client");
//                });

//            modelBuilder.Entity("PP.Library.Models.Client", b =>
//                {
//                    b.Navigation("Projects");
//                });
//#pragma warning restore 612, 618
//        }
//    }
//}
