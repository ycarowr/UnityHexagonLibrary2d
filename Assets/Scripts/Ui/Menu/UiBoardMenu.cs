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
        [SerializeField] Canvas canvas;
        

        [Header("Buttons"), SerializeField] Button neighboursButton;

        [SerializeField] UiTileMapInputHandler uiTileMapInputHandler;

        Vector3Int Selection { get; set; }

        void OnRightClickTile(Vector3Int selection, Vector2 screenPoint)
        {
            var referenceResolution = canvas.GetComponent<CanvasScaler>().referenceResolution;
            var currentResolution = new Vector2(Screen.width, Screen.height);
            var factorResolution = currentResolution / referenceResolution;
            var rectSize = menu.rect.size;
            var offsetX = rectSize.x / 2;
            var offsetY = -rectSize.y / 2;
            menu.anchoredPosition = (screenPoint/factorResolution + new Vector2(offsetX, offsetY));
            Selection = selection;
            Show();
        }

        protected override void Start()
        {
            base.Start();
            neighboursButton.onClick.AddListener(OnPressNeighbours);
            diagonalDesButton.onClick.AddListener(OnPressDiagonalDes);
            diagonalAscButton.onClick.AddListener(OnPressDiagonalAsc);
            horizontalButton.onClick.AddListener(OnPressHorizontal);
            uiTileMapInputHandler.OnRightClickTile += OnRightClickTile;
        }

        void OnPressNeighbours()
        {
            var hexes = boardController.BoardManipulation.GetNeighbours(Selection);
            boardHighlight.Show(hexes);
            BackButton.Instance.Pop();
        }

        void OnPressDiagonalDes()
        {
            var selection = boardController.BoardManipulation.GetDiagonalDescendant(Selection, ABigLength);
            boardHighlight.Show(selection);
            BackButton.Instance.Pop();
        }

        void OnPressDiagonalAsc()
        {
            var selection = boardController.BoardManipulation.GetDiagonalAscendant(Selection, ABigLength);
            boardHighlight.Show(selection);
            BackButton.Instance.Pop();
        }

        void OnPressHorizontal()
        {
            var selection = boardController.BoardManipulation.GetHorizontal(Selection, ABigLength);
            boardHighlight.Show(selection);
            BackButton.Instance.Pop();
        }
    }
}