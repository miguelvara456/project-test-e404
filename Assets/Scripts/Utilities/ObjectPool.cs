using UnityEngine;

namespace Utilities
{
    public class ObjectPool
    {
        private int maxPool;
        private GameObject prefab;
        private bool recyclePositionObjects;
        private GameObject[] pool;
        private Vector3 cementary = Vector3.zero;
        public int MaxPool => maxPool;

        public ObjectPool(int maxPool, GameObject prefab, Transform parent)
        {
            this.maxPool = maxPool;
            this.prefab = prefab;
            pool = new GameObject[maxPool];
            recyclePositionObjects = true;
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