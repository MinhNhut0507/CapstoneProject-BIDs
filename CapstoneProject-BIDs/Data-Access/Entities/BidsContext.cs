using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Data_Access.Entities;

public partial class BidsContext : DbContext
{
    public BidsContext()
    {
    }

    public BidsContext(DbContextOptions<BidsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BanHistory> BanHistories { get; set; }

    public virtual DbSet<BidderPrice> BidderPrices { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<ItemType> ItemTypes { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Session> Sessions { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server =MINHNHUT\\NHUT57;database=BIDs;uid=sa;pwd=05072001;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BanHistory>(entity =>
        {
            entity.HasKey(e => e.BanId);

            entity.ToTable("BanHistory");

            entity.Property(e => e.BanId)
                .ValueGeneratedNever()
                .HasColumnName("BanID");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.Reason).IsRequired();
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.BanHistories)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BanHistory_User");
        });

        modelBuilder.Entity<BidderPrice>(entity =>
        {
            entity.HasKey(e => new { e.ItemId, e.UserId });

            entity.ToTable("BidderPrice");

            entity.Property(e => e.ItemId).HasColumnName("ItemID");
            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Item).WithMany(p => p.BidderPrices)
                .HasForeignKey(d => d.ItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BidderPrice_Item");

            entity.HasOne(d => d.User).WithMany(p => p.BidderPrices)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BidderPrice_User");
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.ToTable("Item");

            entity.Property(e => e.ItemId)
                .ValueGeneratedNever()
                .HasColumnName("ItemID");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.Description).IsRequired();
            entity.Property(e => e.Image)
                .IsRequired()
                .HasColumnType("image");
            entity.Property(e => e.ItemName)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.ItemTypeId).HasColumnName("ItemTypeID");
            entity.Property(e => e.SessionId).HasColumnName("SessionID");
            entity.Property(e => e.StaffId).HasColumnName("StaffID");
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.ItemType).WithMany(p => p.Items)
                .HasForeignKey(d => d.ItemTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Item_ItemType");

            entity.HasOne(d => d.Session).WithMany(p => p.Items)
                .HasForeignKey(d => d.SessionId)
                .HasConstraintName("FK_Item_Session");

            entity.HasOne(d => d.Staff).WithMany(p => p.Items)
                .HasForeignKey(d => d.StaffId)
                .HasConstraintName("FK_Item_Staff");

            entity.HasOne(d => d.User).WithMany(p => p.Items)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Item_User");
        });

        modelBuilder.Entity<ItemType>(entity =>
        {
            entity.ToTable("ItemType");

            entity.Property(e => e.ItemTypeId)
                .ValueGeneratedNever()
                .HasColumnName("ItemTypeID");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.ItemTypeName)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.ToTable("Payment");

            entity.Property(e => e.PaymentId)
                .ValueGeneratedNever()
                .HasColumnName("PaymentID");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.Detail)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.ItemId).HasColumnName("ItemID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Item).WithMany(p => p.Payments)
                .HasForeignKey(d => d.ItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Payment_Item");

            entity.HasOne(d => d.User).WithMany(p => p.Payments)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Payment_User");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("Role");

            entity.Property(e => e.RoleId)
                .ValueGeneratedNever()
                .HasColumnName("RoleID");
            entity.Property(e => e.RoleName)
                .IsRequired()
                .HasMaxLength(50);
        });

        modelBuilder.Entity<Session>(entity =>
        {
            entity.ToTable("Session");

            entity.Property(e => e.SessionId)
                .ValueGeneratedNever()
                .HasColumnName("SessionID");
            entity.Property(e => e.BeginTime).HasColumnType("datetime");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.EndTime).HasColumnType("datetime");
            entity.Property(e => e.ItemTypeId).HasColumnName("ItemTypeID");
            entity.Property(e => e.SessionName)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.ItemType).WithMany(p => p.Sessions)
                .HasForeignKey(d => d.ItemTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Session_ItemType");
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.Property(e => e.StaffId)
                .ValueGeneratedNever()
                .HasColumnName("StaffID");
            entity.Property(e => e.AccountName)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Address)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.DateOfBirth).HasColumnType("datetime");
            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Phone)
                .IsRequired()
                .HasMaxLength(20);
            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.StaffName)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Role).WithMany(p => p.Staff)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Staff_Role");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("UserID");
            entity.Property(e => e.AccountName)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Address)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.CccdbackImage)
                .IsRequired()
                .HasColumnType("image")
                .HasColumnName("CCCDBackImage");
            entity.Property(e => e.CccdfrontImage)
                .IsRequired()
                .HasColumnType("image")
                .HasColumnName("CCCDFrontImage");
            entity.Property(e => e.Cccdnumber)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnName("CCCDNumber");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.DateOfBirth).HasColumnType("datetime");
            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Phone)
                .IsRequired()
                .HasMaxLength(20);
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            entity.Property(e => e.UserName)
                .IsRequired()
                .HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
