using System.Collections.Generic;
using HexCardGame.Runtime;
using UnityEngine;

namespace HexCardGame.SharedData
{
    [CreateAssetMenu(menuName = "Data/RectBoardData", fileName = "RectBoardData")]
    public class RectBoardData : BoardData
    {
        [Range(1, 10)] public int height;
        [Range(1, 10)] public int width;

        public override Hex[] GetHexPoints()
        {
            var points = new List<Hex>();
            for (var y = -height / 2; y < height / 2; y++)
            {
                var yOffset = y >> 1;
                for (var x = -yOffset; x < width - yOffset; x++)
                    points.Add(new Hex(x, y));
            }

            return points.ToArray();
        }
    }
}