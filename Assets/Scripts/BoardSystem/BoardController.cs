using System;
using HexCardGame.SharedData;
using UnityEngine;

namespace HexCardGame.Runtime.GameBoard
{
    public class BoardController : MonoBehaviour
    {
        public BoardData data;
        public IBoard Board { get; private set; }
        public IBoardManipulation BoardManipulation { get; private set; }
        public event Action<IBoard> OnCreateBoard = board => { };

        void Start() => CreateBoard();

        void CreateBoard()
        {
            Board = new Board(this, data);
            BoardManipulation = new BoardManipulationPointOddR(data);
        }

        public void DispatchCreateBoard(IBoard board) => OnCreateBoard(board);

        public void SetBoarDataAndCreate(BoardData boardData)
        {
            data = boardData;
            CreateBoard();
        }
    }
}