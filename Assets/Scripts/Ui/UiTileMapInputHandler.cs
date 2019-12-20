using System;
using HexCardGame.Runtime;
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
        public event Action<Hex> OnClickTile = tile => { };
        public event Action<Hex, Vector2> OnRightClickTile = (hex, screenPoint) => { };

        void OnPointerClick(PointerEventData eventData)
        {
            var screenPosition = eventData.position;
            var hex = ConvertPixelToHex(screenPosition);
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

        //TODO: Make a proper conversion. Currently a hash map is taking care of 
        //TODO: storing the pairs Cell - Hex, which demands a bit more memory allocation
        Hex ConvertPixelToHex(Vector2 screenPoint)
        {
            var worldPosition = Camera.ScreenToWorldPoint(screenPoint);
            var cell = TileMap.WorldToCell(worldPosition);
            var hex = UiBoard.GetHex(cell);
            return hex;
        }
    }
}