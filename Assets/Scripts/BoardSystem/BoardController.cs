using System;
using HexCardGame.SharedData;
using UnityEngine;

namespace HexCardGame.Runtime.GameBoard
{
    public class BoardController : MonoBehaviour
    {
        public BoardData Data;
        public IBoard Board { get; private set; }
        public IBoardManipulation BoardManipulation { get; private set; }
        public event Action<IBoard> OnCreateBoard = board => { };

        void Start()
        {
            Board = new Board(this, Data);
            BoardManipulation = new BoardManipulationPointOddR(Data);
        }

        public void DispatchCreateBoard(IBoard board) => OnCreateBoard(board);
    }
}