using System;
using System.Collections;
using UnityEngine;

namespace Tools.UiTransform
{
    public abstract class UiMotionBase
    {
        /// <summary> Dispatches when the motion ends </summary>
        public Action OnFinishMotion = () => { };

        //--------------------------------------------------------------------------------------------------------------

        protected UiMotionBase(IUiMotionHandler handler) => Handler = handler.MonoBehaviour;

        /// <summary> Whether the component is still operating or not. </summary>
        public bool IsOperating { get; protected set; }

        /// <summary> Limit magnitude until the reaches the target completely. </summary>
        protected virtual float Threshold { get; private set; } = 0.01f;

        /// <summary> Target of the motion. </summary>
        protected Vector3 Target { get; set; }

        /// <summary> Reference for the card. </summary>
        protected MonoBehaviour Handler { get; }

        /// <summary> Speed which the it moves towards the Target. </summary>
        protected float Speed { get; set; }

        /// <summary> Is the movement constant. </summary>
        public bool IsConstant { get; set; }

        public void SetThreshold(float threshold) => Threshold = threshold;

        public void Update()
        {
            if (!IsOperating)
                return;

            if (CheckFinalState())
                OnMotionEnds();
            else
                KeepMotion();
        }

        /// <summary> Check if it has reached the threshold. </summary>
        protected abstract bool CheckFinalState();

        /// <summary> Ends the motion and dispatch motion ends. </summary>
        protected virtual void OnMotionEnds() => OnFinishMotion?.Invoke();

        /// <summary> Keep the motion on update. </summary>
        protected abstract void KeepMotion();

        /// <summary> Execute the motion with the parameters. </summary>
        public virtual void Execute(Vector3 vector, float speed, float delay = 0)
        {
            Speed = speed;
            Target = vector;

            //TODO: Bad float compare 
            if (delay == 0)
                IsOperating = true;
            else
                Handler.StartCoroutine(AllowMotion(delay));
        }

        /// <summary> Used to delay the Motion. </summary>
        IEnumerator AllowMotion(float delay)
        {
            yield return new WaitForSeconds(delay);
            IsOperating = true;
        }

        /// <summary> Stop the motion. It won't trigger OnFinishMotion.</summary>
        /// TODO: Cancel the Delay Coroutine.
        public virtual void StopMotion() => IsOperating = false;
    }
}