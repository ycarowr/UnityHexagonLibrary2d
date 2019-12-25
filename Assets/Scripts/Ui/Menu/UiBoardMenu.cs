using UnityEngine;
using UnityEngine.UI;

namespace HexCardGame.UI
{
    public class UiBoardMenu : UiParentMenu
    {
        const int ABigLength = 12;
        [SerializeField] UiBoardHightlight boardHighlight;
        [SerializeField] Button diagonalAscButton;
        [SerializeField] Button diagonalDesButton;
        [SerializeField] Button horizontalButton;
        [SerializeField] RectTransform menu;

        [Header("Buttons"), SerializeField] Button neighboursButton;

        [SerializeField] UiTileMapInputHandler uiTileMapInputHandler;

        Vector3Int Selection { get; set; }

        void OnRightClickTile(Vector3Int selection, Vector2 screenPoint)
        {
            var rect = menu.rect;
            var offsetX = rect.size.x / 2;
            var offsetY = -rect.size.y / 2;
            menu.anchoredPosition = screenPoint + new Vector2(offsetX, offsetY);
            Selection = selection;
            Show();
        }

        void Awake()
        {
            neighboursButton.onClick.AddListener(OnPressNeighbours);
            diagonalDesButton.onClick.AddListener(OnPressDiagonalDes);
            diagonalAscButton.onClick.AddListener(OnPressDiagonalAsc);
            horizontalButton.onClick.AddListener(OnPressHorizontal);
            uiTileMapInputHandler.OnRightClickTile += OnRightClickTile;
            Hide();
        }

        void OnPressNeighbours()
        {
            var hexes = boardController.BoardManipulation.GetNeighbours(Selection);
            boardHighlight.Show(hexes);
            Hide();
        }

        void OnPressDiagonalDes()
        {
            var selection = boardController.BoardManipulation.GetDiagonalDescendant(Selection, ABigLength);
            boardHighlight.Show(selection);
            Hide();
        }

        void OnPressDiagonalAsc()
        {
            var selection = boardController.BoardManipulation.GetDiagonalAscendant(Selection, ABigLength);
            boardHighlight.Show(selection);
            Hide();
        }

        void OnPressHorizontal()
        {
            var selection = boardController.BoardManipulation.GetHorizontal(Selection, ABigLength);
            boardHighlight.Show(selection);
            Hide();
        }
    }
}