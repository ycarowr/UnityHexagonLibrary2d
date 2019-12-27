namespace HexCardGame.Runtime.GameBoard
{
    /// <summary>
    ///     A position in a real game most likely stores some sort of data.
    ///     Things like heroes, buildings, monsters, itens, etc. Be creative.
    /// </summary>
    public struct Position
    {
        public Hex Point { get; }
        public Position(Hex point) => Point = point;

        //include the data here
    }
}