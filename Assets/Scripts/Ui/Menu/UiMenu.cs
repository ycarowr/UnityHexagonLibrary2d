using UnityEngine;
using UnityEngine.UI;

namespace HexCardGame.UI
{
    public class UiMenu : UiParentMenu
    {
        [SerializeField] Button[] buttons;
        [SerializeField] Toggle flatToggle;
        [SerializeField] Toggle pointyToggle;

        protected override void Awake()
        {
            base.Awake();
            foreach (var i in buttons)
                i.onClick.AddListener(Hide);
            flatToggle.onValueChanged.AddListener(OnFlatTogglePressed);
            pointyToggle.onValueChanged.AddListener(OnPointyTogglePressed);
        }

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