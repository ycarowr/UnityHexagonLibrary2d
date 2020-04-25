using System.Collections.Generic;
using HexBoardGame.Runtime;
using UnityEngine;

namespace HexBoardGame.SharedData
{
    [CreateAssetMenu(menuName = "BoardShape/RectBoardData", fileName = "RectBoardData")]
    public class RectBoardDataShape : BoardDataShape
    {
        private readonly List<Hex> _points = new List<Hex>();
        [Range(1, 10)] public int height;
        [Range(1, 10)] public int width;

        public override Hex[] GetHexPoints()
        {
            _points.Clear();
            var halfHeight = height / 2;
            var halfWidth = width / 2;
            for (var y = -halfHeight; y < halfHeight; y++)
            {
                var fraction = y / 2f;
                var yOffset = Mathf.FloorToInt(fraction);

                for (var x = -yOffset - halfWidth; x < halfWidth - yOffset; x++)
                    _points.Add(new Hex(x, y));
            }

            return _points.ToArray();
        }
    }
}