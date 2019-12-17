using Game.Ui;
using HexCardGame.Runtime;
using HexCardGame.Runtime.GameBoard;
using UnityEngine;
using UnityEngine.UI;

namespace HexCardGame.UI
{
    public class UiBoardTilesSelection : UiEventListener, IOnRightClickTile
    {
        [SerializeField] UiBoardHightlight boardHighlight;
        [SerializeField] GameObject content;
        [SerializeField] Button hideButton;
        [SerializeField] RectTransform menu;
        [SerializeField] Button neighboursButton;
        [SerializeField] Button diagonalAscButton;

        Vector3Int Selection { get; set; }

        void IOnRightClickTile.OnRightClickTile(Vector3Int cell, Vector2 screenPoint)
        {
            var rect = menu.rect;
            var offsetX = rect.size.x / 2;
            var offsetY = -rect.size.y / 2;
            menu.anchoredPosition = screenPoint + new Vector2(offsetX, offsetY);
            Debug.Log($"Tile Selected {cell}");
            Selection = cell;
            Show();
        }

        protected override void Awake()
        {
            base.Awake();
            hideButton.onClick.AddListener(Hide);
            neighboursButton.onClick.AddListener(OnPressNeighbours);
            diagonalAscButton.onClick.AddListener(OnPressDiagonalAsc);
            Hide();
        }

        void OnPressNeighbours()
        {
            var hex = FindObjectOfType<UiBoard>().GetHex(Selection);
            Debug.Log(hex);
            var hexes = FindObjectOfType<BoardController>().BoardManipulation.GetNeighbours(hex);
            boardHighlight.Show(hexes);
            Hide();
        }
        
        void OnPressDiagonalAsc()
        {
//            var selection = GameData.CurrentGameInstance.BoardManipulation.GetAllDiagonalAscendant(Selection, 10);
//            boardHighlight.Show(selection);
//            Hide();
        }


        void Show() => content.SetActive(true);
        void Hide() => content.SetActive(false);
    }
}