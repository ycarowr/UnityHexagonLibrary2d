using System.Collections;
using UnityEngine;

namespace Tools.FreezeFrame
{
    public class FreezeFrame : MonoBehaviour
    {
        [SerializeField] float delay;

        [SerializeField] [Tooltip("Target of the fixed framerate.")]
        uint fixedFrameRate = 60;

        [SerializeField] [Tooltip("Fix the framerate when the game starts.")]
        bool fixFrameRate = true;

        [SerializeField] int frozenCount;
        [SerializeField] float initialTimeScale;

        [SerializeField] [Tooltip("Whether the game is frozen or not.")]
        bool isFrozen;

        [Header("Test")] [SerializeField] float time;

        [SerializeField] [Tooltip("Duration in frames of the freeze.")]
        float totalFramesFrozen;

        void Start()
        {
            if (fixFrameRate)
                Application.targetFrameRate = (int) fixedFrameRate;
        }

        //------------------------------------------------------------------------------------------------------

        public void Freeze(float time, float delay)
        {
            if (isFrozen)
                return;

            totalFramesFrozen = time * Application.targetFrameRate;
            initialTimeScale = Time.timeScale;

            if (delay == 0)
                Freeze();
            else
                StartCoroutine(FreezeRoutine(delay));
        }

        [Button]
        public void Unfreeze()
        {
            frozenCount = 0;
            Time.timeScale = initialTimeScale;
            isFrozen = false;
        }


        void Update()
        {
            if (!isFrozen)
                return;

            frozenCount++;

            if (frozenCount >= totalFramesFrozen)
                Unfreeze();
        }

        IEnumerator FreezeRoutine(float delay)
        {
            yield return new WaitForSeconds(delay);
            Freeze();
        }

        void Freeze()
        {
            initialTimeScale = Time.timeScale;
            Time.timeScale = 0;
            isFrozen = true;
        }

        [Button]
        void TestFreeze() => Freeze(time, delay);
    }
}