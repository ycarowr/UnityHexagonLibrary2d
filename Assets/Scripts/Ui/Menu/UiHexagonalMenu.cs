using HexCardGame.SharedData;
using UnityEngine;
using UnityEngine.UI;

namespace HexCardGame.UI
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

        void OnConfirm()
        {
            dataShape.radius = (int) slider.value;
            boardController.SetBoarDataAndCreate(dataShape);
        }
    }
}