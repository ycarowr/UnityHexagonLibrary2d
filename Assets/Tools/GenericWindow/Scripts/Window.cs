using System;
using UnityEngine;

namespace Tools.GenericWindow
{
    public class Window : MonoBehaviour
    {
        readonly int HideId = Animator.StringToHash("Hide");
        readonly int ShowId = Animator.StringToHash("Show");
        [SerializeField] Animator animator;
        public Action OnShown { get; set; } = () => { };
        public Action OnHidden { get; set; } = () => { };
        public bool IsShowing { get; private set; }

        //--------------------------------------------------------------------------------------------------------------

        [Button]
        public void Show()
        {
            if (IsShowing)
                return;

            IsShowing = true;
            animator?.Play(ShowId);
            OnShow();
        }

        [Button]
        public void Hide()
        {
            if (!IsShowing)
                return;

            IsShowing = false;
            animator?.Play(HideId);
            OnHide();
        }

        //--------------------------------------------------------------------------------------------------------------

        /// <summary> Executed immediately when the window opens. </summary>
        protected virtual void OnShow()
        {
            //Override to do something.
        }

        /// <summary> Executed immediately when the window closes. </summary>
        protected virtual void OnHide()
        {
            //Override to do something.
        }
    }
}