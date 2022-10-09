using DotNatrium.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNatrium.Helpers
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Compound> Compound {get; set;} = null!;
        public DbSet<Element> Element {get; set;} = null!;
        public DbSet<Data> Data {get; set;} = null!;
        public DbSet<RoleReaction> RoleReactions {get; set;} = null!;
        public DbSet<TypeMeasurement> TypeMeasurements {get; set;} = null!;
        public DbSet<CompoundElement> CompoundElement {get; set;} = null!;
        public DbSet<ChemicalReaction> ChemicalReactions {get; set;} = null!;
        public DbSet<ElementChemicalReaction> ElementChemicalReactions {get; set;} = null!;
        public DbSet<CompoundChemicalReaction> CompoundChemicalReactions {get; set;} = null!;

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region EntityChemicalReaction
            modelBuilder.Entity<ChemicalReaction>()
                .HasKey(cr => cr.Id);
            #endregion
            #region EntityData
            modelBuilder.Entity<Data>()
                .HasKey(d => d.Id);
            modelBuilder.Entity<Data>()
                .HasIndex(d => new { d.Name, d.Symbol})
                .IsUnique();
            #endregion
            #region EntityRoleReaction
            modelBuilder.Entity<RoleReaction>()
                .HasKey(rr => rr.Id);
            modelBuilder.Entity<RoleReaction>()
                .HasIndex(rr => rr.Name)
                .IsUnique();
            #endregion
            #region EntityTypeMeasturement
            modelBuilder.Entity<TypeMeasurement>()
                .HasKey(tm => tm.Id);
            modelBuilder.Entity<TypeMeasurement>()
                .HasIndex(tm => tm.Name)
                .IsUnique();
            #endregion
            #region EntityCompound
            modelBuilder.Entity<Compound>()
                .HasKey(c => c.Id);
            #endregion
            #region EnittyElement
            modelBuilder.Entity<Element>()
                .HasKey(e => e.Id);
            #endregion
            #region EntityCompundElement
            modelBuilder.Entity<CompoundElement>()
                .HasKey(ce => ce.Id);
            /*modelBuilder.Entity<CompoundElement>()
                .HasOne(ce => ce.Element)
                .WithMany()
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<CompoundElement>()
                .HasOne(ce => ce.Compound)
                .WithMany()
                .HasForeignKey(ce => ce.CompoundId);*/
            #endregion
            #region EntityElementChemicalReaction
            modelBuilder.Entity<ElementChemicalReaction>()
                .HasKey(ecr => ecr.Id);
            #endregion
            #region EntityCompoundChemicalReaction
            modelBuilder.Entity<CompoundChemicalReaction>()
                .HasKey(ccr => ccr.Id);
            #endregion

        }
    }
}