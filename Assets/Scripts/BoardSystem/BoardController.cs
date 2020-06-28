using System;
using HexBoardGame.SharedData;
using Tools.Extensions.Arrays;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace HexBoardGame.Runtime.GameBoard
{
    public class BoardController : MonoBehaviour
    {
        public BoardDataShape boardShape;
        [SerializeField] private Tilemap tileMap;
        public IBoard Board { get; private set; }
        public IBoardManipulation BoardManipulation { get; private set; }
        public event Action<IBoard> OnCreateBoard = board => { };

        private void Start()
        {
            CreateBoard();
            
            var start = new Vector3Int(0, 0, 0);
            var end = new Vector3Int(3, 0, -3);
            var path = BoardManipulation.GetPathBreadthSearch(start, end);
            path.Print();
        }

        private void CreateBoard()
        {
            //using the tile map orientation to pick the default value
            if (tileMap.orientation == Tilemap.Orientation.XY)
                CreateBoardPointy();
            else
                CreateBoardFlat();
            BoardManipulation = new BoardManipulationOddR(boardShape);
        }

        public void SetBoarDataAndCreate(BoardDataShape boardDataShape)
        {
            boardShape = boardDataShape;
            CreateBoard();
        }

        public void CreateBoardFlat()
        {
            tileMap.orientation = Tilemap.Orientation.YX;
            tileMap.layoutGrid.cellSwizzle = GridLayout.CellSwizzle.YXZ;
            Board = new Board(this, boardShape, Orientation.FlatTop);
        }

        public void CreateBoardPointy()
        {
            tileMap.orientation = Tilemap.Orientation.XY;
            tileMap.layoutGrid.cellSwizzle = GridLayout.CellSwizzle.XYZ;
            Board = new Board(this, boardShape, Orientation.PointyTop);
        }

        public void DispatchCreateBoard(IBoard board)
        {
            OnCreateBoard(board);
        }
    }
}