using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TestEntityFrameworkExceptions.Models;

public class MontantDebiteur : Montant {
    public PieceDebitrice Piece { get; set; }
    public Guid PieceId { get; set; }
}

public class MontantDebiteurConfiguration : IEntityTypeConfiguration<MontantDebiteur> {
    /// <inheritdoc />
    public void Configure(EntityTypeBuilder<MontantDebiteur> builder) {
        builder
            .HasOne(e => e.Piece)
            .WithMany(e => e.Montants)
            .HasForeignKey(s => new { s.PieceId })
            .HasPrincipalKey(s => new { s.Id })
            ;
    }
}