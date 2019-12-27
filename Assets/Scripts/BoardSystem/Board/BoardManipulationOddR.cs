using HexCardGame.SharedData;
using Tools.Extensions.Arrays;
using UnityEngine;

namespace HexCardGame.Runtime
{
    public class BoardManipulationOddR : IBoardManipulation
    {
        static readonly Hex[] Neighbours =
        {
            new Hex(1, 0), new Hex(1, -1), new Hex(0, -1),
            new Hex(-1, 0), new Hex(-1, 1), new Hex(0, 1)
        };

        readonly Hex[] _hexPoints;

        public BoardManipulationOddR(BoardDataShape dataShape) => _hexPoints = dataShape.GetHexPoints();

        public Hex[] GetNeighbours(Vector3Int cell)
        {
            var point = GetHexCoordinate(cell);
            var center = GetIfExists(point);
            var neighbours = new Hex[] { };
            foreach (var direction in Neighbours)
            {
                var neighbour = Hex.Add(center[0], direction);
                var array = new[] {neighbour};
                neighbours = neighbours.Append(array);
            }

            return neighbours;
        }

        /// <summary>
        ///     If the points is present among the starting configuration returns it. Otherwise returns a empty array.
        /// </summary>
        Hex[] GetIfExists(Hex hex)
        {
            foreach (var i in _hexPoints)
                if (i == hex)
                    return new[] {i};

            return new Hex[] { };
        }

        #region Operations

        public bool Contains(Vector3Int cell)
        {
            var center = GetHexCoordinate(cell);
            return GetIfExists(center).Length > 0;
        }

        public Hex[] GetVertical(Vector3Int cell, int length) => new Hex[] { };

        public Hex[] GetHorizontal(Vector3Int cell, int length)
        {
            var center = GetHexCoordinate(cell);
            var halfLength = length / 2;
            var points = GetIfExists(center);
            var x = center.q;
            var y = center.r;

            for (var i = 1; i <= halfLength; i++)
                points = points.Append(GetIfExists(new Hex(x + i, y)));

            for (var i = -1; i >= -halfLength; i--)
                points = points.Append(GetIfExists(new Hex(x + i, y)));

            return points;
        }

        public Hex[] GetDiagonalAscendant(Vector3Int cell, int length)
        {
            var center = GetHexCoordinate(cell);
            var halfLength = length / 2;
            var points = GetIfExists(center);
            var x = center.q;
            var y = center.r;

            for (var i = 1; i <= halfLength; i++)
                points = points.Append(GetIfExists(new Hex(x, y + i)));

            for (var i = -1; i >= -halfLength; i--)
                points = points.Append(GetIfExists(new Hex(x, y + i)));

            return points;
        }

        public Hex[] GetDiagonalDescendant(Vector3Int cell, int length)
        {
            var center = GetHexCoordinate(cell);
            var halfLength = length / 2;
            var points = GetIfExists(center);
            var x = center.q;
            var y = center.r;

            for (var i = 1; i <= halfLength; i++)
                points = points.Append(GetIfExists(new Hex(x - i, y + i)));

            for (var i = -1; i >= -halfLength; i--)
                points = points.Append(GetIfExists(new Hex(x - i, y + i)));

            return points;
        }

        /// <summary>
        ///     Unity by default makes use the R-Offset Odd to reference tiles inside a TileMap.
        ///     Its called cell and is a Vector3Int.
        /// </summary>
        public static Hex GetHexCoordinate(Vector3Int cell) =>
            OffsetCoordHelper.RoffsetToCube(OffsetCoord.Parity.Odd, new OffsetCoord(cell.x, cell.y));

        /// <summary>
        ///     Unity by default makes use the R-Offset Odd to reference tiles inside a TileMap.
        ///     Its called cell and is a Vector3Int.
        /// </summary>
        public static Vector3Int GetCellCoordinate(Hex hex) =>
            OffsetCoordHelper.RoffsetFromCube(OffsetCoord.Parity.Odd, hex).ToVector3Int();

        #endregion
    }
}