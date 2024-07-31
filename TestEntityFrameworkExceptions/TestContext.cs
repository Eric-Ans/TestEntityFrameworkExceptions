using EntityFramework.Exceptions.PostgreSQL;
using Microsoft.EntityFrameworkCore;
using TestEntityFrameworkExceptions.Models;

namespace TestEntityFrameworkExceptions;

public class TestContext : DbContext {
    public DbSet<Transport> Transports { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<Piece> Pieces { get; set; }
    public DbSet<Facture> Factures { get; set; }
    public DbSet<Avoir> Avoirs { get; set; }
    public DbSet<Montant> Montants { get; set; }
    public DbSet<MontantDebiteur> MontantsDebiteurs { get; set; }
    public DbSet<MontantCrediteur> MontantsCrediteurs { get; set; }

    public string DbPath { get; }

    public TestContext() {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "blogging.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MontantCrediteurConfiguration).Assembly);
        base.OnModelCreating(modelBuilder);
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        optionsBuilder.UseExceptionProcessor();
        optionsBuilder.UseSnakeCaseNamingConvention();
        optionsBuilder.UseNpgsql(@"Host=localhost;Username=test;Password=test;Database=TestEntityFrameworkExceptions");
    }
}