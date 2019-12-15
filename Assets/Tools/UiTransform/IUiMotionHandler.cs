using UnityEngine;

namespace Tools.UiTransform
{
    /// <summary>
    ///     Interface for simple Transform operations.
    /// </summary>
    public interface IUiMotionHandler
    {
        /// <summary>
        ///     Motion module.
        /// </summary>
        UiMotion Motion { get; }

        /// <summary>
        ///     The Monobehavior attached to the object.
        /// </summary>
        MonoBehaviour MonoBehaviour { get; }
    }
}