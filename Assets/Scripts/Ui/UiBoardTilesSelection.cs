using HexCardGame.Runtime;
using HexCardGame.Runtime.GameBoard;
using UnityEngine;
using UnityEngine.UI;

namespace HexCardGame.UI
{
    public class UiBoardTilesSelection : MonoBehaviour
    {
        [SerializeField] UiBoardHightlight boardHighlight;
        [SerializeField] GameObject content;
        [SerializeField] BoardController controller;
        [SerializeField] Button diagonalAscButton;
        [SerializeField] Button diagonalDesButton;
        [SerializeField] Button hideButton;
        [SerializeField] RectTransform menu;
        [SerializeField] Button neighboursButton;
        [SerializeField] UiTileMapInputHandler uiTileMapInputHandler;

        Hex Selection { get; set; }

        void OnRightClickTile(Hex hex, Vector2 screenPoint)
        {
            var rect = menu.rect;
            var offsetX = rect.size.x / 2;
            var offsetY = -rect.size.y / 2;
            menu.anchoredPosition = screenPoint + new Vector2(offsetX, offsetY);
            Selection = hex;
            Show();
        }

        void Awake()
        {
            hideButton.onClick.AddListener(Hide);
            neighboursButton.onClick.AddListener(OnPressNeighbours);
            diagonalDesButton.onClick.AddListener(OnPressDiagonalDes);
            diagonalAscButton.onClick.AddListener(OnPressDiagonalAsc);
            uiTileMapInputHandler.OnRightClickTile += OnRightClickTile;
            Hide();
        }

        void OnPressNeighbours()
        {
            var hexes = controller.BoardManipulation.GetNeighbours(Selection);
            boardHighlight.Show(hexes);
            Hide();
        }

        void OnPressDiagonalDes()
        {
            var selection = controller.BoardManipulation.GetDiagonalDescendant(Selection, 10);
            boardHighlight.Show(selection);
            Hide();
        }

        void OnPressDiagonalAsc()
        {
            var selection = controller.BoardManipulation.GetDiagonalAscendant(Selection, 10);
            boardHighlight.Show(selection);
            Hide();
        }


        void Show() => content.SetActive(true);
        void Hide() => content.SetActive(false);
    }
}