using System;
using System.Collections.Generic;
using UnityEngine;

namespace Tools.Patterns.Observer
{
    public interface IDispatcher
    {
        void Notify<T1>(Action<T1> subject) where T1 : class;
        void AddListener(IListener listener);
        void RemoveListener(IListener listener);
        void RemoveSubject(Type subject);
    }
    
    public class ObserverAtt<T> : ScriptableObject, IDispatcher where T : Attribute
    {
        readonly Dictionary<Type, List<IListener>> _register = new Dictionary<Type, List<IListener>>();

        public void AddListener(IListener listener)
        {
            if (listener == null)
                throw new ArgumentNullException("Can't register Null as a Listener");

            var type = listener.GetType();
            var interfaces = type.GetInterfaces();

            foreach (var i in interfaces)
            {
                var customAttributes = i.GetCustomAttributes(true);
                foreach (var subject in customAttributes)
                    if (subject is T)
                        CreateAndAdd(i, listener);
            }
        }

        public void RemoveListener(IListener listener)
        {
            foreach (var pair in _register)
                pair.Value.Remove(listener);
        }

        public void RemoveSubject(Type subject)
        {
            if (_register.ContainsKey(subject))
                _register.Remove(subject);
        }

        public void Notify<T1>(Action<T1> subject) where T1 : class
        {
            var subjectType = typeof(T1);
            var isSubject = _register.ContainsKey(subjectType);
            if (!isSubject)
                return;
            var listeners = _register[subjectType];
            if (listeners.Count == 0) return;

            for (var i = 0; i < listeners.Count; i++)
            {
                var obj = listeners[i];
                if (obj != null)
                    subject(obj as T1);
            }
        }

        void CreateAndAdd(Type subject, IListener listener)
        {
            if (_register.ContainsKey(subject))
                _register[subject].Add(listener);
            else
                _register.Add(subject, new List<IListener> {listener});
        }
    }
}