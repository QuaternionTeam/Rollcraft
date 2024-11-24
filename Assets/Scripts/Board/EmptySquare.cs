public class EmptySquare : Square
{
    internal override bool Walkable() => true;

    internal override void OnMouseDown() { }

    internal override SquareType Type() => SquareType.Empty;
}
