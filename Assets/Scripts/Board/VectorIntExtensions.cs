using UnityEngine;

namespace HexCardGame.Runtime.GameBoard
{
    public static class VectorIntExtensions
    {
        public static Vector2Int AsVector2Int(this Vector3Int vector) => new Vector2Int(vector.x, vector.y);
        public static Vector3Int AsVector3Int(this Vector2Int vector) => new Vector3Int(vector.x, vector.y, 0);
    }
}