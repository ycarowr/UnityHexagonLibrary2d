using UnityEngine;

namespace HexCardGame.Runtime
{
    public interface IBoardManipulation
    {
        Vector3Int[] GetNeighbours(int x, int y);
//        Vector3Int[] Get(int x, int y);
//        Vector3Int[] GetVertical(int x, int y);
//        Vector3Int[] GetHorizontal(int x, int y);
        Vector3Int[] GetAllDiagonalAscendant(Vector3Int position, int n);
//        Vector3Int[] GetDiagonalDescendent(int x, int y);
    }
}