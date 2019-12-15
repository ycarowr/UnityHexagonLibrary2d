using UnityEngine;

namespace Tools.UiTransform
{
    public class UiMotion : IUiMotion
    {
        public UiMotion(IUiMotionHandler handler)
        {
            Scale = new UiMotionScale(handler);
            Movement = new UiMotionMovement(handler);
            Rotation = new UiMotionRotation(handler);
        }

        public UiMotionBase Movement { get; }
        public UiMotionBase Rotation { get; }
        public UiMotionBase Scale { get; }

        public void Update()
        {
            Movement?.Update();
            Rotation?.Update();
            Scale?.Update();
        }

        public void RotateTo(Vector3 rotation, float speed) => Rotation?.Execute(rotation, speed);

        public void MoveTo(Vector3 position, float speed, float delay = 0) => Movement?.Execute(position, speed, delay);

        public void MoveToWithZ(Vector3 position, float speed, float z, float delay = 0) =>
            (Movement as UiMotionMovement)?.Execute(position, speed, delay, z);

        public void Teleport(Vector3 position) => (Movement as UiMotionMovement)?.Teleport(position);

        public void ScaleTo(Vector3 scale, float speed, float delay = 0) => Scale?.Execute(scale, speed, delay);
    }
}