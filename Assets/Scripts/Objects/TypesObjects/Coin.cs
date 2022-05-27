using Interfaces;
using Managers;

namespace Objects.TypesObjects
{
    public class Coin : BaseObject,IDisappear
    {
        public float delayDisappear { get; set; }
        
        public override void OnClickObject() 
        { 
            transform.parent.gameObject.SetActive(false);
            ScoreManager.Instance.AddScore(5);
            Destroy(this.gameObject);
        }

        public override void OnLoseClickObject() 
        {
            ScoreManager.Instance.SubstractScore(1);
        }
    
        public void DisappearObject()
        {
            OnLoseClickObject();
        }
    }
}
