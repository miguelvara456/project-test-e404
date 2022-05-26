using UnityEngine;

namespace Objects
{
    public abstract class BaseObject: MonoBehaviour
    {
        public abstract void OnClickObject();
        public abstract void OnLoseClickObject();
    }   
}
