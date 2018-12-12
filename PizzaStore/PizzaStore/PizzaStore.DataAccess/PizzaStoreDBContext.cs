using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PizzaStore.DataAccess
{
    public partial class PizzaStoreDBContext : DbContext
    {
        public PizzaStoreDBContext()
        {
        }

        public PizzaStoreDBContext(DbContextOptions<PizzaStoreDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ingredients> Ingredients { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Pizza> Pizza { get; set; }
        public virtual DbSet<PizzaIngredients> PizzaIngredients { get; set; }
        public virtual DbSet<PizzaOrder> PizzaOrder { get; set; }
        public virtual DbSet<Store> Store { get; set; }
        public virtual DbSet<UserLocation> UserLocation { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:tovar-server.database.windows.net,1433;Initial Catalog=PizzaStoreDB;Persist Security Info=False;User ID=axel;Password=6372140At;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=10;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<Ingredients>(entity =>
            {
                entity.ToTable("Ingredients", "PS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Ingredients)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Store_Ingredients");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.ToTable("Orders", "PS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ShopId).HasColumnName("ShopID");

                entity.Property(e => e.UserLocationId).HasColumnName("UserLocationID");

                entity.HasOne(d => d.Shop)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ShopId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Store_Address");

                entity.HasOne(d => d.UserLocation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserLocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_User_Address");
            });

            modelBuilder.Entity<Pizza>(entity =>
            {
                entity.ToTable("Pizza", "PS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CrustType)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.LinePrice).HasColumnType("money");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.PizzaIngredientId).HasColumnName("PizzaIngredientID");

                entity.HasOne(d => d.PizzaIngredient)
                    .WithMany(p => p.Pizza)
                    .HasForeignKey(d => d.PizzaIngredientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pizza_Ingredient_ID");
            });

            modelBuilder.Entity<PizzaIngredients>(entity =>
            {
                entity.ToTable("PizzaIngredients", "PS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IngredientId).HasColumnName("IngredientID");

                entity.HasOne(d => d.Ingredient)
                    .WithMany(p => p.PizzaIngredients)
                    .HasForeignKey(d => d.IngredientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pizza_Ingredients_ID");
            });

            modelBuilder.Entity<PizzaOrder>(entity =>
            {
                entity.ToTable("PizzaOrder", "PS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.PizzaId).HasColumnName("PizzaID");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.PizzaOrder)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_ID");

                entity.HasOne(d => d.Pizza)
                    .WithMany(p => p.PizzaOrder)
                    .HasForeignKey(d => d.PizzaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pizza_Order_ID");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.ToTable("Store", "PS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(128);
            });

            modelBuilder.Entity<UserLocation>(entity =>
            {
                entity.ToTable("UserLocation", "PS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserLocation)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Location");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("Users", "PS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100);
            });
        }
    }
}
