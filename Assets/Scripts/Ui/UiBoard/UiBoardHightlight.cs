using System.Collections.Generic;
using Game.Ui;
using HexCardGame.Runtime;
using HexCardGame.Runtime.GameBoard;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace HexCardGame.UI
{
    public class UiBoardHightlight : UiEventListener, ICreateBoard<BoardElement>
    {
        readonly Dictionary<Hex, UiHoverParticleSystem> _highlights =
            new Dictionary<Hex, UiHoverParticleSystem>();

        [SerializeField] GameObject highlightTiles;
        Tilemap TileMap { get; set; }

        void ICreateBoard<BoardElement>.OnCreateBoard(IBoard<BoardElement> board)
        {
            foreach (var p in board.Positions)
            {
                var hex = p.Hex;
                var cell = hex.ToOffsetCoord();
                var worldPosition = TileMap.CellToWorld(cell);
                var highlight = Instantiate(highlightTiles, worldPosition, Quaternion.identity, transform)
                    .GetComponent<UiHoverParticleSystem>();
                highlight.name = hex.ToString();
                if (!_highlights.ContainsKey(hex))
                    _highlights.Add(hex, highlight);
            }
        }

        protected override void Awake()
        {
            base.Awake();
            TileMap = GetComponentInChildren<Tilemap>();
            Hide();
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