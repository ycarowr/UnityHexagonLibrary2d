using UnityEngine;

namespace HexCardGame.Runtime
{
    public interface IBoardManipulation
    {
        bool Exists(Vector3Int cell);
        Hex[] GetNeighbours(Vector3Int cell);
        Hex[] GetVertical(Vector3Int cell, int length);
        Hex[] GetHorizontal(Vector3Int cell, int length);
        Hex[] GetDiagonalAscendant(Vector3Int cell, int length);
        Hex[] GetDiagonalDescendant(Vector3Int cell, int length);
    }
}