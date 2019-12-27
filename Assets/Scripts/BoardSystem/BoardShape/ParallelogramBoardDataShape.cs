using System.Collections.Generic;
using HexCardGame.Runtime;
using UnityEngine;

namespace HexCardGame.SharedData
{
    [CreateAssetMenu(menuName = "Data/ParallelogramData", fileName = "ParallelogramData")]
    public class ParallelogramBoardDataShape : BoardDataShape
    {
        readonly List<Hex> _points = new List<Hex>();
        [Range(2, 10)] public int height;
        [Range(2, 10)] public int width;

        public override Hex[] GetHexPoints()
        {
            var xMin = -width / 2;
            var xMax = width / 2;
            var yMin = -height / 2;
            var yMax = height / 2;
            _points.Clear();
            for (var q = xMin; q <= xMax; q++)
            for (var r = yMin; r <= yMax; r++)
                _points.Add(new Hex(q, r));

            return _points.ToArray();
        }
    }
}