using System.Linq;
using HexCardGame.Runtime;
using UnityEngine;

namespace HexCardGame.SharedData
{
    public abstract class BoardData : ScriptableObject
    {
        //Hack using Linq to find the max/min points without doing the proper math
        public int MaxX => GetHexPoints().Max(hex => hex.q);
        public int MaxY => GetHexPoints().Max(hex => hex.r);
        public int MinX => GetHexPoints().Min(hex => hex.q);
        public int MinY => GetHexPoints().Min(hex => hex.r);
        public abstract Hex[] GetHexPoints();
    }
}