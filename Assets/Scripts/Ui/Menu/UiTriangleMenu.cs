using HexBoardGame.SharedData;
using UnityEngine;
using UnityEngine.UI;

namespace HexBoardGame.UI
{
    public class UiTriangleMenu : UiParentMenu
    {
        [SerializeField] Button confirmButton;
        [SerializeField] TriangleBoardDataShape dataShape;
        [SerializeField] Slider size;

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
            dataShape.size = (int) size.value;
            boardController.SetBoarDataAndCreate(dataShape);
        }
    }
}