using System;
using UnityEngine;
using UnityEngine.Assertions;

namespace HexBoardGame.Runtime
{
    public struct Hex : IComparable
    {
        public int q { get; } //column, X axis
        public int r { get; } //row, Y axis
        public int s { get; } //s = -(q + r), math is great
        public int Length => (Mathf.Abs(q) + Mathf.Abs(r) + Mathf.Abs(s)) / 2;

        //TODO: Maybe keep only one constructor to make things less confusing.
        public Hex(int q, int r)
        {
            this.q = q;
            this.r = r;
            s = -(q + r);
            Assert.AreEqual(0, s + q + r);
        }

        public Hex(int q, int r, int s)
        {
            this.q = q;
            this.r = r;
            this.s = s;
            Assert.AreEqual(0, s + q + r);
        }

        #region Operators

        public override string ToString()
        {
            return $"Hex: ({q}, {r}, {s})";
        }

        public static Hex Add(Hex a, Hex b)
        {
            return new Hex(a.q + b.q, a.r + b.r);
        }

        public static Hex Subtract(Hex a, Hex b)
        {
            return new Hex(a.q - b.q, a.r - b.r);
        }

        public static Hex Multiply(Hex a, int k)
        {
            return new Hex(a.q * k, a.r * k);
        }

        public static int Distance(Hex a, Hex b)
        {
            return Subtract(a, b).Length;
        }

        public static bool operator ==(Hex a, Hex b)
        {
            return a.q == b.q && a.r == b.r && a.s == b.s;
        }

        public static bool operator !=(Hex a, Hex b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (GetType() != obj.GetType())
                return false;

            var other = (Hex) obj;
            return q == other.q && r == other.r;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hash = 17;
                hash = hash * 23 + q.GetHashCode();
                hash = hash * 23 + r.GetHashCode();
                return hash;
            }
        }

        public int CompareTo(object obj)
        {
            var val = (Hex) obj;
            if (Equals(obj))
                return 0;

            var xComparison = q > val.q;
            var yComparison = r > val.r;

            if (xComparison)
                return 1;
            if (yComparison)
                return 1;

            return -1;
        }

        #endregion

        #region Conversion to other Coordinate Systems

        public AxialCoord ToAxialCoord()
        {
            return new AxialCoord(q, r);
        }

        public OffsetCoord ToQoffsetEven()
        {
            return OffsetCoordHelper.QoffsetFromCube(OffsetCoord.Parity.Even, this);
        }

        public OffsetCoord ToQoffsetOdd()
        {
            return OffsetCoordHelper.QoffsetFromCube(OffsetCoord.Parity.Odd, this);
        }

        public OffsetCoord ToRoffsetEven()
        {
            return OffsetCoordHelper.RoffsetFromCube(OffsetCoord.Parity.Even, this);
        }

        public OffsetCoord ToRoffsetOdd()
        {
            return OffsetCoordHelper.RoffsetFromCube(OffsetCoord.Parity.Odd, this);
        }

        #endregion
    }
}