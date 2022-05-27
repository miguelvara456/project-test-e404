using Events;
using UnityEngine;

namespace Objects
{
    public abstract class BaseObject: MonoBehaviour
    {
        [SerializeField] protected CustomEvent onUpdate;
        protected float timerDisappear = 0f;

        public abstract void OnClickObject();
        protected abstract void OnLoseClickObject();
    }   
}
