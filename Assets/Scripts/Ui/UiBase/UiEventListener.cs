using Tools.Patterns.Observer;
using UnityEngine;

namespace Game.Ui
{
    /// <summary>
    ///     Base class for all classes interested on events that happen inside the FSM.
    /// </summary>
    public abstract class UiEventListener : MonoBehaviour, IListener
    {
        /// <summary> Reference to the observer. </summary>
        protected IDispatcher Dispatcher;

        /// <summary> Add itself as a listener. </summary>
        protected virtual void Awake()
        {
            Dispatcher = EventsDispatcher.Load();
            Subscribe();
        }

        void OnDestroy() => Unsubscribe();
        void Subscribe() => Dispatcher.AddListener(this);
        void Unsubscribe() => Dispatcher?.RemoveListener(this);
    }
}