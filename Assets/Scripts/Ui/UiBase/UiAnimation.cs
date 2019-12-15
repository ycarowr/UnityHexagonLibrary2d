using System.Collections;
using Game.Ui;
using UnityEngine;

namespace HexCardGame.UI
{
    public class UiAnimation : UiEventListener
    {
        protected static readonly int HashName = Animator.StringToHash("Animation");
        protected Animator Animator { get; set; }

        protected override void Awake()
        {
            base.Awake();
            Animator = GetComponent<Animator>();
        }

        protected virtual IEnumerator Animate(float delay = 0)
        {
            yield return new WaitForSeconds(delay);

            if (Animator != null)
                Animator.Play(HashName);
        }
    }
}