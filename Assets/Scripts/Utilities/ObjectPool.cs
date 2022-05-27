using System.Linq;
using UnityEngine;

namespace Utilities
{
    public class ObjectPool
    {
        private bool recyclePositionObjects;
        private GameObject[] pool;
        private Vector3 cementary = Vector3.zero;
        public int MaxPool { get; private set; }

        public ObjectPool(int maxPool, GameObject prefab, Transform parent)
        {
            MaxPool = maxPool;
            pool = new GameObject[maxPool];
            recyclePositionObjects = false;
            for (int i = 0; i < maxPool; i++)
            {
                var obj = Object.Instantiate(prefab, cementary, prefab.transform.rotation,parent);
                obj.GetComponent<RecyclableObject>().Configure(this);
                obj.SetActive(false);
                pool[i] = obj;
            }
        }

        public GameObject Spawn(int index)
        {
            var obj = pool[index];
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                return obj;
            }
            return null;
        }
        
        public GameObject SpawnRandom()
        {
            var rdm = Random.Range(0, MaxPool);
            while (pool[rdm].activeInHierarchy)
            {
                 rdm = Random.Range(0, MaxPool);
            }
            pool[rdm].SetActive(true);
            return pool[rdm];
        }

        public int  GetObjectsPoolDisactive()
        {
            return pool.Count(obj => !obj.activeInHierarchy);
        }

        public void SetInitialSpawnPosition(int _index, Vector3 _position)
        {
            if (recyclePositionObjects)
                recyclePositionObjects = false;
            
            pool[_index].transform.position = _position;
        }

        public void RecyclableObject(GameObject _recycle)
        {
            if (recyclePositionObjects)
                _recycle.transform.position = cementary;
        }
    }
}