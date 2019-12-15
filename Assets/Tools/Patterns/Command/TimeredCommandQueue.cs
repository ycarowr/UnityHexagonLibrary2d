using System.Collections;
using UnityEngine;

namespace Tools.Patterns.Command
{
    public class TimeredCommandQueue<T, T1> : CommandQueue<T, T1>
        where T : MonoBehaviour
        where T1 : Command
    {
        [Tooltip("Time until dequeue the next command.")] [SerializeField] [Range(0, 1f)]
        float dequeueTime = 0.5f;

        /// <summary> Whether the component is operating or not. </summary>
        public bool IsActive { get; private set; }

        public void Reset()
        {
            if (Enqueueing != null)
                StopCoroutine(Enqueueing);
            if (Dequeuing != null)
                StopCoroutine(Dequeuing);
            if (Priority != null)
                StopCoroutine(Priority);

            Enqueueing = null;
            Dequeuing = null;
            Priority = null;

            Commands.Clear();
        }

        #region Corotines

        Coroutine Enqueueing { get; set; }
        Coroutine Dequeuing { get; set; }
        Coroutine Priority { get; set; }

        #endregion

        #region Operations

        /// <summary> Enqueue a command after a determined amount of time. </summary>
        public void EnqueueWithDelay(T1 command, float timeToEnqueue) =>
            Enqueueing = StartCoroutine(TimeredEnqueue(command, timeToEnqueue));

        public override void Enqueue(T1 command)
        {
            base.Enqueue(command);
            IsActive = true;
            UnQueueAll();
        }

        public void UnQueueAll()
        {
            if (!IsEmpty)
                StartCoroutine(KeepDequeuing(0));
        }

        #endregion

        #region Corotines

        IEnumerator KeepDequeuing(float delay)
        {
            if (delay > 0)
                yield return new WaitForSeconds(delay);

            Dequeue();
            if (!IsEmpty)
                StartCoroutine(KeepDequeuing(dequeueTime));
            else
                IsActive = false;
        }

        IEnumerator TimeredEnqueue(T1 command, float time)
        {
            if (time > 0)
                yield return new WaitForSeconds(time);
            Enqueue(command);
        }

        #endregion
    }
}