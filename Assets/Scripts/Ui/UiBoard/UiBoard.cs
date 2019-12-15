using Game.Ui;
using HexCardGame.Runtime;
using HexCardGame.Runtime.GameBoard;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace HexCardGame.UI
{
    public class UiBoard : UiEventListener, ICreateBoard<BoardElement>
    {
        [SerializeField] TileBase test;
        IBoard<BoardElement> CurrentBoard { get; set; }
        Tilemap TileMap { get; set; }

        void ICreateBoard<BoardElement>.OnCreateBoard(IBoard<BoardElement> board)
        {
            CurrentBoard = board;
            CreateBoardUi();
        }

        protected override void Awake()
        {
            base.Awake();
            TileMap = GetComponentInChildren<Tilemap>();
        }

        void CreateBoardUi()
        {
            foreach (var pos in CurrentBoard.Positions)
            {
                var hex = pos.Hex;
                var cell = HexHelper.YOffsetFromCubeEven(hex);
                TileMap.SetTile(cell, test);
                TileMap.CellToWorld(cell);
            }
        }
    }
}