using HexCardGame.SharedData;
using UnityEngine;
using UnityEngine.UI;

namespace HexCardGame.UI
{
    public class UiHexagonalMenu : UiParentMenu
    {
        [SerializeField] Button confirmButton;
        [SerializeField] HexagonalBoardData data;
        [SerializeField] Slider slider;

        protected override void Awake()
        {
            base.Awake();
            confirmButton.onClick.AddListener(OnConfirm);
        }

        void OnConfirm()
        {
            data.SetRadius((int) slider.value);
            boardController.SetBoarDataAndCreate(data);
        }
    }
}