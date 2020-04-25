using HexBoardGame.Runtime.GameBoard;
using UnityEngine;
using UnityEngine.UI;

namespace HexBoardGame.UI
{
    public abstract class UiParentMenu : MonoBehaviour, IBackHandler
    {
        [Header("Dependencies"), SerializeField]
        protected BoardController boardController;

        [Header("Internal"), SerializeField] protected GameObject content;

        [SerializeField] protected Button hideButton;
        [SerializeField] protected Button showButton;
        [SerializeField] protected Button xButton;

        public void Show()
        {
            BackButton.Instance.Push(this);
            content.SetActive(true);
            OnShow();
        }

        public void Back()
        {
            Hide();
        }

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