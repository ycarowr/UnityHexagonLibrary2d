using UnityEngine;

namespace Tools.Shake
{
    public class ShakeAnimation : MonoBehaviour
    {
        [Tooltip("How big are the width and height of the shake.")] [SerializeField]
        float amplitude;

        [Tooltip("Duration of the shake in seconds")] [SerializeField]
        float duration;

        [Tooltip("How often the shake happens during its own duration. Value has to be smaller than the duration.")]
        [SerializeField]
        float frequency;

        Vector3 InitialPosition { get; set; }
        Transform CachedTransform { get; set; }
        bool IsShaking { get; set; }
        float CounterFrequency { get; set; }
        float CounterDuration { get; set; }

        void Awake() => CachedTransform = transform;

        void Update()
        {
            if (!IsShaking)
                return;

            UpdateShake();
        }

        /// <summary>
        ///     Method which starts the shake movement.
        /// </summary>
        [Button]
        public void Shake()
        {
            if (IsShaking)
                return;

            InitialPosition = CachedTransform.position;
            IsShaking = true;
        }

        /// <summary>
        ///     Clear the shake instantly.
        /// </summary>
        [Button]
        public void Stop()
        {
            IsShaking = false;
            CachedTransform.position = InitialPosition;
            ResetCounters();
        }

        /// <summary>
        ///     Clear all the shake counters.
        /// </summary>
        void ResetCounters()
        {
            CounterDuration = 0;
            CounterFrequency = 0;
        }

        void UpdateShake()
        {
            var deltaTime = Time.deltaTime;
            CounterDuration += deltaTime;
            if (CounterDuration >= duration)
            {
                Stop();
            }
            else
            {
                if (CounterFrequency < frequency)
                {
                    CounterFrequency += deltaTime;
                }
                else
                {
                    CachedTransform.position = InitialPosition + Random.insideUnitSphere * amplitude;
                    CounterFrequency = 0;
                }
            }
        }
    }
}