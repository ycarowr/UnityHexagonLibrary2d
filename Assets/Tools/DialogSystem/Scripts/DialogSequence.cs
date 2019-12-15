namespace Tools.DialogSystem
{
    public partial class DialogSystem
    {
        /// <summary>
        ///     Manages the <see cref="TextSequence" /> to show the current <see cref="TextPiece" />.
        /// </summary>
        class DialogSequence : DialogSubComponent
        {
            public DialogSequence(IDialogSystem system) : base(system)
            {
            }

            /// <summary>
            ///     Current displayed <see cref="TextSequence" />.
            /// </summary>
            public TextSequence Sequence { get; private set; }

            /// <summary>
            ///     Current index of the <see cref="TextPiece" />
            /// </summary>
            public int IndexPieces { get; private set; }

            public bool IsLast => Sequence.Sequence.Length - 1 == IndexPieces;

            public void SetSequence(TextSequence sequence)
            {
                IndexPieces = 0;
                Sequence = sequence;
                foreach (var piece in sequence.Sequence)
                foreach (var btn in piece.Buttons)
                    btn.SetDialog(DialogSystem);
            }

            /// <summary>
            ///     Resets the component.
            /// </summary>
            public void Reset()
            {
                IndexPieces = 0;
                Sequence = null;
            }

            /// <summary>
            ///     Gets the <see cref="TextPiece" /> in the <paramref name="index" /> position.
            /// </summary>
            /// <param name="index"></param>
            /// <returns></returns>
            public TextPiece Get(int index)
            {
                if (Sequence == null)
                    return null;

                return index < Sequence.Sequence.Length
                    ? Sequence.Sequence[index]
                    : null;
            }

            /// <summary>
            ///     Gets the current displayed <see cref="TextPiece" />.
            /// </summary>
            /// <returns></returns>
            public TextPiece GetCurrent() => Get(IndexPieces);

            /// <summary>
            ///     Gets the next displayed <see cref="TextPiece" />.
            /// </summary>
            /// <returns></returns>
            public TextPiece GetNext()
            {
                if (Sequence == null)
                    return null;

                ++IndexPieces;
                return GetCurrent();
            }
        }


        //-----------------------------------------------------------------------------------------
    }
}