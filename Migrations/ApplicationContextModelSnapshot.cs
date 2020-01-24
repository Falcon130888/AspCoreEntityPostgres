﻿// <auto-generated />
using System;
using AspCoreEntityPostgres.DBcontext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AspCoreEntityPostgres.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("AspCoreEntityPostgres.Models.CopyMemo", b =>
                {
                    b.Property<int>("IdCopyMemo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("IdMemo")
                        .HasColumnType("integer");

                    b.Property<int>("IdUser")
                        .HasColumnType("integer");

                    b.HasKey("IdCopyMemo");

                    b.HasIndex("IdMemo")
                        .IsUnique();

                    b.HasIndex("IdUser");

                    b.ToTable("CopyMemos");
                });

            modelBuilder.Entity("AspCoreEntityPostgres.Models.Dolzh", b =>
                {
                    b.Property<int>("IdDolzh")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("IdOtdel")
                        .HasColumnType("integer");

                    b.Property<string>("NameDolzh")
                        .HasColumnType("text");

                    b.HasKey("IdDolzh");

                    b.HasIndex("IdOtdel");

                    b.ToTable("Dolzhs");
                });

            modelBuilder.Entity("AspCoreEntityPostgres.Models.Memo", b =>
                {
                    b.Property<int>("IdMemo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DateEnd")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("IdStatus")
                        .HasColumnType("integer");

                    b.Property<int?>("IdUserExecutor")
                        .HasColumnType("integer");

                    b.Property<int>("IdUserTo")
                        .HasColumnType("integer");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Thema")
                        .HasColumnType("text");

                    b.HasKey("IdMemo");

                    b.HasIndex("IdStatus");

                    b.HasIndex("IdUserExecutor");

                    b.HasIndex("IdUserTo");

                    b.ToTable("Memos");
                });

            modelBuilder.Entity("AspCoreEntityPostgres.Models.MemoFile", b =>
                {
                    b.Property<int>("IdMemoFile")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("FileName")
                        .HasColumnType("text");

                    b.Property<string>("Format")
                        .HasColumnType("text");

                    b.Property<int>("IdMemo")
                        .HasColumnType("integer");

                    b.Property<string>("Path")
                        .HasColumnType("text");

                    b.HasKey("IdMemoFile");

                    b.HasIndex("IdMemo")
                        .IsUnique();

                    b.ToTable("MemoFiles");
                });

            modelBuilder.Entity("AspCoreEntityPostgres.Models.Otdel", b =>
                {
                    b.Property<int>("IdOtdel")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("LeadOtdel")
                        .HasColumnType("text");

                    b.Property<string>("NameOtdel")
                        .HasColumnType("text");

                    b.HasKey("IdOtdel");

                    b.ToTable("Otdels");
                });

            modelBuilder.Entity("AspCoreEntityPostgres.Models.Role", b =>
                {
                    b.Property<int>("IdRole")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("NameRole")
                        .HasColumnType("text");

                    b.HasKey("IdRole");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("AspCoreEntityPostgres.Models.Status", b =>
                {
                    b.Property<int>("IdStatus")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("NameStatus")
                        .HasColumnType("text");

                    b.HasKey("IdStatus");

                    b.ToTable("Statuses");
                });

            modelBuilder.Entity("AspCoreEntityPostgres.Models.Task", b =>
                {
                    b.Property<int>("IdTask")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("DateBegin")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DateEnd")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("IdUser")
                        .HasColumnType("integer");

                    b.Property<string>("NameTask")
                        .HasColumnType("text");

                    b.Property<string>("TypeTask")
                        .HasColumnType("text");

                    b.HasKey("IdTask");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("AspCoreEntityPostgres.Models.User", b =>
                {
                    b.Property<int>("IdUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("IdDolzh")
                        .HasColumnType("integer");

                    b.Property<int>("IdOtdel")
                        .HasColumnType("integer");

                    b.Property<int>("IdRole")
                        .HasColumnType("integer");

                    b.Property<string>("UserAdLogin")
                        .HasColumnType("text");

                    b.Property<int>("UserConf")
                        .HasColumnType("integer");

                    b.Property<string>("UserFIO")
                        .HasColumnType("text");

                    b.Property<string>("UserLogin")
                        .HasColumnType("text");

                    b.Property<string>("UserPassword")
                        .HasColumnType("text");

                    b.HasKey("IdUser");

                    b.HasIndex("IdDolzh");

                    b.HasIndex("IdOtdel");

                    b.HasIndex("IdRole");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AspCoreEntityPostgres.Models.CopyMemo", b =>
                {
                    b.HasOne("AspCoreEntityPostgres.Models.Memo", "Memo")
                        .WithOne("UserCopy")
                        .HasForeignKey("AspCoreEntityPostgres.Models.CopyMemo", "IdMemo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AspCoreEntityPostgres.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AspCoreEntityPostgres.Models.Dolzh", b =>
                {
                    b.HasOne("AspCoreEntityPostgres.Models.Otdel", "Otdel")
                        .WithMany()
                        .HasForeignKey("IdOtdel")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AspCoreEntityPostgres.Models.Memo", b =>
                {
                    b.HasOne("AspCoreEntityPostgres.Models.Status", "Status")
                        .WithMany()
                        .HasForeignKey("IdStatus")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AspCoreEntityPostgres.Models.User", "UserExecutor")
                        .WithMany()
                        .HasForeignKey("IdUserExecutor");

                    b.HasOne("AspCoreEntityPostgres.Models.User", "UserTO")
                        .WithMany()
                        .HasForeignKey("IdUserTo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AspCoreEntityPostgres.Models.MemoFile", b =>
                {
                    b.HasOne("AspCoreEntityPostgres.Models.Memo", "Memo")
                        .WithOne("MemoFile")
                        .HasForeignKey("AspCoreEntityPostgres.Models.MemoFile", "IdMemo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AspCoreEntityPostgres.Models.User", b =>
                {
                    b.HasOne("AspCoreEntityPostgres.Models.Dolzh", "Dolzh")
                        .WithMany()
                        .HasForeignKey("IdDolzh")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AspCoreEntityPostgres.Models.Otdel", "Otdel")
                        .WithMany()
                        .HasForeignKey("IdOtdel")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AspCoreEntityPostgres.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("IdRole")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
