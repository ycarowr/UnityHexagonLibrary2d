using UnityEngine;

namespace Tools.Patterns.Singleton
{
    public class PersistentSingleton<T> : MonoBehaviour where T : Component
    {
        static T instance;

        public static T Instance
        {
            get
            {
                if (instance == null)
                    CreateInstance();
                else
                    HandleDuplication();

                return instance;
            }
        }

        static void CreateInstance()
        {
            var go = new GameObject(typeof(T).ToString());
            instance = go.AddComponent<T>();
        }

        static void HandleDuplication()
        {
            var copies = FindObjectsOfType(typeof(T));
            foreach (var copy in copies)
                if (copy != instance)
                    Destroy(copy);
        }
    }
}