using HexCardGame.SharedData;
using Tools.Extensions.Arrays;
using UnityEngine;

namespace HexCardGame.Runtime
{
    public class BoardManipulation : IBoardManipulation
    {
        readonly Hex[] _hexPositions;
        readonly int _max;
        readonly int _min;

        readonly Hex[] _neighbours =
        {
            new Hex(1, 0), new Hex(1, -1), new Hex(0, -1),
            new Hex(-1, 0), new Hex(-1, 1), new Hex(0, 1)
        };

        public BoardManipulation(BoardData data)
        {
            _hexPositions = data.GetHexPoints();
            _max = Mathf.Max(data.MaxX, data.MaxY);
            _min = Mathf.Min(data.MinY, data.MinY);
        }

        public Hex[] GetNeighbours(Hex hex)
        {
            var neighbours = new Hex[] { };
            var center = Get(hex);
            foreach (var direction in _neighbours)
            {
                var neighbour = Hex.Add(center[0], direction);
                var array = new[] {neighbour};
                neighbours = neighbours.Append(array);
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

        public Hex[] GetDiagonalAscendant(Hex center, int length)
        {
            var points = Get(center);
            var x = center.q;
            var y = center.r;

            //Upper part
            for (var i = 1; i <= _max; i++)
                points = points.Append(Get(new Hex(x + i, y + i)));

            //Bottom part
            for (var i = -1; i >= _min; i--)
                points = points.Append(Get(new Hex(x + i, y - i)));

            return points;
        }

        public Hex[] GetDiagonalDescendant(Hex center, int length)
        {
            Debug.Log("DES");
            var points = Get(center);
            points.Print("Points");
            var x = center.q;
            var y = center.r;

            //Upper part
            for (var i = 1; i <= _max; i++)
                points = points.Append(Get(new Hex(x - i, y + i)));

            points.Print("Points");
            //Bottom part
            for (var i = -1; i >= _min; i--)
                points = points.Append(Get(new Hex(x + i, y - i)));

            points.Print("Points");
            return points;
        }

        #endregion
    }
}