using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TestEntityFrameworkExceptions.Models;

public class Prescription {
    public Guid Id { get; set; }
    public List<Transport> Transport { get; set; }
}

public class PrescriptionConfiguration : IEntityTypeConfiguration<Prescription> {
    /// <inheritdoc />
    public void Configure(EntityTypeBuilder<Prescription> builder) {
        builder
            .HasMany(e => e.Transport)
            .WithOne(e => e.Prescription)
            .OnDelete(DeleteBehavior.Restrict)
            ;
    }
}