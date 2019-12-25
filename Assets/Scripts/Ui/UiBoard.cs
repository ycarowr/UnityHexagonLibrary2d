using HexCardGame.Runtime;
using HexCardGame.Runtime.GameBoard;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace HexCardGame.UI
{
    public class UiBoard : MonoBehaviour
    {
        [SerializeField] BoardController controller;
        [SerializeField] TileBase test;
        IBoard CurrentBoard { get; set; }
        Tilemap TileMap { get; set; }

        void OnCreateBoard(IBoard board)
        {
            CurrentBoard = board;
            CreateBoardUi();
        }

        void Awake()
        {
            TileMap = GetComponentInChildren<Tilemap>();
            controller.OnCreateBoard += OnCreateBoard;
        }

        void CreateBoardUi()
        {
            TileMap.ClearAllTiles();
            foreach (var pos in CurrentBoard.Positions)
            {
                var hex = pos.Hex;
                var cell = BoardManipulationPointOddR.GetCellCoordinate(hex);
                TileMap.SetTile(cell, test);
            }
        }
    }
}