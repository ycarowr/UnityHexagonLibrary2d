using System.Collections.Generic;
using HexBoardGame.Runtime;
using UnityEngine;

namespace HexBoardGame.SharedData
{
    [CreateAssetMenu(menuName = "BoardShape/BoardData", fileName = "HexagonalBoardData")]
    public class HexagonalBoardDataShape : BoardDataShape
    {
        private readonly List<Hex> _points = new List<Hex>();
        [Range(0, 10)] public int radius;

        public override Hex[] GetHexPoints()
        {
            _points.Clear();
            for (var x = -radius; x <= radius; x++)
            {
                var yMin = Mathf.Max(-radius, -x - radius);
                var yMax = Mathf.Min(radius, -x + radius);
                for (var y = yMin; y <= yMax; y++)
                    _points.Add(new Hex(x, y));
            }

            return _points.ToArray();
        }
    }
}