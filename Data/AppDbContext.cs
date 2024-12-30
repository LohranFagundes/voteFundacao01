using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AppVote01.Models;

namespace AppVote01.Data
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {
        }

        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<Candidato> Candidatos { get; set; }
        public DbSet<Voto> Votos { get; set; }
        public DbSet<Log> Logs { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.HasDefaultSchema("LOHRANDEV");

            //builder.Entity<Produto>()
            //    .Property(p => p.Preco)
            //    .HasColumnType("NUMBER(10,2)");

          //  Configurar nomes mais curtos para as tabelas do Identity
            foreach (var entity in builder.Model.GetEntityTypes())
            {
                var tableName = entity.GetTableName();
                if (tableName.StartsWith("AspNet") && tableName.Length >= 7)
                {
                    entity.SetTableName(tableName.Substring(6));
                }
            }

          //  Configurar nomes mais curtos para as constraints do Identity
            foreach (var foreignKey in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                var constraintName = foreignKey.GetConstraintName();
                if (constraintName.Length >= 30)
                {
                    foreignKey.SetConstraintName(constraintName.Substring(0, 30));
                }
            }
        }
    }
}