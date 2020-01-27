using HexBoardGame.SharedData;
using UnityEngine;
using UnityEngine.UI;

namespace HexBoardGame.UI
{
    public class UiHexagonalMenu : UiParentMenu
    {
        [SerializeField] Button confirmButton;
        [SerializeField] HexagonalBoardDataShape dataShape;
        [SerializeField] Slider slider;

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
            dataShape.radius = (int) slider.value;
            boardController.SetBoarDataAndCreate(dataShape);
        }
    }
}