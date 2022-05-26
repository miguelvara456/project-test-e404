using UnityEngine;

namespace Utilities
{
    public class ObjectPool : MonoBehaviour
    {
        [SerializeField] private int maxPool;
        [SerializeField] private GameObject prefab;
        private bool recyclePositionObjects;
        private GameObject[] pool;
        private Vector3 cementary = Vector3.zero;
        public int MaxPool => maxPool;
        private void Awake()    
        {
            Init();
        }

        private void Init()
        {
            pool = new GameObject[maxPool];
            recyclePositionObjects = true;
            for (int i = 0; i < maxPool; i++)
            {
                var obj = Object.Instantiate(prefab, cementary, prefab.transform.rotation,transform);
                obj.GetComponent<RecyclableObject>().Configure(this);
                obj.SetActive(false);
                pool[i] = obj;
            }
        }

        public GameObject Spawn(Vector3 _position)
        {
            foreach (var i in pool)
            {
                if (!i.activeInHierarchy)
                {
                    i.transform.position = _position;
                    i.SetActive(true);
                    return i;
                }
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
            {
                _recycle.transform.position = cementary;
            }
        }
    }
}