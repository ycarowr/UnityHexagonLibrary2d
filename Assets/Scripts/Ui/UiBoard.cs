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
                var cell = GetOffsetFromCurrentLayout(hex);
                _register.Add(cell, hex);
                TileMap.SetTile(cell, test);
            }
        }

        /// <summary>
        ///     Unity by default makes use the R-Offset Odd to reference tiles inside a TileMap.
        /// </summary>
        public static Hex GetHexFromCurrentLayout(Vector3Int cell) =>
            OffsetCoordHelper.RoffsetToCube(OffsetCoord.Parity.Odd, new OffsetCoord(cell.x, cell.y));

        /// <summary>
        ///     Unity by default makes use the R-Offset Odd to reference tiles inside a TileMap.
        /// </summary>
        public static Vector3Int GetOffsetFromCurrentLayout(Hex hex) => hex.ToRoffsetOdd().ToVector3Int();
    }
}