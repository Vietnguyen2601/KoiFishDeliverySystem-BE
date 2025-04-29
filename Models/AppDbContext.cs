using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace KoiFishDeliverySystem.Models;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<KoiFish> KoiFishes { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderService> OrderServices { get; set; }

    public virtual DbSet<PaymentDetail> PaymentDetails { get; set; }

    public virtual DbSet<PriceBoard> PriceBoards { get; set; }

    public virtual DbSet<Question> Questions { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<Shiper> Shipers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=KoiFishDeleverySystem;User Id=sa;Password=123456;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasKey(e => e.FeedbackId).HasName("PK__Feedback__6A4BEDF634E1E46D");

            entity.ToTable("Feedback");

            entity.Property(e => e.FeedbackId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("FeedbackID");
            entity.Property(e => e.Comment).HasMaxLength(1000);
            entity.Property(e => e.OrderId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("OrderID");

            entity.HasOne(d => d.Order).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK_Feedback_Order");
        });

        modelBuilder.Entity<KoiFish>(entity =>
        {
            entity.HasKey(e => e.KoiFishId).HasName("PK__KoiFish__44D353C53EE7C145");

            entity.ToTable("KoiFish");

            entity.Property(e => e.KoiFishId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("KoiFishID");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.LenghtAve).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Manufacturer).HasMaxLength(255);
            entity.Property(e => e.OrderId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("OrderID");
            entity.Property(e => e.Type).HasMaxLength(100);
            entity.Property(e => e.WeightAve).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Order).WithMany(p => p.KoiFishes)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK_KoiFish_Order");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Orders__C3905BAFF4B8FFB8");

            entity.Property(e => e.OrderId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("OrderID");
            entity.Property(e => e.DeliveryAddress).HasMaxLength(255);
            entity.Property(e => e.DeliveryStatus).HasMaxLength(50);
            entity.Property(e => e.Notes).HasMaxLength(255);
            entity.Property(e => e.OrderDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.PaymentStatus)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.PickupAddress).HasMaxLength(255);
            entity.Property(e => e.ShiperId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ShiperID");
            entity.Property(e => e.TotalPrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.UserId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("UserID");

            entity.HasOne(d => d.Shiper).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ShiperId)
                .HasConstraintName("FK_Orders_Shiper");

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Orders_User");
        });

        modelBuilder.Entity<OrderService>(entity =>
        {
            entity.HasKey(e => e.OrderServiceId).HasName("PK__OrderSer__F065F7CB3734CDDB");

            entity.ToTable("OrderService");

            entity.Property(e => e.OrderServiceId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("OrderServiceID");
            entity.Property(e => e.OrderId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("OrderID");
            entity.Property(e => e.ServiceId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ServiceID");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderServices)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK_OrderService_Order");

            entity.HasOne(d => d.Service).WithMany(p => p.OrderServices)
                .HasForeignKey(d => d.ServiceId)
                .HasConstraintName("FK_OrderService_Service");
        });

        modelBuilder.Entity<PaymentDetail>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__PaymentD__9B556A588C07CF32");

            entity.ToTable("PaymentDetail");

            entity.Property(e => e.PaymentId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("PaymentID");
            entity.Property(e => e.OrderId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("OrderID");
            entity.Property(e => e.PaidAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PaymentDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.PaymentMethod).HasMaxLength(50);

            entity.HasOne(d => d.Order).WithMany(p => p.PaymentDetails)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK_PaymentDetail_Order");
        });

        modelBuilder.Entity<PriceBoard>(entity =>
        {
            entity.HasKey(e => e.PriceId).HasName("PK__PriceBoa__4957584F42B72AA8");

            entity.ToTable("PriceBoard");

            entity.Property(e => e.PriceId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("PriceID");
            entity.Property(e => e.BasePrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.ExtraCost).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<Question>(entity =>
        {
            entity.HasKey(e => e.QuestionId).HasName("PK__Question__0DC06F8CBF4AA6AA");

            entity.ToTable("Question");

            entity.Property(e => e.QuestionId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("QuestionID");
            entity.Property(e => e.AnswerText).HasMaxLength(255);
            entity.Property(e => e.QuestionText).HasMaxLength(255);
            entity.Property(e => e.UserId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Questions)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Question_User");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.ServiceId).HasName("PK__Service__C51BB0EA5F75FE51");

            entity.ToTable("Service");

            entity.Property(e => e.ServiceId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ServiceID");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.PriceId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("PriceID");

            entity.HasOne(d => d.Price).WithMany(p => p.Services)
                .HasForeignKey(d => d.PriceId)
                .HasConstraintName("FK_Service_PriceBoard");
        });

        modelBuilder.Entity<Shiper>(entity =>
        {
            entity.HasKey(e => e.ShiperId).HasName("PK__Shiper__A3BA7B8E05068275");

            entity.ToTable("Shiper");

            entity.Property(e => e.ShiperId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ShiperID");
            entity.Property(e => e.Available)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.UserId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Shipers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Shiper_User");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCAC7FD9904C");

            entity.Property(e => e.UserId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("UserID");
            entity.Property(e => e.DateOfBirth).HasColumnName("Date_of_Birth");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.Gender)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Role)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValue("Active");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
