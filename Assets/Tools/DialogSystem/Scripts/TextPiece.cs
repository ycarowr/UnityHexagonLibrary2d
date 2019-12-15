using UnityEngine;

namespace Tools.DialogSystem
{
    /// <summary>
    ///     A text piece inside the Dialog System.
    /// </summary>
    [CreateAssetMenu(menuName = "DialogSystem/TextPiece")]
    public class TextPiece : ScriptableObject
    {
        /// <summary>
        ///     Author of the text. Appears at the top.
        /// </summary>
        public string Author;

        /// <summary>
        ///     The buttons that interact with the Dialog System.
        /// </summary>
        public TextButton[] Buttons;

        /// <summary>
        ///     The sentence inside the box.
        /// </summary>
        [Multiline] public string Text;
    }
}