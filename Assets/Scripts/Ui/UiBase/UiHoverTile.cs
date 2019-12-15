using UnityEngine;
using UnityEngine.Tilemaps;

namespace HexCardGame.UI
{
    [RequireComponent(typeof(Tilemap))]
    public class UiHoverTile : MonoBehaviour, IUiInputElement
    {
        Camera Camera { get; set; }
        Tilemap TileMap { get; set; }
        UiHoverParticleSystem Hover { get; set; }
        Transform HoverTransform { get; set; }
        public bool IsShowing { get; private set; }

        public bool IsLocked { get; private set; }
        public void Lock() => IsLocked = true;
        public void Unlock() => IsLocked = false;

        void Awake()
        {
            Camera = Camera.main;
            TileMap = GetComponent<Tilemap>();
            Hover = GetComponentInChildren<UiHoverParticleSystem>();
            HoverTransform = Hover.transform;
        }

        void HideHover()
        {
            IsShowing = false;
            Hover.Hide();
        }

        void ShowHover(Vector3 position)
        {
            HoverTransform.position = position;
            Hover.Show();
        }

        void Update() => CalculateHoverPosition();

        void CalculateHoverPosition()
        {
            var mousePosition = Input.mousePosition;
            var worldHoverPosition = Camera.ScreenToWorldPoint(mousePosition);
            var cellPosition = TileMap.WorldToCell(worldHoverPosition);
            var hasTile = TileMap.HasTile(cellPosition);
            if (!hasTile)
            {
                HideHover();
                return;
            }

            var worldCellPosition = TileMap.CellToWorld(cellPosition);
            ShowHover(worldCellPosition);
        }
    }
}