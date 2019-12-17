using System;
using HexCardGame.Runtime.GameBoard;
using UnityEngine;
using UnityEngine.Assertions;

namespace HexCardGame.Runtime
{
    public struct Hex : IComparable
    {
        public int x { get; } //column, X axis
        public int y { get; } //row, Y axis
        public int z { get; }

        public Hex(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public Hex(int x, int y)
        {
            this.x = x;
            this.y = y;
            z = -(x + y);
            Assert.AreEqual(0, z + x + y);
        }
        
        public OffsetCoord ToOffsetCoord() => HexHelper.YOffsetFromCubeEven(this);
        public int Length => (Mathf.Abs(x) + Mathf.Abs(y) + Mathf.Abs(z)) / 2;
        public static bool operator == (Hex a, Hex b) => a.x == b.x && a.y == b.y && a.z == b.z;
        public static bool operator != (Hex a, Hex b) => !(a == b);
        public int CompareTo(object obj)
        {
            var other = obj as Hex?;
            if (!other.HasValue)
                throw new ArgumentException($"Can't Compare {typeof(Hex)} with Null");

            var value = other.Value;
            var areEqual = value == this;
            if (areEqual)
                return 0;
            
            return value.Length > Length ? 1 : 0;
        }
        public override string ToString() => $"Hex: ({x}, {y}, {z})";
    }
}