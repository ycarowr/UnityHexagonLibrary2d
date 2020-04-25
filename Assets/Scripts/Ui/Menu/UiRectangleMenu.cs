using HexBoardGame.SharedData;
using UnityEngine;
using UnityEngine.UI;

namespace HexBoardGame.UI
{
    public class UiRectangleMenu : UiParentMenu
    {
        [SerializeField] private Button confirmButton;
        [SerializeField] private RectBoardDataShape dataShape;
        [SerializeField] private Slider height;
        [SerializeField] private Slider width;

        protected override void Awake()
        {
            base.Awake();
            confirmButton.onClick.AddListener(OnConfirm);
        }

        protected override void Start()
        {
            base.Start();
            Hide();
        }

        private void OnConfirm()
        {
            dataShape.width = (int) width.value;
            dataShape.height = (int) height.value;
            boardController.SetBoarDataAndCreate(dataShape);
        }
    }
}