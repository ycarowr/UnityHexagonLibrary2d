using UnityEngine;
using UnityEngine.Tilemaps;

namespace HexBoardGame.UI
{
    [RequireComponent(typeof(Tilemap))]
    public class UiHoverTile : MonoBehaviour
    {
        private Camera Camera { get; set; }
        private Tilemap TileMap { get; set; }
        private Transform HoverTransform { get; set; }
        private UiHoverParticleSystem Hover { get; set; }

        private void Awake()
        {
            Camera = Camera.main;
            TileMap = GetComponent<Tilemap>();
            Hover = GetComponentInChildren<UiHoverParticleSystem>();
            HoverTransform = Hover.transform;
        }

        private void HideHover()
        {
            Hover.Hide();
        }

        private void ShowHover(Vector3 position)
        {
            HoverTransform.position = position;
            Hover.Show();
        }

        private void Update()
        {
            CalculateHoverPosition();
        }

        private void CalculateHoverPosition()
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