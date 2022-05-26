using Interfaces;
using UnityEngine;

namespace Objects.TypesObjects
{
    public class Coin : BaseObject,IDisappear
    {
        public float delayDisappear { get; set; }
    
        public override void OnClickObject() 
        {
            throw new System.NotImplementedException();
        }

        public override void OnLoseClickObject() 
        {
            throw new System.NotImplementedException();
        }
    
        public void DisappearObject()
        {
            throw new System.NotImplementedException();
        }
    }
}
