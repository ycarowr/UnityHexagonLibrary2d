using HexBoardGame.SharedData;

namespace HexBoardGame.Runtime.GameBoard
{
    /// <summary>
    ///     A board is composed by positions that, by themselves, contain a HexCoordinate.
    ///     Positions may store the game data. Things like monsters, itens, heroes, etc.
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

        private BoardController Controller { get; }
        public BoardDataShape DataShape { get; }
        public Orientation Orientation { get; }
        public Position[] Positions { get; private set; }

        public bool HasPosition(Hex point)
        {
            return GetPosition(point) != null;
        }

        public Position GetPosition(Hex point)
        {
            foreach (var i in Positions)
                if (i.Point == point)
                    return i;

            return null;
        }

        private void GeneratePositions()
        {
            var points = DataShape.GetHexPoints();
            Positions = new Position[points.Length];
            for (var index = 0; index < points.Length; index++)
            {
                var i = points[index];
                Positions[index] = new Position(i);
            }

            OnCreateBoard();
        }

        private void OnCreateBoard()
        {
            Controller.DispatchCreateBoard(this);
        }
    }
}