namespace HexCardGame.Runtime
{
    public interface IBoardManipulation
    {
        Hex[] GetNeighbours(Hex hex);

//        Vector3Int[] Get(int x, int y);
//        Vector3Int[] GetVertical(int x, int y);
//        Vector3Int[] GetHorizontal(int x, int y);
        Hex[] GetAllDiagonalAscendant(Hex hex, int n);
//        Vector3Int[] GetDiagonalDescendent(int x, int y);
    }
}