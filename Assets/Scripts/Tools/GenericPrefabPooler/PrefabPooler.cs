using System.Collections.Generic;
using Tools.Patterns.Singleton;
using UnityEngine;

namespace Tools.Patterns.GenericPrefabPooler
{
    public class PrefabPooler<T> : SingletonMB<T>
        where T : class
    {
        private readonly Dictionary<GameObject, List<GameObject>> busy = new Dictionary<GameObject, List<GameObject>>();
        private readonly Dictionary<GameObject, List<GameObject>> free = new Dictionary<GameObject, List<GameObject>>();

        [Tooltip("All pooled models have to be inside this array before the initialization")]
        public GameObject[] models;

        [Tooltip("How many objects will be created as soon as the game loads")]
        public int startSize = 10;


        private void OnEnable()
        {
            if (!Application.isPlaying)
                return;

            Initialize();
        }

        private void Initialize()
        {
            if (models.Length == 0)
                Debug.LogError("Can't pool empty objects.");

            foreach (var model in models)
            {
                var pool = new List<GameObject>();
                var busy = new List<GameObject>();
                for (var i = 0; i < startSize; i++)
                {
                    var obj = Instantiate(model, transform);
                    pool.Add(obj);
                    obj.SetActive(false);
                }

                free.Add(model, pool);
                this.busy.Add(model, busy);
            }
        }


        public virtual GameObject Get(GameObject prefabModel)
        {
            GameObject pooledObj = null;

            if (free == null)
                Debug.LogError("Nop! PoolAble objects list is not created yet!");

            if (busy == null)
                Debug.LogError("Nop! Busy objects list is not created yet!");

            if (!free.ContainsKey(prefabModel))
                return null;

            if (free[prefabModel].Count > 0)
            {
                var size = free[prefabModel].Count;
                pooledObj = free[prefabModel][size - 1];
            }

            if (pooledObj != null)
                free[prefabModel].Remove(pooledObj);
            else
                pooledObj = Instantiate(prefabModel, transform);

            busy[prefabModel].Add(pooledObj);
            pooledObj.SetActive(true);
            OnPool(pooledObj);

            return pooledObj;
        }

        public virtual T1 Get<T1>(GameObject prefabModel) where T1 : class
        {
            var obj = Get(prefabModel);
            return obj.GetComponent<T1>();
        }

        public virtual T1 GetFirst<T1>() where T1 : class
        {
            var prefabModel = models[0];
            var obj = Get(prefabModel);
            return obj.GetComponent<T1>();
        }

        public virtual void Release(GameObject prefabModel, GameObject pooledObj)
        {
            if (free == null)
                Debug.LogError("Nop! PoolAble objects list is not created yet!");

            if (busy == null)
                Debug.LogError("Nop! Busy objects list is not created yet!");

            pooledObj.SetActive(false);
            busy[prefabModel].Remove(pooledObj);
            free[prefabModel].Add(pooledObj);
            pooledObj.transform.parent = transform;
            pooledObj.transform.localPosition = Vector3.zero;
            OnRelease(pooledObj);
        }

        public virtual void Release(GameObject pooledObj)
        {
            if (free == null)
                Debug.LogError("Nop! PoolAble objects list is not created yet!");

            if (busy == null)
                Debug.LogError("Nop! Busy objects list is not created yet!");

            pooledObj.SetActive(false);

            foreach (var model in busy.Keys)
                if (busy[model].Contains(pooledObj))
                {
                    busy[model].Remove(pooledObj);
                    free[model].Add(pooledObj);
                }

            pooledObj.transform.parent = transform;
            pooledObj.transform.localPosition = Vector3.zero;
            OnRelease(pooledObj);
        }

        protected virtual void OnPool(GameObject prefabModel)
        {
        }

        protected virtual void OnRelease(GameObject prefabModel)
        {
        }
    }
}