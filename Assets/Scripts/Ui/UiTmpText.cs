using TMPro;
using UnityEngine;

namespace Game.Ui
{
    [RequireComponent(typeof(TMP_Text))]
    public class UiTmpText : MonoBehaviour
    {
        TMP_Text _tmpText;

        void Awake() => _tmpText = GetComponent<TMP_Text>();

        protected void SetText(string s) => _tmpText.text = s;
    }
}