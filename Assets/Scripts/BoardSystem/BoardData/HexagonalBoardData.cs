using System.Collections.Generic;
using HexCardGame.Runtime;
using UnityEngine;

namespace HexCardGame.SharedData
{
    [CreateAssetMenu(menuName = "Data/BoardData", fileName = "HexagonalBoardData")]
    public class HexagonalBoardData : BoardData
    {
        readonly List<Hex> _points = new List<Hex>();
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

        public void SetRadius(int r) => radius = r;
    }
}