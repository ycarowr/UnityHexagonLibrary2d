using HexCardGame.Runtime.GameBoard;
using UnityEngine;
using UnityEngine.UI;

namespace HexCardGame.UI
{
    public abstract class UiParentMenu : MonoBehaviour
    {
        [Header("Dependencies"), SerializeField]
        protected BoardController boardController;

        [Header("Internal"), SerializeField] protected GameObject content;

        [SerializeField] protected Button hideButton;
        [SerializeField] protected Button showButton;

        [SerializeField] protected Button xButton;

        protected virtual void Awake()
        {
            if (showButton)
                showButton.onClick.AddListener(Show);
            if (hideButton)
                hideButton.onClick.AddListener(Hide);
            if (xButton)
                xButton.onClick.AddListener(Hide);
        }

        protected virtual void Start() => Hide();

        protected void Show()
        {
            content.SetActive(true);
            OnShow();
        }

        protected void Hide()
        {
            content.SetActive(false);
            OnHide();
        }

        protected virtual void OnHide()
        {
        }

        protected virtual void OnShow()
        {
        }
    }
}