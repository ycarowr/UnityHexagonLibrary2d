using System.Collections.Generic;
using HexCardGame.Runtime;
using HexCardGame.Runtime.GameBoard;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace HexCardGame.UI
{
    public class UiBoard : MonoBehaviour
    {
        readonly Dictionary<Vector3Int, Hex> _register = new Dictionary<Vector3Int, Hex>();
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
            foreach (var pos in CurrentBoard.Positions)
            {
                var hex = pos.Hex;
                var offset = hex.ToOffsetCoord();
                var cell = offset.ToVector3Int();
                _register.Add(cell, hex);
                TileMap.SetTile(cell, test);
            }
        }

        public Hex GetHex(Vector3Int cell) => _register[cell];
    }
}