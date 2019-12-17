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
        
        static FractionalHex pixel_to_hex(Vector2 p)
        {
            var orientation = Layout.orientation;
            var pt = new Vector2(
                (p.x - Layout.origin.x) / Layout.size.x,
                (p.y - Layout.origin.y) / Layout.size.y);
            var q = orientation.b0 * pt.x + orientation.b1 * pt.y;
            var r = orientation.b2 * pt.x + orientation.b3 * pt.y;
            return new FractionalHex(q, r);
        }
        
        
        public static OffsetCoord YOffsetFromCubeEven(Hex h) => YOffsetFromCube(Even, h);
        public static Hex YOffsetToCubeEven(OffsetCoord offset) => YOffsetToCube(Even, offset);
        public static Hex PixelToPointyHex(Vector2 screenPosition) => CubeRound(pixel_to_hex(screenPosition));

        struct FractionalHex
        {
            public float q { get; }
            public float r { get; }
            public float s { get; }

            public FractionalHex(float q, float r)
            {
                this.q = q;
                this.r = r;
                this.s = -q - r;
            }
        }

        struct Orientation
        {
            public float f0, f1, f2, f3;
            public float b0, b1, b2, b3;
            public float start_angle;
        }

        struct Layout
        {
            //pointy
            public static readonly Orientation orientation = new Orientation
            {
                f0 = Mathf.Sqrt(3.0f),
                f1 = Mathf.Sqrt(3.0f) / 2.0f,
                f2 = 0.0f,
                f3 = 3.0f / 2.0f,
                b0 = Mathf.Sqrt(3.0f) / 3.0f,
                b1 = -1.0f / 3.0f,
                b2 = 0.0f,
                b3 = 2.0f / 3.0f,
                start_angle = 0.5f
            };

            public static readonly Vector2 size = new Vector2(1.96f, 2.25f);
            public static readonly Vector2 origin = new Vector2();
        }

        static Hex CubeRound(FractionalHex fHex)
        {
            var q = Mathf.Round(fHex.q);
            var r = Mathf.Round(fHex.r);
            var s = Mathf.Round(fHex.s);

            var xDiff = Mathf.Abs(q - fHex.q);
            var yDiff = Mathf.Abs(r - fHex.r);
            var zDiff = Mathf.Abs(s - fHex.s);

            if (xDiff > yDiff && xDiff > zDiff)
                q = -r - s;
            else if (yDiff > zDiff)
                r = -q - s;
            else
                s = -q - r;

            return new Hex((int)q, (int)r, (int)s);
        }

        #endregion
    }
}