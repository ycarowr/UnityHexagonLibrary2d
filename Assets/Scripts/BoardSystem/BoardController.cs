using System;
using HexCardGame.SharedData;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace HexCardGame.Runtime.GameBoard
{
    public class BoardController : MonoBehaviour
    {
        public BoardDataShape dataShape;
        [SerializeField] Tilemap tileMap;
        public IBoard Board { get; private set; }
        public IBoardManipulation BoardManipulation { get; private set; }
        public event Action<IBoard> OnCreateBoard = board => { };


        void Start() => CreateBoard();

        public void CreateBoardFlat()
        {
            tileMap.orientation = Tilemap.Orientation.YX;
            tileMap.layoutGrid.cellSwizzle = GridLayout.CellSwizzle.YXZ;
            Board = new Board(this, dataShape, Orientation.FlatTop);
        }

        public void CreateBoardPointy()
        {
            tileMap.orientation = Tilemap.Orientation.XY;
            tileMap.layoutGrid.cellSwizzle = GridLayout.CellSwizzle.XYZ;
            Board = new Board(this, dataShape, Orientation.PointyTop);
        }

        public void DispatchCreateBoard(IBoard board) => OnCreateBoard(board);

        public void SetBoarDataAndCreate(BoardDataShape boardDataShape)
        {
            dataShape = boardDataShape;
            CreateBoard();
        }

        public void CreateBoard()
        {
            //using the tile map orientation to define the default
            if (tileMap.orientation == Tilemap.Orientation.XY)
                CreateBoardPointy();
            else
                CreateBoardFlat();
            BoardManipulation = new BoardManipulationOddR(dataShape);
        }
    }
}