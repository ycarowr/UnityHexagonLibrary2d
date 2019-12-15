using UnityEngine;

namespace HexCardGame.UI
{
    /// <summary> Enable and Disable a CanvasGroup. </summary>
    public interface IUiUserInput
    {
        void Disable();
        void Enable();
    }

    /// <summary> Class used to manage the UiUserInput upon a CanvasGroup. </summary>
    [RequireComponent(typeof(CanvasGroup))]
    public class UiUserInput : MonoBehaviour, IUiUserInput
    {
        CanvasGroup CanvasGroup { get; set; }

        void IUiUserInput.Disable() => CanvasGroup.interactable = false;

        void IUiUserInput.Enable() => CanvasGroup.interactable = true;

        void Awake() => CanvasGroup = GetComponent<CanvasGroup>();
    }
}