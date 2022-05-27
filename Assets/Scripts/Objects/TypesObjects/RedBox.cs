using Interfaces;
using Managers;
using UnityEngine;
namespace Objects.TypesObjects
{
    public class RedBox : BaseObject,IDisappear
    {
        public float delayDisappear { get; set; }
        private void Awake()
        {
            delayDisappear = 5f;
            timerDisappear = delayDisappear;
            onUpdate.OnEvent.AddListener(DisappearObject);
        }
        public override void OnClickObject() 
        {
            ScoreManager.Instance.SubstractScore(5);
            onUpdate.OnEvent.RemoveListener(DisappearObject);
            DisactiveAndDestroyObject();
        }

        protected override void OnLoseClickObject()
        {
            onUpdate.OnEvent.RemoveListener(DisappearObject);
            DisactiveAndDestroyObject();
        }
    
        public void DisappearObject()
        {
            if (timerDisappear <= 0)
                OnLoseClickObject();

            timerDisappear -= 1*Time.deltaTime;
        }
        
        private void DisactiveAndDestroyObject()
        {
            Destroy(this.gameObject);
            transform.parent.gameObject.SetActive(false);
        }
    }
}