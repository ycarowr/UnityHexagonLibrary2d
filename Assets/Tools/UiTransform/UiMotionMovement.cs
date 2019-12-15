using UnityEngine;

namespace Tools.UiTransform
{
    public class UiMotionMovement : UiMotionBase
    {
        public UiMotionMovement(IUiMotionHandler handler) : base(handler)
        {
        }

        float Z { get; set; }

        public void Execute(Vector2 position, float speed, float delay, float z)
        {
            TeleportZ(z);
            base.Execute(position, speed, delay);
        }

        public void Teleport(Vector3 position) => Handler.transform.position = position;

        void TeleportZ(float z)
        {
            Z = z;
            var pos = Handler.transform.position;
            pos.z = z;
            Handler.transform.position = pos;
        }

        protected override void OnMotionEnds()
        {
            IsOperating = false;
            var target = Target;
            target.z = Handler.transform.position.z;
            Handler.transform.position = target;
            base.OnMotionEnds();
        }

        protected override void KeepMotion()
        {
            var current = (Vector2) Handler.transform.position;
            var amount = Speed * Time.deltaTime;
            var delta = !IsConstant
                ? Vector2.Lerp(current, Target, amount)
                : Vector2.MoveTowards(current, Target, amount);

            Handler.transform.position = delta;
            TeleportZ(Z);
        }

        protected override bool CheckFinalState()
        {
            var distance = (Vector2) Target - (Vector2) Handler.transform.position;
            return distance.magnitude <= Threshold;
        }
    }
}