using HexCardGame.Runtime.GameBoard;
using UnityEngine;
using UnityEngine.Assertions;

namespace HexCardGame.Runtime
{
    public static class HexHelper
    {
        public static Hex Add(Hex a, Hex b) => new Hex(a.x + b.x, a.y + b.y);
        public static Hex Subtract(Hex a, Hex b) => new Hex(a.x - b.x, a.y - b.y);
        public static Hex Multiply(Hex a, int k) => new Hex(a.x * k, a.y * k);
        public static int Distance(Hex a, Hex b) => Subtract(a, b).Length;


        #region Flat - Top
        
        public const int Even = -1;
        public const int Odd = 1;
        public static OffsetCoord XOffsetFromCube(int offset, Hex h)
        {
            Assert.IsTrue(offset == Even || offset == Odd);
            var col = h.x;
            var row = h.y + (h.x + offset * (h.x & 1)) / 2;
            return new OffsetCoord(col, row);
        }

        public static Hex XOffsetToCube(int offset, OffsetCoord h)
        {
            Assert.IsTrue(offset == Even || offset == Odd);
            var q = h.y;
            var r = h.x - (h.y + offset * (h.y & 1)) / 2;
            return new Hex(q, r);
        }

        #endregion
        
        #region Pointy - Top
        
        public static OffsetCoord YOffsetFromCube(int offset, Hex h)
        {
            Assert.IsTrue(offset == Even || offset == Odd);
            var parity = h.y & 1;
            var col = h.x + (h.y + offset * parity) / 2;
            var row = h.y;
            return new OffsetCoord(col, row);
        }

        public static Hex YOffsetToCube(int offset, OffsetCoord h)
        { 
            Assert.IsTrue(offset == Even || offset == Odd);
            var q = h.y - (h.x + offset * (h.x & 1)) / 2;
            var r = h.x;
            return new Hex(q, r);
        }

        public static Vector3Int YOffsetFromCubeEven(Hex h) => YOffsetFromCube(Even, h).ToVector3Int();

        #endregion
    }
}