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
        readonly Dictionary<Vector3Int, UiHoverParticleSystem> _highlights =
            new Dictionary<Vector3Int, UiHoverParticleSystem>();

        [SerializeField] GameObject highlightTiles;
        Tilemap TileMap { get; set; }

        void ICreateBoard<BoardElement>.OnCreateBoard(IBoard<BoardElement> board)
        {
            foreach (var p in board.Positions)
            {
                var v3IntPosition = HexHelper.YOffsetFromCubeEven(p.Hex);
                var worldPosition = TileMap.CellToWorld(v3IntPosition);
                var highlight = Instantiate(highlightTiles, worldPosition, Quaternion.identity, transform)
                    .GetComponent<UiHoverParticleSystem>();
                if (!_highlights.ContainsKey(p.Hex))
                    _highlights.Add(v3IntPosition, highlight);
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

        public void Show(Vector3Int[] positions)
        {
            Hide();
            foreach (var i in positions)
                if (_highlights.ContainsKey(i))
                    _highlights[i].Show();
        }
    }
}