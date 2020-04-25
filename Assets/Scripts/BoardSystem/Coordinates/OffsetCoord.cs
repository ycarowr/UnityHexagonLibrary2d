using UnityEngine;

public struct OffsetCoord
{
    public enum Parity
    {
        Even = 1,
        Odd = -1
    }

    public int col { get; }
    public int row { get; }
    public Parity RowParity => (Parity) (row & 1);
    public bool IsOddRow => RowParity == Parity.Odd;

    public OffsetCoord(int col, int row)
    {
        this.col = col;
        this.row = row;
    }

    public Vector3Int ToVector3Int()
    {
        return new Vector3Int(col, row, 0);
    }

    public override string ToString()
    {
        return $"Offset: (x: {col}, y: {row})";
    }
}