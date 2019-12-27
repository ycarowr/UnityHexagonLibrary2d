using HexCardGame.Runtime.GameBoard;
using UnityEngine;
using UnityEngine.UI;

namespace HexCardGame.UI
{
    public abstract class UiParentMenu : MonoBehaviour, IBackHandler
    {
        [Header("Dependencies"), SerializeField]
        protected BoardController boardController;

        [Header("Internal"), SerializeField] protected GameObject content;

        [SerializeField] protected Button hideButton;
        [SerializeField] protected Button showButton;
        [SerializeField] protected Button xButton;

        protected virtual void Awake()
        {
            
        }

        protected virtual void Start()
        {
            if (showButton)
                showButton.onClick.AddListener(Show);
            if (hideButton)
                hideButton.onClick.AddListener(BackButton.Instance.Pop);
            if (xButton)
                xButton.onClick.AddListener(BackButton.Instance.Pop);
            Hide();
        }

        public void Show()
        {
            BackButton.Instance.Push(this);
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

        public void Back() => Hide();
    }
}