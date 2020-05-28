﻿// <auto-generated />
using System;
using Infrastructure.RDBMS;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BookCrossingBackEnd.Migrations
{
    [DbContext(typeof(BookCrossingContext))]
    partial class BookCrossingContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.RDBMS.Entities.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnName("firstname")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<bool>("IsConfirmed")
                        .HasColumnName("is_confirmed")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnName("lastname")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Author");
                });

            modelBuilder.Entity("Domain.RDBMS.Entities.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImagePath")
                        .HasColumnName("imagepath")
                        .HasColumnType("nvarchar(260)")
                        .HasMaxLength(260);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Notice")
                        .HasColumnName("notice")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<string>("Publisher")
                        .HasColumnName("publisher")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("State")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50)
                        .HasDefaultValue("Available");

                    b.Property<int>("UserId")
                        .HasColumnName("user_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Book");
                });

            modelBuilder.Entity("Domain.RDBMS.Entities.BookAuthor", b =>
                {
                    b.Property<int>("BookId")
                        .HasColumnName("book_id")
                        .HasColumnType("int");

                    b.Property<int>("AuthorId")
                        .HasColumnName("author_id")
                        .HasColumnType("int");

                    b.HasKey("BookId", "AuthorId");

                    b.HasIndex("AuthorId");

                    b.ToTable("BookAuthor");
                });

            modelBuilder.Entity("Domain.RDBMS.Entities.BookGenre", b =>
                {
                    b.Property<int>("BookId")
                        .HasColumnName("book_id")
                        .HasColumnType("int");

                    b.Property<int>("GenreId")
                        .HasColumnName("genre_id")
                        .HasColumnType("int");

                    b.HasKey("BookId", "GenreId");

                    b.HasIndex("GenreId");

                    b.ToTable("BookGenre");
                });

            modelBuilder.Entity("Domain.RDBMS.Entities.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Genre");
                });

            modelBuilder.Entity("Domain.RDBMS.Entities.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnName("city")
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<bool>("IsActive")
                        .HasColumnName("is_active")
                        .HasColumnType("bit");

                    b.Property<string>("OfficeName")
                        .HasColumnName("office_name")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnName("street")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("Domain.RDBMS.Entities.Request", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookId")
                        .HasColumnName("book_id")
                        .HasColumnType("int");

                    b.Property<int>("OwnerId")
                        .HasColumnName("owner_id")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ReceiveDate")
                        .HasColumnName("receive_date")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("RequestDate")
                        .HasColumnName("request_date")
                        .HasColumnType("datetime");

                    b.Property<int>("UserId")
                        .HasColumnName("user_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("OwnerId");

                    b.HasIndex("UserId");

                    b.ToTable("Request");
                });

            modelBuilder.Entity("Domain.RDBMS.Entities.ResetPassword", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConfirmationNumber")
                        .IsRequired()
                        .HasColumnName("confirmation_number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ResetDate")
                        .HasColumnName("reset_date")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("ResetPassword");
                });

            modelBuilder.Entity("Domain.RDBMS.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("Domain.RDBMS.Entities.ScheduleJob", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RequestId")
                        .HasColumnName("requestId")
                        .HasColumnType("int");

                    b.Property<string>("ScheduleId")
                        .IsRequired()
                        .HasColumnName("scheduleId")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("ScheduleJob");
                });

            modelBuilder.Entity("Domain.RDBMS.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnName("birth_date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("email")
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnName("firstname")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnName("lastname")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("MiddleName")
                        .HasColumnName("middlename")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnName("password")
                        .HasColumnType("nvarchar(32)")
                        .HasMaxLength(32);

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RegisteredDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("registered_date")
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<int>("RoleId")
                        .HasColumnName("role_id")
                        .HasColumnType("int");

                    b.Property<int?>("UserRoomId")
                        .HasColumnName("user_room_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserRoomId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Domain.RDBMS.Entities.UserRoom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LocationId")
                        .HasColumnName("location_id")
                        .HasColumnType("int");

                    b.Property<int>("RoomNumber")
                        .HasColumnName("room_number")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.ToTable("UserRoom");
                });

            modelBuilder.Entity("Domain.RDBMS.Entities.Book", b =>
                {
                    b.HasOne("Domain.RDBMS.Entities.User", "User")
                        .WithMany("Book")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.RDBMS.Entities.BookAuthor", b =>
                {
                    b.HasOne("Domain.RDBMS.Entities.Author", "Author")
                        .WithMany("BookAuthor")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.RDBMS.Entities.Book", "Book")
                        .WithMany("BookAuthor")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.RDBMS.Entities.BookGenre", b =>
                {
                    b.HasOne("Domain.RDBMS.Entities.Book", "Book")
                        .WithMany("BookGenre")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.RDBMS.Entities.Genre", "Genre")
                        .WithMany("BookGenre")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.RDBMS.Entities.Request", b =>
                {
                    b.HasOne("Domain.RDBMS.Entities.Book", "Book")
                        .WithMany("Request")
                        .HasForeignKey("BookId")
                        .IsRequired();

                    b.HasOne("Domain.RDBMS.Entities.User", "Owner")
                        .WithMany("RequestOwner")
                        .HasForeignKey("OwnerId")
                        .IsRequired();

                    b.HasOne("Domain.RDBMS.Entities.User", "User")
                        .WithMany("RequestUser")
                        .HasForeignKey("UserId")
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.RDBMS.Entities.User", b =>
                {
                    b.HasOne("Domain.RDBMS.Entities.Role", "Role")
                        .WithMany("User")
                        .HasForeignKey("RoleId")
                        .IsRequired();

                    b.HasOne("Domain.RDBMS.Entities.UserRoom", "UserRoom")
                        .WithMany("User")
                        .HasForeignKey("UserRoomId");
                });

            modelBuilder.Entity("Domain.RDBMS.Entities.UserRoom", b =>
                {
                    b.HasOne("Domain.RDBMS.Entities.Location", "Location")
                        .WithMany("UserRoom")
                        .HasForeignKey("LocationId")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
