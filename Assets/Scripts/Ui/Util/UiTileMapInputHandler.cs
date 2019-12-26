using System;
using Tools.Input.Mouse;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;

namespace HexCardGame.UI
{
    [RequireComponent(typeof(IMouseInput)), RequireComponent(typeof(Tilemap)),
     RequireComponent(typeof(TilemapCollider2D)), RequireComponent(typeof(UiBoard))]
    public class UiTileMapInputHandler : MonoBehaviour
    {
        Camera Camera { get; set; }
        Tilemap TileMap { get; set; }
        UiBoard UiBoard { get; set; }
        IMouseInput Input { get; set; }
        public event Action<Vector3Int> OnClickTile = tile => { };
        public event Action<Vector3Int, Vector2> OnRightClickTile = (hex, screenPoint) => { };

        void OnPointerClick(PointerEventData eventData)
        {
            var screenPosition = eventData.position;
            var hex = ConvertPixelToCell(screenPosition);
            switch (eventData.button)
            {
                case PointerEventData.InputButton.Left:
                    OnClickTile.Invoke(hex);
                    break;
                case PointerEventData.InputButton.Right:
                    OnRightClickTile.Invoke(hex, screenPosition);
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

        Vector3Int ConvertPixelToCell(Vector2 screenPoint)
        {
            var worldPosition = Camera.ScreenToWorldPoint(screenPoint);
            var cell = TileMap.WorldToCell(worldPosition);
            return cell;
        }
    }
}