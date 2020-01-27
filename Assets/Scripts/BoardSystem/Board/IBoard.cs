using HexBoardGame.SharedData;

namespace HexBoardGame.Runtime.GameBoard
{
    /// <summary>
    ///     Interface of a runtime board. It has a shape with its Hex points, orientation and positions to store data.
    /// </summary>
    public interface IBoard
    {
        BoardDataShape DataShape { get; }
        Orientation Orientation { get; }
        Position[] Positions { get; }
        bool HasPosition(Hex point);
        Position GetPosition(Hex point);
    }
}