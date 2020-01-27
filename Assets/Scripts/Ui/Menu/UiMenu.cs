using UnityEngine;
using UnityEngine.UI;

namespace HexBoardGame.UI
{
    public class UiMenu : UiParentMenu
    {
        [SerializeField] Button[] buttons;
        [SerializeField] Toggle flatToggle;
        [SerializeField] Toggle pointyToggle;
        [SerializeField] Slider zoomSlider;
        Camera MainCamera { get; set; }

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

        void OnZoomChanged(float value) => MainCamera.orthographicSize = value;

        void OnPointyTogglePressed(bool isEnabled)
        {
            if (isEnabled) boardController.CreateBoardPointy();
        }

        void OnFlatTogglePressed(bool isEnabled)
        {
            if (isEnabled) boardController.CreateBoardFlat();
        }
    }
}