using System;
using System.Collections.Generic;
using Tools.Patterns.Singleton;

namespace Tools.Patterns.Observer
{
    public interface ISubject
    {
    }

    public interface IListener
    {
    }

    public class ObserverMB<T> : SingletonMB<ObserverMB<T>>
    {
        readonly Dictionary<Type, List<IListener>> register = new Dictionary<Type, List<IListener>>();

        public virtual void AddListener(IListener listener)
        {
            if (listener == null)
                throw new ArgumentNullException("Can't register Null as a Listener");

            var type = listener.GetType();
            var interfaces = type.GetInterfaces();
            for (var i = 0; i < interfaces.Length; i++)
            {
                var subject = interfaces[i];

                //TODO: ISubject and mid level interfaces are also added to the register
                var isAssignableFrom = typeof(ISubject).IsAssignableFrom(subject);
                if (isAssignableFrom)
                    CreateAndAdd(subject, listener);
            }
        }

        public virtual void RemoveListener(IListener listener)
        {
            foreach (var pair in register)
                pair.Value.Remove(listener);
        }

        public void RemoveSubject(Type subject)
        {
            if (register.ContainsKey(subject))
                register.Remove(subject);
        }

        public void Notify<T1>(Action<T1> subject) where T1 : class
        {
            var subjectType = typeof(T1);
            var isSubject = register.ContainsKey(subjectType);
            if (!isSubject)
                return;
            var listeners = register[subjectType];
            if (listeners.Count == 0) return;

            for (var i = 0; i < listeners.Count; i++)
            {
                var obj = listeners[i];
                if (obj != null)
                    subject(obj as T1);
            }
        }

        protected void CreateAndAdd(Type subject, IListener listener)
        {
            if (register.ContainsKey(subject))
                register[subject].Add(listener);
            else
                register.Add(subject, new List<IListener> {listener});
        }
    }
}