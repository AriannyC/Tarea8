using Microsoft.EntityFrameworkCore;
using System.Drawing;
using System.Net;
using Tarea8.Models;

namespace Tarea8.Contex
{
    public class UserContex : DbContext
    {
        public UserContex(DbContextOptions<UserContex> options) : base(options) { }

        public DbSet<User> users { get; set; }
        public DbSet<RegiUs> RegiUss { get; set; }

        public DbSet<Proveedor> pro { get; set; }
        public DbSet<Categoria> cat { get; set; }
        public DbSet<Producto> prod { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //fluen Api

            #region tabla

            modelBuilder.Entity<User>().ToTable("user");
            modelBuilder.Entity<RegiUs>().ToTable("Regis");
            modelBuilder.Entity<Producto>().ToTable("Producto");
            modelBuilder.Entity<Categoria>().ToTable("Categoria");
            modelBuilder.Entity<Proveedor>().ToTable("Proveedor");



            #endregion

            #region "Primary Key"
            modelBuilder.Entity<User>().HasKey(User => User.Id);
            modelBuilder.Entity<RegiUs>().HasKey(User => User.IdR);
            modelBuilder.Entity<Proveedor>().HasKey(pr=> pr.Id);
            modelBuilder.Entity<Categoria>().HasKey(c => c.Id);
            modelBuilder.Entity<Producto>().HasKey(p=> p.Id);


            #endregion



            #region Relationship

            modelBuilder.Entity<Categoria>().HasMany<Producto>
                (category=> category.ProductosNC).WithOne
                (cat=> cat.CategoriaN).HasForeignKey
                (cat=>cat.IdCategoria).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Proveedor>().HasMany<Producto>(prove=> prove.ProductosN).WithOne
                (pro=> pro.ProveedorN).HasForeignKey(prove=>prove.IdProveedor).OnDelete(DeleteBehavior.Cascade);


            #endregion

            #region "Configuration"

            modelBuilder.Entity<User>().Property(User => User.Name).IsRequired();

            modelBuilder.Entity<User>().Property(User => User.Email).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<User>().Property(User => User.FechaN).IsRequired();



            #region proveedor

            modelBuilder.Entity<Proveedor>().Property(pro=> pro.Nombre).IsRequired();

            modelBuilder.Entity<Proveedor>().Property(pro => pro.Contacto).IsRequired();


            #endregion


            #region producto

            modelBuilder.Entity<Producto>().Property(pro => pro.Nombre).IsRequired();
            modelBuilder.Entity<Producto>().Property(pro => pro.Precio).IsRequired();


            #endregion

            #region categoria

            modelBuilder.Entity<Categoria>().Property(pro => pro.Nombre).IsRequired();

            #endregion



            #region "Configuration Regi"

            modelBuilder.Entity<RegiUs>().Property(User => User.Username).IsRequired();

            modelBuilder.Entity<RegiUs>().Property(User => User.Password).IsRequired().HasMaxLength(100);

            #endregion


            #endregion



        }
    }
}


