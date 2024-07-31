using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TestEntityFrameworkExceptions.Models;

public class MontantCrediteur : Montant {
    public PieceCreditrice Piece { get; set; }
    public Guid PieceId { get; set; }
}

public class MontantCrediteurConfiguration : IEntityTypeConfiguration<MontantCrediteur> {
    /// <inheritdoc />
    public void Configure(EntityTypeBuilder<MontantCrediteur> builder) {
        builder
            .HasOne(e => e.Piece)
            .WithMany(e => e.Montants)
            .HasForeignKey(s => new { s.PieceId })
            .HasPrincipalKey(s => new { s.Id })
            ;
    }
}