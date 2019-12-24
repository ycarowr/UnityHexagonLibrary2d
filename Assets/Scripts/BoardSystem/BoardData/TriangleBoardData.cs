using System.Collections.Generic;
using HexCardGame.Runtime;
using UnityEngine;

namespace HexCardGame.SharedData
{
    [CreateAssetMenu(menuName = "Data/TriangleBoardData", fileName = "TriangleBoardData")]
    public class TriangleBoardData : BoardData
    {
        [Range(1, 10)] public int size;
        readonly List<Hex> _points = new List<Hex>();

        public override Hex[] GetHexPoints()
        {
            _points.Clear();

            var halfSize = size / 2;
            for (var x = -halfSize; x <= size; x++)
            for (var y = -halfSize; y <= halfSize -x; y++) 
                _points.Add(new Hex(x, y));
            return _points.ToArray();
        }
    }
}