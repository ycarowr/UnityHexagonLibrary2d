using UnityEngine;

namespace HexCardGame.Runtime
{
    /// <summary>
    ///     Interface that manipulates a board shape.
    /// </summary>
    public interface IBoardManipulation
    {
        bool Contains(Vector3Int cell);
        Hex[] GetNeighbours(Vector3Int cell);
        Hex[] GetVertical(Vector3Int cell, int length);
        Hex[] GetHorizontal(Vector3Int cell, int length);
        Hex[] GetDiagonalAscendant(Vector3Int cell, int length);
        Hex[] GetDiagonalDescendant(Vector3Int cell, int length);

        //TODO:
        //1. Range
        //2. Path finding
        //3. More useful methods...
    }
}