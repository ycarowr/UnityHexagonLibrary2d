using System.Collections.Generic;
using HexCardGame.Runtime;
using UnityEngine;

namespace HexCardGame.SharedData
{
    [CreateAssetMenu(menuName = "Data/ParallelogramData", fileName = "ParallelogramData")]
    public class ParallelogramBoardData : BoardData
    {
        [Range(-10, 10)] public int xMin;
        [Range(-10, 10)] public int xMax;
        [Range(-10, 10)] public int yMin;
        [Range(-10, 10)] public int yMax;
        
        public override Hex[] GetHexPositions()
        {
            var positions = new List<Hex>();
            for (var q = xMin; q <= xMax; q++)
            for (var r = yMin; r <= yMax; r++)
                positions.Add(new Hex(q, r));

            return positions.ToArray();
        }
    }
}