using System.Collections.Generic;
using HexCardGame.Runtime;
using UnityEngine;

namespace HexCardGame.SharedData
{
    [CreateAssetMenu(menuName = "Data/ParallelogramData", fileName = "ParallelogramData")]
    public class ParallelogramBoardData : BoardData
    {
        [Range(-10, 10)] public int xMax;
        [Range(-10, 10)] public int xMin;
        [Range(-10, 10)] public int yMax;
        [Range(-10, 10)] public int yMin;
        readonly List<Hex> _points = new List<Hex>();

        public override Hex[] GetHexPoints()
        {
            _points.Clear();
            for (var q = xMin; q <= xMax; q++)
            for (var r = yMin; r <= yMax; r++)
                _points.Add(new Hex(q, r));

            return _points.ToArray();
        }
    }
}