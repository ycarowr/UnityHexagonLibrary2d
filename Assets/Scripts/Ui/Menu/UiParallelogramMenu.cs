using HexCardGame.SharedData;
using UnityEngine;
using UnityEngine.UI;

namespace HexCardGame.UI
{
    public class UiParallelogramMenu : UiParentMenu
    {
        [SerializeField] Button confirmButton;
        [SerializeField] ParallelogramBoardData data;
        [SerializeField] Slider height;
        [SerializeField] Slider width;

        protected override void Awake()
        {
            base.Awake();
            confirmButton.onClick.AddListener(OnConfirm);
        }

        void OnConfirm()
        {
            data.width = (int) width.value;
            data.height = (int) height.value;
            boardController.SetBoarDataAndCreate(data);
        }
    }
}