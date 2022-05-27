using Interfaces;
using Managers;
using UnityEngine;
namespace Objects.TypesObjects
{
    public class Shield : BaseObject,IDisappear
    {
        public float delayDisappear { get; set; }
        private int clicksOnBreak;
        private void Awake()
        {
            clicksOnBreak = 5;
            delayDisappear = 5f;
            timerDisappear = delayDisappear;
            onUpdate.OnEvent.AddListener(DisappearObject);
        }
        public override void OnClickObject() 
        {
            if (clicksOnBreak <= 0)
            {
                ScoreManager.Instance.AddScore(10);
                onUpdate.OnEvent.RemoveListener(DisappearObject);
                DisactiveAndDestroyObject();
            }
            else
            {
                clicksOnBreak--;   
            }
        }

        protected override void OnLoseClickObject() 
        {
            ScoreManager.Instance.SubstractScore(5);
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