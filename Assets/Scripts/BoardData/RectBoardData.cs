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

        public override Hex[] GetHexPositions()
        {
            var positions = new List<Hex>();
            for (var y = 0; y < height; y++)
            {
                var yOffset = Mathf.FloorToInt(y / 2); // or r>>1
                for (var x = -yOffset; x < width - yOffset; x++) positions.Add(new Hex(x, y));
            }

            return positions.ToArray();
        }
    }
}