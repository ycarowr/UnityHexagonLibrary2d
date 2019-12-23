using System.Collections.Generic;
using HexCardGame.Runtime;
using UnityEngine;

namespace HexCardGame.SharedData
{
    [CreateAssetMenu(menuName = "Data/BoardData", fileName = "HexagonalBoardData")]
    public class HexagonalBoardData : BoardData
    {
        [Range(0, 10)] public int radius;

        public override Hex[] GetHexPoints()
        {
            var points = new List<Hex>();
            for (var x = -radius; x <= radius; x++)
            {
                var yMin = Mathf.Max(-radius, -x - radius);
                var yMax = Mathf.Min(radius, -x + radius);
                for (var y = yMin; y <= yMax; y++)
                    points.Add(new Hex(x, y));
            }

            return points.ToArray();
        }
    }
}