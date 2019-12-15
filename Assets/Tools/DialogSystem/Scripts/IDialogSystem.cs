using System;
using UnityEngine;

namespace Tools.DialogSystem
{
    /// <summary>
    ///     A dialog system interface.
    /// </summary>
    public interface IDialogSystem
    {
        /// <summary>
        ///     The monobehavior attached to the system.
        /// </summary>
        MonoBehaviour Monobehavior { get; }

        /// <summary>
        ///     OnShow Event.
        /// </summary>
        Action OnShow { get; set; }

        /// <summary>
        ///     OnHide Event.
        /// </summary>
        Action OnHide { get; set; }

        /// <summary>
        ///     OnHide Finish Sequence Event.
        /// </summary>
        Action OnFinishSequence { get; set; }

        /// <summary>
        ///     Tells whether the window is opened or not.
        /// </summary>
        bool IsOpened { get; }

        /// <summary>
        ///     Speed the text is written to the user.
        /// </summary>
        int Speed { get; }

        /// <summary>
        ///     Activate the gameobject.
        /// </summary>
        void Activate();

        /// <summary>
        ///     Deactivate the gameObject.
        /// </summary>
        void Deactivate();

        /// <summary>
        ///     Clear the text.
        /// </summary>
        void Clear();

        /// <summary>
        ///     Calls next text.
        /// </summary>
        void Next();

        /// <summary>
        ///     Writes a determined text sequence.
        /// </summary>
        /// <param name="textSequence"></param>
        void Write(TextSequence textSequence);

        /// <summary>
        ///     Shows the window in its last state.
        /// </summary>
        void Show();

        /// <summary>
        ///     Hides the window.
        /// </summary>
        void Hide();
    }
}