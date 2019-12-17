using HexCardGame.SharedData;
using UnityEngine;

namespace HexCardGame.Runtime
{
    public class BoardManipulation : IBoardManipulation
    {
        readonly Hex[] _hexPositions;

        readonly Hex[] _neighbours =
        {
            new Hex(1, 0), new Hex(1, -1), new Hex(0, -1),
            new Hex(-1, 0), new Hex(-1, 1), new Hex(0, 1)
        };

        public BoardManipulation(BoardData data) => _hexPositions = data.GetHexPositions();

        public Hex[] GetNeighbours(Hex hex)
        {
            var neighbours = new Hex[] { };
            var center = Get(hex);
            foreach (var direction in _neighbours)
            {
                var neighbour = HexHelper.Add(center[0], direction);
                var array = new[] {neighbour};
                neighbours = neighbours.Merge(array);
            }

            return neighbours;
        }

        Hex[] Get(Hex hex)
        {
            foreach (var i in _hexPositions)
                if (i == hex)
                    return new[] {i};

            return new Hex[] { };
        }

        #region Sequence

        public Vector3Int[] GetVertical(Vector3Int direction, int n)
        {
            var vertical = new Vector3Int[n];
//            if (n > 0)
//            {
//                for (var i = 0; i <= n; i++)
//                    vertical = vertical.Merge(Get(x + i, y));
//            }
//            else
//            {
//                for (var i = 0; i <= -n; i++)
//                    vertical = vertical.Merge(Get(x - i, y));
//            }

            return vertical;
        }

        public Vector3Int[] GetAllDiagonalDescendant(Vector3Int direction, int n)
        {
            var diagDescendant = new Vector3Int[n];

//            if (n > 0)
//            {
//                var max = Mathf.Min(n, MaxX);
//                for (var i = 1; i <= max; i++)
//                    diagDescendant = diagDescendant.Merge(Get(x - i, y + i));
//            }
//            else
//            {
//                var max = Mathf.Min(x - n, MaxX);
//                for (var i = 0; i < max; i++)
//                    diagDescendant = diagDescendant.Merge(Get(x + i, y - i));
//            }

            return diagDescendant;
        }

        public Hex[] GetAllDiagonalAscendant(Hex hex, int n)
        {
            var diagAscendant = new Hex[n];
//            var x = position.x;
//            var y = position.y;
//
//            diagAscendant = diagAscendant.Merge(Get(x, y));
//
//            Hex[] positions;
//            for (var i = 1; i < 10; i++)
//            {
//                positions = Get(x - i, y + i);
//                if(positions != null)
//                    diagAscendant = diagAscendant.Merge(positions);
//            }
//
//            for (var i = 1; i < 10; i++)
//            {
//                positions = Get(x + i, y - i);
//                if(positions != null)
//                    diagAscendant = diagAscendant.Merge(positions);
//            }

            return diagAscendant;
        }

        #endregion
    }
}