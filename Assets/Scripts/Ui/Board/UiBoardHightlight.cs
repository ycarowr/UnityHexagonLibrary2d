using System.Collections.Generic;
using HexBoardGame.Runtime;
using HexBoardGame.Runtime.GameBoard;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace HexBoardGame.UI
{
    public class UiBoardHightlight : MonoBehaviour
    {
        private readonly Dictionary<Hex, UiHoverParticleSystem> _highlights =
            new Dictionary<Hex, UiHoverParticleSystem>();

        [SerializeField] private BoardController controller;
        [SerializeField] private GameObject highlightTiles;
        private Tilemap TileMap { get; set; }

        private void OnCreateBoard(IBoard board)
        {
            Hide();
            _highlights.Clear();
            foreach (var p in board.Positions)
            {
                var hex = p.Point;
                var cell = BoardManipulationOddR.GetCellCoordinate(hex);
                var worldPosition = TileMap.CellToWorld(cell);
                var highlight = Instantiate(highlightTiles, worldPosition, Quaternion.identity, transform)
                    .GetComponent<UiHoverParticleSystem>();
                highlight.name = hex.ToString();
                if (!_highlights.ContainsKey(hex))
                    _highlights.Add(hex, highlight);
            }
        }

        private void Awake()
        {
            TileMap = GetComponentInChildren<Tilemap>();
            controller.OnCreateBoard += OnCreateBoard;
        }

        private void Hide()
        {
            foreach (var i in _highlights.Values)
                i.Hide();
        }

        public void Show(Hex[] positions)
        {
            Hide();
            foreach (var i in positions)
                if (_highlights.ContainsKey(i))
                    _highlights[i].Show();
        }
    }
}