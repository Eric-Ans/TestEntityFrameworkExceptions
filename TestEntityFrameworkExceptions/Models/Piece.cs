namespace TestEntityFrameworkExceptions.Models;

public class Piece {
    public Guid Id { get; set; }
}


public class Piece<TTypeMontant> : Piece {
    public List<TTypeMontant> Montants { get; set; }
}