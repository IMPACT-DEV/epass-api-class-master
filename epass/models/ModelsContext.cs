using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using epass.modeles;

namespace epass.models
{
    public class ModelsContext : IdentityDbContext
    {
        
        public ModelsContext(DbContextOptions<ModelsContext> options)
            : base(options)
        {
        }

        public DbSet<Admin> Admin { get; set; }
        public DbSet<AdminRole> AdminRole { get; set; }
        public DbSet<Compte> Compte { get; set; }
        public DbSet<Devise> Devise { get; set; }
        public DbSet<EventLog> EventLog { get; set; }
        public DbSet<InfoCompte> InfoCompte { get; set; }
        public DbSet<Operation> Operation { get; set; }
        public DbSet<Paiement> Paiement { get; set; }
        public DbSet<Pays> Pays { get; set; }
        public DbSet<PieceIdentite> PieceIdentite { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<TypeOperation> TypeOperation { get; set; }
        public DbSet<UserPreference> UserPreference { get; set; }
        public DbSet<Ville> Ville { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>().Property(p => p.Id).ValueGeneratedOnAdd();
        }
    }
}
