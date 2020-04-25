using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Tools.Input.Mouse
{
    [RequireComponent(typeof(Collider2D))]
    public partial class UiMouseInputProvider : MonoBehaviour, IMouseInput
    {
        private Vector3 prevPosition;
        public DragDirection Direction => GetDragDirection();
        public Vector2 MousePosition => UnityEngine.Input.mousePosition;
        public bool IsTracking { get; private set; }

        public void StartTracking()
        {
            IsTracking = true;
        }

        public void StopTracking()
        {
            IsTracking = false;
        }

        private void Awake()
        {
            // Can be used with PhysicsRaycaster2D and Collider2D too.
            if (Camera.main.GetComponent<Physics2DRaycaster>() == null)
                throw new Exception(GetType() + " needs an " + typeof(Physics2DRaycaster) + " on the MainCamera");
        }

        private DragDirection GetDragDirection()
        {
            var currentPosition = UnityEngine.Input.mousePosition;
            var normalized = (currentPosition - prevPosition).normalized;
            prevPosition = currentPosition;

            if (normalized.x > 0)
                return DragDirection.Right;

            if (normalized.x < 0)
                return DragDirection.Left;

            if (normalized.y > 0)
                return DragDirection.Top;

            return normalized.y < 0 ? DragDirection.Down : DragDirection.None;
        }
    }
}