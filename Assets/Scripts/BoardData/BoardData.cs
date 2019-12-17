using HexCardGame.Runtime;
using UnityEngine;

namespace HexCardGame.SharedData
{
    public abstract class BoardData : ScriptableObject
    {
        public abstract Hex[] GetHexPositions();
    }
}