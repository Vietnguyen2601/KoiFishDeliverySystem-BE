using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace KoiFishDelivery.Entities;

public partial class KoiFishDeleverySystemContext : DbContext
{
    public KoiFishDeleverySystemContext()
    {
    }

    public KoiFishDeleverySystemContext(DbContextOptions<KoiFishDeleverySystemContext> options)
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
        => optionsBuilder.UseSqlServer("Server=(local);uid=sa;pwd=123456;database= KoiFishDeleverySystem;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasKey(e => e.FeedbackId).HasName("PK__Feedback__6A4BEDF6F6EFB0E4");

            entity.ToTable("Feedback");

            entity.Property(e => e.FeedbackId)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("FeedbackID");
            entity.Property(e => e.Comment).HasMaxLength(1000);
            entity.Property(e => e.CustomerId)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("CustomerID");
            entity.Property(e => e.OrderId)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("OrderID");

            entity.HasOne(d => d.Customer).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__Feedback__Custom__5535A963");

            entity.HasOne(d => d.Order).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__Feedback__OrderI__5629CD9C");
        });

        modelBuilder.Entity<KoiFish>(entity =>
        {
            entity.HasKey(e => e.KoiFishId).HasName("PK__KoiFish__44D353C596EEDA8B");

            entity.ToTable("KoiFish");

            entity.Property(e => e.KoiFishId)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("KoiFishID");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Manufacturer).HasMaxLength(255);
            entity.Property(e => e.OrderId)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("OrderID");
            entity.Property(e => e.Type).HasMaxLength(100);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Orders__C3905BAF0758F6A4");

            entity.Property(e => e.OrderId)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("OrderID");
            entity.Property(e => e.AdditionalService)
                .HasMaxLength(1)
                .IsUnicode(false);
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
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("ShiperID");
            entity.Property(e => e.UserId)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("UserID");

            entity.HasOne(d => d.AdditionalServiceNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.AdditionalService)
                .HasConstraintName("FK__Orders__Addition__49C3F6B7");

            entity.HasOne(d => d.Shiper).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ShiperId)
                .HasConstraintName("FK__Orders__ShiperID__45F365D3");

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Orders__UserID__44FF419A");
        });

        modelBuilder.Entity<OrderService>(entity =>
        {
            entity.HasKey(e => e.OrderServiceId).HasName("PK__OrderSer__F065F7CBD01A5D42");

            entity.ToTable("OrderService");

            entity.Property(e => e.OrderServiceId)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("OrderServiceID");
            entity.Property(e => e.OrderId)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("OrderID");
            entity.Property(e => e.ServiceId)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("ServiceID");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderServices)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__OrderServ__Order__4CA06362");

            entity.HasOne(d => d.Service).WithMany(p => p.OrderServices)
                .HasForeignKey(d => d.ServiceId)
                .HasConstraintName("FK__OrderServ__Servi__4D94879B");
        });

        modelBuilder.Entity<PaymentDetail>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__PaymentD__9B556A58DC6EF533");

            entity.ToTable("PaymentDetail");

            entity.Property(e => e.PaymentId)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("PaymentID");
            entity.Property(e => e.OrderId)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("OrderID");
            entity.Property(e => e.PaymentDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentMethod).HasMaxLength(50);

            entity.HasOne(d => d.Order).WithMany(p => p.PaymentDetails)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__PaymentDe__Order__5070F446");
        });

        modelBuilder.Entity<PriceBoard>(entity =>
        {
            entity.HasKey(e => e.PriceId).HasName("PK__PriceBoa__4957584F678E527B");

            entity.ToTable("PriceBoard");

            entity.Property(e => e.PriceId)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("PriceID");
            entity.Property(e => e.Description).HasMaxLength(255);
        });

        modelBuilder.Entity<Question>(entity =>
        {
            entity.HasKey(e => e.QuestionId).HasName("PK__Question__0DC06F8CE9AFD3A2");

            entity.ToTable("Question");

            entity.Property(e => e.QuestionId)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("QuestionID");
            entity.Property(e => e.AnswerText).HasMaxLength(255);
            entity.Property(e => e.QuestionText).HasMaxLength(255);
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.ServiceId).HasName("PK__Service__C51BB0EAF00C4023");

            entity.ToTable("Service");

            entity.Property(e => e.ServiceId)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("ServiceID");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.PriceId)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("PriceID");

            entity.HasOne(d => d.Price).WithMany(p => p.Services)
                .HasForeignKey(d => d.PriceId)
                .HasConstraintName("FK__Service__PriceID__403A8C7D");
        });

        modelBuilder.Entity<Shiper>(entity =>
        {
            entity.HasKey(e => e.ShiperId).HasName("PK__Shiper__A3BA7B8E8AF6DDAE");

            entity.ToTable("Shiper");

            entity.Property(e => e.ShiperId)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("ShiperID");
            entity.Property(e => e.Available)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.UserId)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Shipers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Shiper__UserID__3A81B327");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCACC5B7F2DB");

            entity.Property(e => e.UserId)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("UserID");
            entity.Property(e => e.DateOfBirth).HasColumnName("date_of_birth");
            entity.Property(e => e.Email)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Role)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("role");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
