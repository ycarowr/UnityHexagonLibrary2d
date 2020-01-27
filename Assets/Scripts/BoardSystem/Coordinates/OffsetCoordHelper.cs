using System;
using HexBoardGame.Runtime;

/// <summary>
///     Helper class that handles all the conversion from HexCoordinate to OffsetCoordinates.
/// </summary>
public static class OffsetCoordHelper
{
    public static OffsetCoord QoffsetFromCube(OffsetCoord.Parity offset, Hex h)
    {
        var col = h.q;
        var row = h.r + (h.q + (int) offset * (h.q & 1)) / 2;
        if (offset != OffsetCoord.Parity.Even && offset != OffsetCoord.Parity.Odd)
            throw new ArgumentException("offset must be EVEN (+1) or ODD (-1)");
        return new OffsetCoord(col, row);
    }

    public static Hex QoffsetToCube(OffsetCoord.Parity offset, OffsetCoord h)
    {
        var q = h.col;
        var r = h.row - (h.col + (int) offset * (h.col & 1)) / 2;
        var s = -q - r;
        if (offset != OffsetCoord.Parity.Even && offset != OffsetCoord.Parity.Odd)
            throw new ArgumentException("offset must be EVEN (+1) or ODD (-1)");
        return new Hex(q, r, s);
    }

    public static OffsetCoord RoffsetFromCube(OffsetCoord.Parity offset, Hex h)
    {
        var col = h.q + (h.r + (int) offset * (h.r & 1)) / 2;
        var row = h.r;
        if (offset != OffsetCoord.Parity.Even && offset != OffsetCoord.Parity.Odd)
            throw new ArgumentException("offset must be EVEN (+1) or ODD (-1)");
        return new OffsetCoord(col, row);
    }

    public static Hex RoffsetToCube(OffsetCoord.Parity offset, OffsetCoord h)
    {
        var q = h.col - (h.row + (int) offset * (h.row & 1)) / 2;
        var r = h.row;
        var s = -q - r;
        if (offset != OffsetCoord.Parity.Even && offset != OffsetCoord.Parity.Odd)
            throw new ArgumentException("offset must be EVEN (+1) or ODD (-1)");
        return new Hex(q, r, s);
    }
}