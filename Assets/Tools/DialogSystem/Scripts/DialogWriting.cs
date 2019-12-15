using System.Collections;
using System.Text;
using TMPro;
using UnityEngine;

namespace Tools.DialogSystem
{
    public partial class DialogSystem
    {
        /// <summary>
        ///     Manages the writing of the Dialog System.
        /// </summary>
        class DialogWriting : DialogSubComponent
        {
            public DialogWriting(IDialogSystem system,
                TextMeshProUGUI sentence,
                TextMeshProUGUI author) : base(system)
            {
                Builder = new StringBuilder();
                AuthorText = author;
                SentenceText = sentence;
            }

            StringBuilder Builder { get; }
            int CharLength { get; set; }
            Coroutine WriteRoutine { get; set; }
            TextMeshProUGUI SentenceText { get; }
            TextMeshProUGUI AuthorText { get; }

            public void Write(string text, string author)
            {
                CharLength = 0;
                Builder.Length = 0;
                Builder.Append(text);
                AuthorText.text = author;
                if (!DialogSystem.IsOpened)
                    DialogSystem.Show();
                else
                    StartWriting();
            }

            //-----------------------------------------------------------------------------------------

            public void Clear()
            {
                Builder.Length = 0;
                SentenceText.text = string.Empty;
                AuthorText.text = string.Empty;
            }

            /// <summary>
            ///     Dispatches the loop to write the sentence.
            /// </summary>
            public void StartWriting()
            {
                if (WriteRoutine != null)
                {
                    DialogSystem.Monobehavior.StopCoroutine(WriteRoutine);
                    WriteRoutine = null;
                }

                if (Builder.Length <= 0)
                    return;

                StartCoroutine();
            }

            /// <summary>
            ///     Loop to write the sentence.
            /// </summary>
            /// <param name="delay"></param>
            /// <returns></returns>
            IEnumerator KeepWriting(float delay)
            {
                yield return new WaitForSeconds(delay);

                var aSentence = Builder.ToString();
                var subSentence = CharLength <= aSentence.Length
                    ? aSentence.Substring(0, CharLength)
                    : string.Empty;

                SentenceText.text = subSentence;
                ++CharLength;

                var hasEnded = CharLength > Builder.Length;
                if (!hasEnded)
                    StartCoroutine();
            }

            void StartCoroutine()
            {
                var delay = CalculateTime();
                WriteRoutine = DialogSystem.Monobehavior.StartCoroutine(KeepWriting(delay));
            }

            /// <summary>
            ///     Return the time necessary to wait according to the sentence length.
            /// </summary>
            /// <returns></returns>
            float CalculateTime() => Builder.Length / DialogSystem.Speed;
        }
    }
}