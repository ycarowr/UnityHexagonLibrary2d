namespace HexCardGame.Runtime.GameBoard
{
    public struct Position
    {
        public Hex Hex { get; }
        public Position(Hex hex) => Hex = hex;
    }
}