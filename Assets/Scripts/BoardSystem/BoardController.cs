using System;
using HexCardGame.SharedData;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace HexCardGame.Runtime.GameBoard
{
    public class BoardController : MonoBehaviour
    {
        public BoardData data;
        [SerializeField] Tilemap tileMap;
        public IBoard Board { get; private set; }
        public IBoardManipulation BoardManipulation { get; private set; }
        public event Action<IBoard> OnCreateBoard = board => { };


        void Start() => CreateBoard();

        public void CreateBoardFlat()
        {
            tileMap.orientation = Tilemap.Orientation.YX;
            tileMap.layoutGrid.cellSwizzle = GridLayout.CellSwizzle.YXZ;
            Board = new Board(this, data, Orientation.FlatTop);
            BoardManipulation = new BoardManipulationFlatOddR(data);
        }

        public void CreateBoardPointy()
        {
            tileMap.orientation = Tilemap.Orientation.XY;
            tileMap.layoutGrid.cellSwizzle = GridLayout.CellSwizzle.XYZ;
            Board = new Board(this, data, Orientation.PointyTop);
            BoardManipulation = new BoardManipulationPointOddR(data);
        }

        public void DispatchCreateBoard(IBoard board) => OnCreateBoard(board);

        public void SetBoarDataAndCreate(BoardData boardData)
        {
            data = boardData;
            CreateBoard();
        }

        public void CreateBoard()
        {
            if (tileMap.orientation == Tilemap.Orientation.XY)
                CreateBoardPointy();
            else
                CreateBoardFlat();
        }
    }
}