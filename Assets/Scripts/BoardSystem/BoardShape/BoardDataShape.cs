using HexBoardGame.Runtime;
using UnityEngine;

namespace HexBoardGame.SharedData
{
    public abstract class BoardDataShape : ScriptableObject
    {
        public abstract Hex[] GetHexPoints();
    }
}