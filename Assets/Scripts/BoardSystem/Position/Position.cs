namespace HexBoardGame.Runtime.GameBoard
{
    /// <summary>
    ///     A position in a real game most likely stores some sort of data.
    ///     Things like heroes, buildings, monsters, itens, etc. Be creative.
    ///     <remarks> If this structure grow consider make it a class and pool it, instead. </remarks>
    ///     >
    /// </summary>
    public class Position
    {
        public Position(Hex point, BoardElement baseData = null)
        {
            Point = point;
            Data = baseData;
        }

        /// <summary>
        ///     The data in the board.
        ///     <remarks> Consider make it an Array if it can hold more than one single object. </remarks>>
        /// </summary>
        public BoardElement Data { get; private set; }

        public Hex Point { get; }

        public void AddData(BoardElement baseData)
        {
            Data = baseData;
        }

        public void RemoveData()
        {
            Data = null;
        }

        public bool HasData()
        {
            return Data != null;
        }
    }
}