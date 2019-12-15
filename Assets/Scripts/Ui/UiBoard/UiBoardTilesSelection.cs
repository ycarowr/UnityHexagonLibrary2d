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

        void IOnRightClickTile.OnRightClickTile(Vector3Int position, Vector2 screenPosition)
        {
            var rect = menu.rect;
            var offsetX = rect.size.x / 2;
            var offsetY = -rect.size.y / 2;
            menu.anchoredPosition = screenPosition + new Vector2(offsetX, offsetY);
            Selection = position;
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
            var selection = FindObjectOfType<BoardController>().BoardManipulation.GetNeighbours(Selection.x, Selection.y);
            boardHighlight.Show(selection);
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