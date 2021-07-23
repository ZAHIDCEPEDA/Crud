using Crud.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crud.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, UserRole,string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Registro> Registro { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Registro>(re =>{
                re.HasKey(z => z.Codigo);

                re.Property(z => z.Nombres)
                .HasMaxLength(100)
                .IsRequired()
                .IsUnicode(false);

                re.Property(z => z.Apellidos)
               .HasMaxLength(100)
               .IsRequired()
               .IsUnicode(false);

                re.Property(z => z.Direccion)
                .HasMaxLength(250)
                .IsRequired()
                .IsUnicode(false);

                re.Property(z => z.Estado)
                .IsRequired()
                .IsUnicode(false);
            });
        }
    }
}
