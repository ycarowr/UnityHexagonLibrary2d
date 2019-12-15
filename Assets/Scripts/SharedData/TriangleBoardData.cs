using System.Collections.Generic;
using HexCardGame.Runtime;
using UnityEngine;

namespace HexCardGame.SharedData
{
    [CreateAssetMenu(menuName = "Data/TriangleBoardData", fileName = "TriangleBoardData")]
    public class TriangleBoardData : BoardData
    {
        [Range(1, 10)] public int size;
        
        public override Hex[] GetHexPositions()
        {
            var positions = new List<Hex>();
            for (var x = 0; x <= size; x++)
            for (var y = 0; y <= size -x; y++)
                positions.Add(new Hex(x, y));

            return positions.ToArray();
        }
    }
}