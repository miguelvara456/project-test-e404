using UnityEngine;
using Interfaces;
using Objects;

namespace Objects.TypesObjects
{
    public class BlueSphere : BaseObject,IDisappear
    {
        public override void OnClickObject()
        {
            throw new System.NotImplementedException();
        }

        public override void OnLoseClickObject()
        {
            throw new System.NotImplementedException();
        }

        public float delayDisappear { get; set; }
        public void DisappearObject()
        {
            throw new System.NotImplementedException();
        }
    }
}