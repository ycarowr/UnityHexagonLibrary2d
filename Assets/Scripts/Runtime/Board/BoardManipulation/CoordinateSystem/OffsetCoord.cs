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
    static Vector3Int AsVector3Int(OffsetCoord offset) => new Vector3Int(offset.x, offset.y, 0);
    static Vector2Int AsVector2Int(OffsetCoord offset) => new Vector2Int(offset.x, offset.y);
    public static implicit operator Vector3Int(OffsetCoord p) => AsVector3Int(p);
    public static implicit operator Vector2Int(OffsetCoord p) => AsVector2Int(p);

    public override string ToString() => $"Offset: (x: {x}, y: {y})";
}