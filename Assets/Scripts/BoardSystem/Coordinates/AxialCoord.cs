using UnityEngine;

namespace HexBoardGame.Runtime
{
    public struct AxialCoord
    {
        public int q { get; }
        public int r { get; }

        public AxialCoord(int q, int r)
        {
            this.q = q;
            this.r = r;
        }

        public Hex ToCubic()
        {
            var x = q;
            var z = r;
            var y = -x - z;
            return new Hex(x, y, z);
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

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (GetType() != obj.GetType())
                return false;

            var other = (AxialCoord) obj;
            return q == other.q && r == other.r;
        }

        public Vector3Int ToVector3Int()
        {
            return new Vector3Int(q, r, 0);
        }
    }
}