namespace HexCardGame.Runtime.GameBoard
{
    /// <summary>
    ///     A position in a real game most likely stores some sort of data.
    ///     Things like heroes, buildings, monsters, itens, etc. Be creative.
    ///     <remarks> If this structure grow consider make it a class instead a struct. </remarks>>
    /// </summary>
    public struct Position
    {
        /// <summary>
        ///     The unit(s) in the board.
        ///     <remarks> Consider make an Array if it can hold more than one unit. </remarks>>
        /// </summary>
        public BoardUnit Unit { get; private set; } 
        public Hex Point { get; }
        public Position(Hex point, BoardUnit unit = null)
        {
            Point = point;
            Unit = unit;
        }

        public void AddUnit(BoardUnit unit) => Unit = unit;
        public void RemoveUnit(BoardUnit unit) => Unit = null;
        public bool HasUnit() => Unit != null;
    }

    /// <summary>
    ///     Any kind of unit which can be positioned inside the board.
    /// </summary>
    public abstract class BoardUnit
    {
        
    }
}