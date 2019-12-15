using System;
using HexCardGame.SharedData;
using Tools.Patterns.Observer;
using UnityEngine;

namespace HexCardGame.Runtime.GameBoard
{
    public class BoardController : MonoBehaviour
    {
        [SerializeField] EventsDispatcher dispatcher;
        public BoardData Data;
        public IBoard<BoardElement> Board { get; private set; }
        public IBoardManipulation BoardManipulation { get; private set; } 

        void Start()
        {
            Board = new Board<BoardElement>(Data, dispatcher);
            BoardManipulation = new BoardManipulation();
        }
    }
}