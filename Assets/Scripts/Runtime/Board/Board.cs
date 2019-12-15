using HexCardGame.SharedData;
using Tools.Patterns.Observer;
using UnityEngine;

namespace HexCardGame.Runtime.GameBoard
{
    [Event]
    public interface ICreateBoard<T> where T : class
    {
        void OnCreateBoard(IBoard<T> board);
    }

    public interface IBoard<T> : IBoardDataStorage<T> where T : class
    {
        Position<T>[] Positions { get; }
        bool HasPosition(int x, int y);
        Position<T> GetPosition(int x, int y);
        Position<T> GetPosition(Vector3Int position);
        void GeneratePositions();
    }

    public partial class Board<T> : IBoard<T> where T : class
    {
        public Board(BoardData data, IDispatcher dispatcher)
        {
            Dispatcher = dispatcher;
            Data = data;
            GeneratePositions();
        }

        IDispatcher Dispatcher { get; }
        public BoardData Data { get; }
        public Position<T>[] Positions { get; private set; }

        public void GeneratePositions()
        {
            var positions = Data.GetHexPositions();
            Positions = new Position<T>[positions.Length];
            for (var index = 0; index < positions.Length; index++)
            {
                var i = positions[index];
                Positions[index] = new Position<T>(i);
            }

            OnCreateBoard();
        }

        public bool HasPosition(int x, int y) => GetPosition(x, y) != null;
        public Position<T> GetPosition(Vector3Int p) => GetPosition(p.x, p.y);

        public Position<T> GetPosition(int x, int y)
        {
            foreach (var i in Positions)
            {
                if (i.Hex.x != x)
                    continue;
                if (i.Hex.y == y)
                    return i;
            }

            return null;
        }

        public void Clear() => GeneratePositions();

        void OnCreateBoard()
        {
            Dispatcher.Notify<ICreateBoard<T>>(i => i.OnCreateBoard(this));
        }
    }
}