using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Tools.DialogSystem
{
    public partial class DialogSystem : MonoBehaviour, IDialogSystem
    {
        [Tooltip("The text which contains the author content.")] [SerializeField]
        TextMeshProUGUI authorText;

        [Tooltip("Parent transform to hold all dialog buttons.")] [SerializeField]
        Transform buttonsAnchor;

        [Header("Set by Editor")] [Tooltip("All the window content.")] [SerializeField]
        GameObject content;

        [Tooltip("Parameters to configure the writing.")] [SerializeField]
        Parameters parameters;

        [Tooltip("The text which contains the written sentence.")] [SerializeField]
        TextMeshProUGUI sentenceText;

        // -----------------------------------------------------------------------------------------

        List<DialogButton> CurrentButtons { get; } = new List<DialogButton>();
        DialogAnimation Animation { get; set; }
        DialogWriting Writing { get; set; }
        DialogSequence Sequence { get; set; }
        public int Speed => parameters.speed;
        public bool IsOpened { get; private set; }
        public Action OnShow { get; set; } = () => { };
        public Action OnHide { get; set; } = () => { };
        public Action OnFinishSequence { get; set; } = () => { };
        public MonoBehaviour Monobehavior => this;

        protected void Awake()
        {
            Animation = new DialogAnimation(this);
            Writing = new DialogWriting(this, sentenceText, authorText);
            Sequence = new DialogSequence(this);
            OnShow += Writing.StartWriting;
            OnShow += () => CreateButtons(Sequence.GetCurrent());
            Hide();
        }

        //-----------------------------------------------------------------------------------------

        #region Write and Clear

        public void Write(TextSequence textSequence)
        {
            Sequence.SetSequence(textSequence);
            var current = Sequence.GetCurrent();
            if (current == null)
                return;

            var author = current.Author;
            var text = current.Text;
            Write(text, author);
        }

        void Write(string text, string author) => Writing.Write(text, author);


        #region Next

        public void Next()
        {
            if (!IsOpened)
                return;

            if (Sequence == null)
                return;

            if (Sequence.IsLast)
            {
                OnFinishSequence?.Invoke();
                Hide();
                return;
            }

            var current = Sequence?.GetCurrent();
            if (current == null)
                return;

            Clear();
            WriteNext();
        }

        void WriteNext()
        {
            var next = Sequence.GetNext();
            if (next == null)
                return;

            var author = next.Author;
            var text = next.Text;
            CreateButtons(next);
            Write(text, author);
        }

        #endregion

        void CreateButtons(TextPiece next)
        {
            foreach (var piece in next.Buttons)
            {
                var btn = piece.CreateButton(buttonsAnchor, this);
                CurrentButtons.Add(btn);
            }
        }

        [Button]
        public void Clear()
        {
            ClearButtons();
            Writing.Clear();
        }

        void ClearButtons()
        {
            for (var i = 0; i < CurrentButtons.Count; i++)
                Destroy(CurrentButtons[i].gameObject);

            CurrentButtons.Clear();
        }

        #endregion

        //-----------------------------------------------------------------------------------------

        #region Show and Hide

        [Button]
        public void Show()
        {
            Animation.Show();
            IsOpened = true;
        }

        [Button]
        public void Hide()
        {
            Animation.Hide();
            Sequence.Reset();
            IsOpened = false;
            Clear();
        }

        #endregion

        //-----------------------------------------------------------------------------------------

        #region Activate and Deactivate

        [Button]
        public void Activate() => content.SetActive(true);

        [Button]
        public void Deactivate()
        {
            content.SetActive(false);
            Hide();
        }

        #endregion

        //-----------------------------------------------------------------------------------------
    }
}