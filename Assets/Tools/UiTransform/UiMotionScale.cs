using UnityEngine;

namespace Tools.UiTransform
{
    public class UiMotionScale : UiMotionBase
    {
        //--------------------------------------------------------------------------------------------------------------

        public UiMotionScale(IUiMotionHandler handler) : base(handler)
        {
        }

        //--------------------------------------------------------------------------------------------------------------

        protected override bool CheckFinalState()
        {
            var delta = Target - Handler.transform.localScale;
            return delta.magnitude <= Threshold;
        }

        protected override void OnMotionEnds()
        {
            Handler.transform.localScale = Target;
            IsOperating = false;
        }

        protected override void KeepMotion()
        {
            var current = Handler.transform.localScale;
            var amount = Time.deltaTime * Speed;
            Handler.transform.localScale = Vector3.Lerp(current, Target, amount);
        }
    }
}