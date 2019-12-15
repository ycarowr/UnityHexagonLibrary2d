using UnityEngine;

namespace HexCardGame.Runtime.GameBoard
{
    public class Position<T> : IDataStorage<T> where T : class
    {
        public Hex Hex { get; }
        public Position(Hex hex) => Hex = hex;
        public bool HasData => Data != null;
        public T Data { get; private set; }
        public void SetData(T value) => Data = value;
    }
}