using HexBoardGame.SharedData;
using UnityEngine;
using UnityEngine.UI;

namespace HexBoardGame.UI
{
    public class UiRectangleMenu : UiParentMenu
    {
        [SerializeField] Button confirmButton;
        [SerializeField] RectBoardDataShape dataShape;
        [SerializeField] Slider height;
        [SerializeField] Slider width;

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

        void OnConfirm()
        {
            dataShape.width = (int) width.value;
            dataShape.height = (int) height.value;
            boardController.SetBoarDataAndCreate(dataShape);
        }
    }
}