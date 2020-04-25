using System;
using UnityEngine;

namespace Tools.Patterns.Singleton
{
    public class SingletonMB<T> : MonoBehaviour where T : class
    {
        private static readonly object locker = new object();

        [Tooltip("Mark it whether this singleton will be destroyed when the scene changes"), SerializeField]
        private bool isDontDestroyOnLoad;

        [Tooltip(
             "Mark it whether the script raises an exception when another singleton like this is present in the scene"),
         SerializeField]
        private bool isSilent = true;

        public static T Instance { get; private set; }

        protected virtual void OnAwake()
        {
        }


        public void InjectInstance(T instance)
        {
            Instance = instance;
        }

        protected virtual void Awake()
        {
            lock (locker)
            {
                if (Instance == null)
                    Initialize();
                else if (Instance as SingletonMB<T> != this) HandleDuplication();
            }
        }

        protected virtual void OnDestroy()
        {
            if (Instance as SingletonMB<T> == this) Instance = null;
        }

        private void Initialize()
        {
            Instance = this as T;
            if (isDontDestroyOnLoad)
                DontDestroyOnLoad(gameObject);

            OnAwake();
        }

        private void HandleDuplication()
        {
            var allSingletonsOfThis = FindObjectsOfType(typeof(T));

            if (isSilent)
            {
                foreach (var duplicated in allSingletonsOfThis)
                    if (!ReferenceEquals(duplicated, Instance))
                        Destroy(duplicated);
            }
            else
            {
                var singletonsNames = string.Empty;
                foreach (var duplicated in allSingletonsOfThis)
                    singletonsNames += duplicated.name + ", ";
                var message = "[" + GetType() + "] Something went really wrong, " +
                              "there is more than one Singleton: \"" + typeof(T) +
                              "\". GameObject names: " +
                              singletonsNames;

                throw new SingletonMBException(message);
            }
        }

        public class SingletonMBException : Exception
        {
            public SingletonMBException(string message) : base(message)
            {
            }
        }
    }
}