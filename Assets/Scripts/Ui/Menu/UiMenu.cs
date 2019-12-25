using UnityEngine;
using UnityEngine.UI;

namespace HexCardGame.UI
{
    public class UiMenu : UiParentMenu
    {
        [SerializeField] Button[] buttons;

        protected override void Awake()
        {
            base.Awake();
            foreach (var i in buttons)
                i.onClick.AddListener(Hide);
        }
    }
}