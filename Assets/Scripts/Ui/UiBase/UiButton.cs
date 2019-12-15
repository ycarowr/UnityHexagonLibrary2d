using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace HexCardGame.UI
{
    /// <summary> This interface says that it handles a button event</summary>
    public interface IButtonHandler
    {
    }

    public abstract class UiButton : MonoBehaviour
    {
        protected Button Button { get; set; }
        protected IButtonHandler Handler { get; private set; }

        /// <summary> Add more listeners to the button event. </summary>
        /// <param name="action"></param>
        public void AddListener(UnityAction action)
        {
            if (action == null)
                return;

            if (Button == null)
                Button = GetComponent<Button>();

            Button.onClick.AddListener(action);
        }

        public void RemoveListener(UnityAction action) => Button.onClick.RemoveListener(action);

        /// <summary> Inject a button handler to handle the press event. </summary>
        /// <param name="handler"></param>
        public void SetHandler(IButtonHandler handler)
        {
            Handler = handler ??
                      throw new ArgumentException("Can't assign a null handler to the button: " + gameObject.name);
            OnSetHandler(handler);
        }

        /// <summary> Override this function to implement the funcionality. </summary>
        /// <param name="handler"></param>
        protected abstract void OnSetHandler(IButtonHandler handler);
    }
}