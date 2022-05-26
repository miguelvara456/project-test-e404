using UnityEngine;

namespace Utilities
{
    public class Singleton<T> : MonoBehaviour where T : Component
    {
        private static T instance;

        public static T Instance
        {
            get
            {
                if (!instance)
                {
                    var objs = FindObjectsOfType(typeof(T)) as T[];
                    if (objs.Length > 0)
                        instance = objs[0];
                    if(objs.Length > 1)
                        Debug.LogError("There is more than one " + typeof(T).Name + " in the scene");
                    if (instance == null)
                    {
                        var obj = new GameObject();
                        obj.name = string.Format("_{0}", typeof(T).Name);
                        instance = obj.AddComponent<T>();
                    }
                }
                return instance;
            }
        }
    }
}