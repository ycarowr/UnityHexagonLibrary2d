using System;
using Tools.Input.Mouse;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;

namespace HexCardGame.UI
{
    [RequireComponent(typeof(IMouseInput)), RequireComponent(typeof(Tilemap)),
     RequireComponent(typeof(TilemapCollider2D))]
    public class UiTileMapInputHandler : MonoBehaviour
    {
        IMouseInput Input { get; set; }
        Tilemap TileMap { get; set; }
        Camera Camera { get; set; }
        UiBoard UiBoard { get; set; }
        public event Action<Vector3Int> OnClickTile = tile => { };
        public event Action<Vector3Int, Vector2> OnRightClickTile = (tile, screenPoint) => { };

        void OnPointerClick(PointerEventData eventData)
        {
            var screenPosition = eventData.position;
            var cell = PixelToCell(screenPosition);
            Debug.Log($"Screen: {screenPosition} {cell}");

            switch (eventData.button)
            {
                case PointerEventData.InputButton.Left:
                    OnClickTile(cell);
                    break;
                case PointerEventData.InputButton.Right:
                    OnRightClickTile(cell, screenPosition);
                    break;
            }
        }

        void Awake()
        {
            Camera = Camera.main;
            UiBoard = GetComponent<UiBoard>();
            TileMap = GetComponentInChildren<Tilemap>();
            Input = GetComponent<IMouseInput>();
            Input.OnPointerClick += OnPointerClick;
        }

        Vector3Int PixelToCell(Vector2 screenPoint)
        {
            var worldPosition = Camera.ScreenToWorldPoint(screenPoint);
            var cell = TileMap.WorldToCell(worldPosition);
            return cell;
        }
    }
}