using TMPro;
using UnityEngine;

namespace Game.Ui
{
    [RequireComponent(typeof(TMP_Text))]
    public class UiTMP_TextListener : UiEventListener
    {
        protected TMP_Text TMPText;

        protected override void Awake()
        {
            base.Awake();
            TMPText = GetComponent<TMP_Text>();
        }

        protected void SetText(string s) => TMPText.text = s;
    }
}