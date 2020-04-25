using UnityEngine;
using UnityEngine.UI;

namespace HexBoardGame.UI
{
    public class UiMenu : UiParentMenu
    {
        [SerializeField] private Button[] buttons;
        [SerializeField] private Toggle flatToggle;
        [SerializeField] private Toggle pointyToggle;
        [SerializeField] private Slider zoomSlider;
        private Camera MainCamera { get; set; }

        protected override void Awake()
        {
            zoomSlider.onValueChanged.AddListener(OnZoomChanged);
            flatToggle.onValueChanged.AddListener(OnFlatTogglePressed);
            pointyToggle.onValueChanged.AddListener(OnPointyTogglePressed);
            foreach (var i in buttons)
                i.onClick.AddListener(Hide);

            MainCamera = Camera.main;
            base.Awake();
        }

        protected override void Start()
        {
            base.Start();
            Hide();
        }

        private void OnZoomChanged(float value)
        {
            MainCamera.orthographicSize = value;
        }

        private void OnPointyTogglePressed(bool isEnabled)
        {
            if (isEnabled) boardController.CreateBoardPointy();
        }

        private void OnFlatTogglePressed(bool isEnabled)
        {
            if (isEnabled) boardController.CreateBoardFlat();
        }
    }
}