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

    public Hex ToHex() => HexHelper.YOffsetToCubeEven(this);
    public Vector3Int ToVector3Int() => new Vector3Int(x, y, 0);
    public static implicit operator Vector3Int(OffsetCoord p) => new Vector3Int(p.x, p.y, 0);
    public static implicit operator Vector2Int(OffsetCoord p) => new Vector2Int(p.x, p.y);

    public override string ToString() => $"Offset: (x: {x}, y: {y})";
}