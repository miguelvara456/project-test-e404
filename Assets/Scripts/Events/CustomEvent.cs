using UnityEngine;
using UnityEngine.Events;

namespace Events
{
    [CreateAssetMenu(fileName = "CustomEvent", menuName = "ScriptableObjects/Event/CustomEvent", order = 0)]
    public class CustomEvent : ScriptableObject
    {
        public UnityEvent OnEvent;
        public void ActiveEvent()
        {
            if (OnEvent != null)
                OnEvent.Invoke();
        }
    }
}