using System.Collections.Generic;
using Game.Ui;
using HexCardGame.Runtime;
using HexCardGame.Runtime.GameBoard;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace HexCardGame.UI
{
    public class UiBoard : UiEventListener, ICreateBoard<BoardElement>
    {
        readonly Dictionary<Vector3Int, Hex> _register = new Dictionary<Vector3Int, Hex>();
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
                var offset = hex.ToOffsetCoord();
                var cell = offset.ToVector3Int();
                _register.Add(cell, hex);
                TileMap.SetTile(cell, test);
                Debug.Log($"Add {hex} to cell {cell}");
            }
        }

        public Hex GetHex(Vector3Int cell)
        {
            Debug.Log(_register.Count);
            foreach (var VARIABLE in _register.Values) 
                Debug.Log(VARIABLE);
            Debug.Log("Get Cell value: "+cell);
            return _register[cell];
        }
    }
}