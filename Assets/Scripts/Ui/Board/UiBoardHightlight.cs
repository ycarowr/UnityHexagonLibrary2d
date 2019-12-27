using System.Collections.Generic;
using HexCardGame.Runtime;
using HexCardGame.Runtime.GameBoard;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace HexCardGame.UI
{
    public class UiBoardHightlight : MonoBehaviour
    {
        readonly Dictionary<Hex, UiHoverParticleSystem> _highlights =
            new Dictionary<Hex, UiHoverParticleSystem>();

        [SerializeField] BoardController controller;
        [SerializeField] GameObject highlightTiles;
        Tilemap TileMap { get; set; }

        void OnCreateBoard(IBoard board)
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

        void Awake()
        {
            TileMap = GetComponentInChildren<Tilemap>();
            controller.OnCreateBoard += OnCreateBoard;
        }

        void Hide()
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