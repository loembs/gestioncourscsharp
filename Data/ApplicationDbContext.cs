using GestionCours.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionCours.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Etudiant>()
            .HasMany(a => a.Absences)
            .WithOne(d => d.Etudiant)
            .HasForeignKey(d => d.EtudiantId); 
        modelBuilder.Entity<Etudiant>()
            .HasMany(c => c.Courses)
            .WithOne(d => d.Etudiant)
            .HasForeignKey(d => d.EtudiantId); 

        modelBuilder.Entity<Course>()
         .HasOne(user => user.Etudiant)
         .WithOne(c => c.Courses)
         .HasForeignKey<Course>(c => c.CoursId); // Associer la clé étrangère à la colonne UserId dans la table Clients

         modelBuilder.Entity<Absence>()
         .HasOne(p => p.Etudiant)
         .WithMany(d => d.Absences)
         .HasForeignKey(p => p.EtudiantId);  // Associer la clé étrangère à la colonne DetteId dans la table Paiements
         
    }
    // Define your DbSet properties here.
    public DbSet<Etudiant> Clients { get; set; }
    public DbSet<Absence> Users { get; set; }
    public DbSet<Cours> Dettes { get; set; }
   

    /* 
        On ne peut pas augmenter la visibilité d'un attribut ou d'une méthode héritée

        * private (visible uniquement dans la classe elle même)

        * protected (visibile dans toutes les classes filles uniquement)

        * internal (visible dans le namespace)

        * public (visible partout)

        modelBuilder.Entity<Client>().ToTable("clients") => Changer le nom des tables
     */


}