using HexCardGame.SharedData;
using UnityEngine;
using UnityEngine.UI;

namespace HexCardGame.UI
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

        void OnConfirm()
        {
            dataShape.size = (int) size.value;
            boardController.SetBoarDataAndCreate(dataShape);
        }
    }
}