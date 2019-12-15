using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Tools.Input.Mouse
{
    public enum DragDirection
    {
        None,
        Down,
        Left,
        Top,
        Right
    }

    /// <summary>
    ///     Interface for all Unity Mouse Input System.
    /// </summary>
    public interface IMouseInput :
        IPointerClickHandler,
        IBeginDragHandler,
        IDragHandler,
        IEndDragHandler,
        IDropHandler,
        IPointerDownHandler,
        IPointerUpHandler,
        IPointerEnterHandler,
        IPointerExitHandler
    {
        Vector2 MousePosition { get; }
        DragDirection Direction { get; }
        bool IsTracking { get; }

        //clicks
        new Action<PointerEventData> OnPointerClick { get; set; }
        new Action<PointerEventData> OnPointerDown { get; set; }
        new Action<PointerEventData> OnPointerUp { get; set; }

        //drag
        new Action<PointerEventData> OnBeginDrag { get; set; }
        new Action<PointerEventData> OnDrag { get; set; }
        new Action<PointerEventData> OnEndDrag { get; set; }
        new Action<PointerEventData> OnDrop { get; set; }

        //enter
        new Action<PointerEventData> OnPointerEnter { get; set; }
        new Action<PointerEventData> OnPointerExit { get; set; }
        void StartTracking();
        void StopTracking();
    }
}