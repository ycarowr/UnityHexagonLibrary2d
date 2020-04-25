using UnityEngine;
using UnityEngine.UI;

namespace HexBoardGame.UI
{
    public class UiBoardMenu : UiParentMenu
    {
        private const float Width = 1920;
        private const float Height = 1080;
        private const int ABigLength = 12;
        [SerializeField] private UiBoardHightlight boardHighlight;
        [SerializeField] private Canvas canvas;
        [SerializeField] private Button diagonalAscButton;
        [SerializeField] private Button diagonalDesButton;
        [SerializeField] private Button horizontalButton;

        [SerializeField,
         Tooltip("Change the resolution to make the placement of the menu (it depends on the aspect ratio).")]
        private bool isSetResolution = true;

        [SerializeField] private RectTransform menu;


        [Header("Buttons"), SerializeField] private Button neighboursButton;

        [SerializeField] private UiTileMapInputHandler uiTileMapInputHandler;

        private Vector3Int Selection { get; set; }

        private void OnRightClickTile(Vector3Int selection, Vector2 screenPoint)
        {
            var referenceResolution = canvas.GetComponent<CanvasScaler>().referenceResolution;
            var currentResolution = new Vector2(Screen.width, Screen.height);
            var factorResolution = currentResolution / referenceResolution;
            var rectSize = menu.rect.size;
            var offsetX = rectSize.x / 2;
            var offsetY = -rectSize.y / 2;
            //TODO (Bug):
            //Demands Full HD resolution or any equivalent aspect ratio (1.77), otherwise the placement is done in a wrong way.
            menu.anchoredPosition = screenPoint / factorResolution + new Vector2(offsetX, offsetY);
            Selection = selection;
            Show();
        }

        protected override void Start()
        {
            base.Start();
            Hide();
            var delta = Mathf.Abs(Camera.main.aspect - Width / Height) > 0.001f;
            if (delta)
                Debug.LogError("Demands Full HD resolution or any equivalent aspect ratio (1.77). " +
                               "Otherwise the 'Right Click Menu' placement is done in a wrong way.");
            neighboursButton.onClick.AddListener(OnPressNeighbours);
            diagonalDesButton.onClick.AddListener(OnPressDiagonalDes);
            diagonalAscButton.onClick.AddListener(OnPressDiagonalAsc);
            horizontalButton.onClick.AddListener(OnPressHorizontal);
            uiTileMapInputHandler.OnRightClickTile += OnRightClickTile;
        }

        private void OnPressNeighbours()
        {
            var hexes = boardController.BoardManipulation.GetNeighbours(Selection);
            boardHighlight.Show(hexes);
            BackButton.Instance.Pop();
        }

        private void OnPressDiagonalDes()
        {
            var selection = boardController.BoardManipulation.GetDiagonalDescendant(Selection, ABigLength);
            boardHighlight.Show(selection);
            BackButton.Instance.Pop();
        }

        private void OnPressDiagonalAsc()
        {
            var selection = boardController.BoardManipulation.GetDiagonalAscendant(Selection, ABigLength);
            boardHighlight.Show(selection);
            BackButton.Instance.Pop();
        }

        private void OnPressHorizontal()
        {
            var selection = boardController.BoardManipulation.GetHorizontal(Selection, ABigLength);
            boardHighlight.Show(selection);
            BackButton.Instance.Pop();
        }
    }
}