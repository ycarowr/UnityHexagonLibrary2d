using System;
using Tools.Patterns.Observer;
using UnityEngine;

/// <summary>
///     Dispatcher of the events related to the Battle FSM.
/// </summary>
[CreateAssetMenu(menuName = "Variables/GameEventsDispatcher")]
public class EventsDispatcher : ObserverAtt<EventAttribute>
{
    const string FilePath = "Variables/GameEventsDispatcher";
    public static EventsDispatcher Load() => Resources.Load<EventsDispatcher>(FilePath);
}

[AttributeUsage(AttributeTargets.Interface, AllowMultiple = true)]
public class EventAttribute : Attribute
{
}