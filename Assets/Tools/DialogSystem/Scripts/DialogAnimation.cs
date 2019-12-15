using UnityEngine;

namespace Tools.DialogSystem
{
    public partial class DialogSystem
    {
        /// <summary>
        ///     Controls the animations of the Dialog System.
        /// </summary>
        class DialogAnimation : DialogSubComponent
        {
            public DialogAnimation(IDialogSystem system) : base(system)
            {
                ShowHash = Animator.StringToHash("Show");
                HideHash = Animator.StringToHash("Hide");
                Animator = DialogSystem.Monobehavior.GetComponentInChildren<Animator>();
            }

            int ShowHash { get; }
            int HideHash { get; }
            Animator Animator { get; }

            public void Show()
            {
                if (!DialogSystem.IsOpened)
                    Animator.Play(ShowHash);
            }

            public void Hide()
            {
                if (DialogSystem.IsOpened)
                    Animator.Play(HideHash);
            }
        }
    }
}