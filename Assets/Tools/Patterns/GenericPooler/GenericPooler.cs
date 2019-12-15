using System.Collections.Generic;

namespace Tools.Patterns.GenericPooler
{
    public partial class GenericPooler<T> where T : class, IPoolableObject, new()
    {
        readonly List<T> busy = new List<T>();
        readonly List<T> free = new List<T>();

        public GenericPooler(int startingSize)
        {
            StartSize = startingSize;
            for (var i = 0; i < StartSize; ++i)
            {
                var obj = new T();
                free.Add(obj);
            }
        }

        public int StartSize { get; }
        public int SizeFreeObjects => free.Count;
        public int SizeBusyObjects => busy.Count;

        /// <summary> Get an object </summary>
        public T Get()
        {
            T pooled = null;

            if (SizeFreeObjects > 0)
            {
                pooled = free[SizeFreeObjects - 1];
                free.Remove(pooled);
            }
            else
            {
                pooled = new T();
            }

            busy.Add(pooled);
            return pooled;
        }

        /// <summary> Release an object of the type T </summary>
        public void Release(T released)
        {
            if (released == null)
                throw new GenericPoolerArgumentException("Can't Release a null object");

            released.Restart();
            free.Add(released);
            busy.Remove(released);
        }
    }
}