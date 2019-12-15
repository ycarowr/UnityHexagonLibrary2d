using TMPro;
using Tools.Extensions.GameObject;
using UnityEngine;

namespace HexCardGame.UI
{
    public class UiText : MonoBehaviour
    {
        readonly string defaultText = string.Empty;

        [Tooltip("Color of the text."), SerializeField]
        protected Color color = Color.black;

        [Tooltip("TMPro Component assigned by the Editor or Automatically on Awake.")]
        protected TextMeshProUGUI TmProText;

        protected virtual void Awake()
        {
            if (TmProText == null)
                TmProText = gameObject.GetOrAddComponent<TextMeshProUGUI>();

            TmProText.color = color;
            SetText(defaultText);
        }

        public virtual void SetText(string text) => TmProText.text = text;
    }
}