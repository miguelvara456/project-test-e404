using UnityEngine;

namespace Utilities
{
    public class RecyclableObject : MonoBehaviour
    {
        private ObjectPool poolParent;
        public void Configure(ObjectPool _poolParent)
        {
            poolParent = _poolParent;
        }

        public void Recycle()
        {
            poolParent.RecyclableObject(gameObject);
        }

        private void OnDisable() {
            Recycle();
        }
    }
}