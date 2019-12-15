using HexCardGame.Runtime;
using UnityEngine;

public struct OffsetCoord
{
    public int x { get; }
    public int y { get; }

    public OffsetCoord(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
    
    public Vector3Int ToVector3Int() => new Vector3Int(x, y, 0);
}