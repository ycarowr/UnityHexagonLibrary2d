using HexCardGame.SharedData;

namespace HexCardGame.Runtime.GameBoard
{
    /// <summary>
    ///     A board is composed by positions that are referenced by an HexCoordinate.
    ///     Positions can store the game data like monsters, itens, heroes, etc.
    /// </summary>
    public class Board : IBoard
    {
        public Board(BoardController controller, BoardDataShape dataShape, Orientation orientation)
        {
            Orientation = orientation;
            DataShape = dataShape;
            Controller = controller;
            GeneratePositions();
        }

        BoardController Controller { get; }
        public BoardDataShape DataShape { get; }
        public Orientation Orientation { get; }
        public Position[] Positions { get; private set; }

        public bool HasPosition(Hex point) => GetPosition(point) != null;

        public Position? GetPosition(Hex point)
        {
            foreach (var i in Positions)
                if (i.Point == point)
                    return i;

            return null;
        }

        public void GeneratePositions()
        {
            var positions = DataShape.GetHexPoints();
            Positions = new Position[positions.Length];
            for (var index = 0; index < positions.Length; index++)
            {
                var i = positions[index];
                Positions[index] = new Position(i);
            }

            OnCreateBoard();
        }

        void OnCreateBoard() => Controller.DispatchCreateBoard(this);
    }
}