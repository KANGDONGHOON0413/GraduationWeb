using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace GraduationWeb.Models.DB
{
    public partial class TableManager : DbContext
    {
        public TableManager()
        {
        }

        public TableManager(DbContextOptions<TableManager> options)
            : base(options)
        {
        }

        public virtual DbSet<TableMsg> TableMsg { get; set; }
        public virtual DbSet<TableOrder> TableOrder { get; set; }
        public virtual DbSet<TableReceipt> TableReceipt { get; set; }
        public virtual DbSet<TableSell> TableSell { get; set; }
        public virtual DbSet<TableUser> TableUser { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TableMsg>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Table_Msg");

                entity.Property(e => e.Msg)
                    .IsRequired()
                    .HasMaxLength(80);

                entity.Property(e => e.ProductName)
                    .HasColumnName("Product_Name")
                    .HasMaxLength(50);

                entity.Property(e => e.ProductNum).HasColumnName("Product_Num");

                entity.Property(e => e.ReceiverId)
                    .IsRequired()
                    .HasColumnName("Receiver_ID")
                    .HasMaxLength(30)
                    .IsFixedLength();
            });

            modelBuilder.Entity<TableOrder>(entity =>
            {
                entity.HasKey(e => e.OrderNum);

                entity.ToTable("Table_Order");

                entity.Property(e => e.OrderNum).HasColumnName("Order_Num");

                entity.Property(e => e.OrderTime)
                    .IsRequired()
                    .HasColumnName("Order_Time")
                    .HasMaxLength(30);

                entity.Property(e => e.OrdererAddress)
                    .IsRequired()
                    .HasColumnName("Orderer_Address")
                    .HasMaxLength(50);

                entity.Property(e => e.OrdererId)
                    .IsRequired()
                    .HasColumnName("Orderer_ID")
                    .HasMaxLength(20)
                    .IsFixedLength();

                entity.Property(e => e.OrdererName)
                    .IsRequired()
                    .HasColumnName("Orderer_Name")
                    .HasMaxLength(20);

                entity.Property(e => e.OrdererPhone)
                    .IsRequired()
                    .HasColumnName("Orderer_Phone")
                    .HasMaxLength(20)
                    .IsFixedLength();

                entity.Property(e => e.ProductName)
                    .HasColumnName("Product_Name")
                    .HasMaxLength(30);

                entity.Property(e => e.ProductNum).HasColumnName("Product_Num");

                entity.Property(e => e.SellNum).HasColumnName("Sell_Num");

                entity.Property(e => e.SellerId)
                    .IsRequired()
                    .HasColumnName("Seller_ID")
                    .HasMaxLength(20)
                    .IsFixedLength();

                entity.Property(e => e.TotalPay).HasColumnName("Total_Pay");

                entity.HasOne(d => d.SellNumNavigation)
                    .WithMany(p => p.TableOrder)
                    .HasForeignKey(d => d.SellNum)
                    .HasConstraintName("Relationship_Tbl_Sell_Sellnum_Tbl_Order");
            });

            modelBuilder.Entity<TableReceipt>(entity =>
            {
                entity.HasKey(e => e.OrderNum);

                entity.ToTable("Table_Receipt");

                entity.Property(e => e.OrderNum)
                    .HasColumnName("Order_Num")
                    .ValueGeneratedNever();

                entity.Property(e => e.CommitTime)
                    .HasColumnName("Commit_Time")
                    .HasMaxLength(30);

                entity.Property(e => e.OrderTime)
                    .IsRequired()
                    .HasColumnName("Order_Time")
                    .HasMaxLength(30);

                entity.Property(e => e.OrdererAddress)
                    .IsRequired()
                    .HasColumnName("Orderer_Address")
                    .HasMaxLength(60);

                entity.Property(e => e.OrdererId)
                    .IsRequired()
                    .HasColumnName("Orderer_ID")
                    .HasMaxLength(20)
                    .IsFixedLength();

                entity.Property(e => e.OrdererName)
                    .IsRequired()
                    .HasColumnName("Orderer_Name")
                    .HasMaxLength(30);

                entity.Property(e => e.OrdererPhone)
                    .IsRequired()
                    .HasColumnName("Orderer_Phone")
                    .HasMaxLength(30);

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasColumnName("Product_Name")
                    .HasMaxLength(30);

                entity.Property(e => e.ProductNum).HasColumnName("Product_Num");

                entity.Property(e => e.SellerId)
                    .IsRequired()
                    .HasColumnName("Seller_ID")
                    .HasMaxLength(20)
                    .IsFixedLength();

                entity.Property(e => e.SellerPhone)
                    .IsRequired()
                    .HasColumnName("Seller_Phone")
                    .HasMaxLength(30);

                entity.Property(e => e.TotalPay).HasColumnName("Total_Pay");
            });

            modelBuilder.Entity<TableSell>(entity =>
            {
                entity.HasKey(e => e.SellNum);

                entity.ToTable("Table_Sell");

                entity.Property(e => e.SellNum).HasColumnName("Sell_Num");

                entity.Property(e => e.ProductDescription)
                    .HasColumnName("Product_Description")
                    .HasMaxLength(100);

                entity.Property(e => e.ProductImage)
                    .HasColumnName("Product_Image")
                    .HasColumnType("image");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasColumnName("Product_Name")
                    .HasMaxLength(20);

                entity.Property(e => e.ProductNum).HasColumnName("Product_Num");

                entity.Property(e => e.ProductPrice).HasColumnName("Product_Price");

                entity.Property(e => e.SellerId)
                    .IsRequired()
                    .HasColumnName("Seller_ID")
                    .HasMaxLength(20)
                    .IsFixedLength();

                entity.HasOne(d => d.Seller)
                    .WithMany(p => p.TableSell)
                    .HasForeignKey(d => d.SellerId)
                    .HasConstraintName("Relationship_Tbl_User_ID_Tbl_Sell");
            });

            modelBuilder.Entity<TableUser>(entity =>
            {
                entity.ToTable("Table_User");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(20)
                    .IsFixedLength();

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.Email)
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.Property(e => e.Image).HasColumnType("image");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsFixedLength();

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(16)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
