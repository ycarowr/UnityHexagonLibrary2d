namespace HexCardGame.Runtime.GameBoard
{
    /// <summary>
    ///     A position in a real game most likely stores some sort of data.
    ///     Things like heroes, buildings, monsters, itens, etc. Be creative.
    ///     <remarks> If this structure grow consider make it a class and pool it, instead. </remarks>>
    /// </summary>
    public struct Position
    {
        /// <summary>
        ///     Any kind of data which can be positioned onto the board.
        ///     <remarks> Inherit this class to create itens, monsters and stuff to populate the board. </remarks>>
        /// </summary>
        public abstract class BaseData
        {
        
        }
        
        /// <summary>
        ///     The data in the board.
        ///     <remarks> Consider make it an Array if it can hold more than one single object. </remarks>>
        /// </summary>
        public BaseData Data { get; private set; } 
        public Hex Point { get; }
        public Position(Hex point, BaseData baseData = null)
        {
            Point = point;
            Data = baseData;
        }

        public void AddData(BaseData baseData) => Data = baseData;
        public void RemoveData(BaseData baseData) => Data = null;
        public bool HasData() => Data != null;
    }
}