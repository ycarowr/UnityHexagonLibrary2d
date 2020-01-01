using UnityEngine;
using UnityEngine.UI;

namespace HexCardGame.UI
{
    public class UiBoardMenu : UiParentMenu
    {
        const float Width = 1920;
        const float Height = 1080;
        const int ABigLength = 12;
        [SerializeField] [Tooltip("Change the resolution to make the placement of the menu (it depends on the aspect ratio).")]
        bool isSetResolution = true;
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
            //TODO (Bug):
            //Demands Full HD resolution or any equivalent aspect ratio (1.77), otherwise the placement is done in a wrong way.
            menu.anchoredPosition = (screenPoint/factorResolution + new Vector2(offsetX, offsetY));
            Selection = selection;
            Show();
        }

        protected override void Start()
        {
            base.Start();
            var delta = Mathf.Abs(Camera.main.aspect - Width / Height) > 0.001f;
            if(delta)
                Debug.LogError("Demands Full HD resolution or any equivalent aspect ratio (1.77). " +
                               "Otherwise the 'Right Click Menu' placement is done in a wrong way.");
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