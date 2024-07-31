namespace TestEntityFrameworkExceptions.Models;

public class Facture : PieceDebitrice {
    /// <inheritdoc />
    public Facture() : base() {
    }

    public string Numero { get; set; } = null!;
}
