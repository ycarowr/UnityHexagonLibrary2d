using HexCardGame.Runtime;
using UnityEngine;

namespace HexCardGame.SharedData
{
    public abstract class BoardDataShape : ScriptableObject
    {
        public abstract Hex[] GetHexPoints();
    }
}