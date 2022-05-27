using Interfaces;
using Managers;

namespace Objects.TypesObjects
{
    public class YellowBlock : BaseObject,IDisappear
    {
        public float delayDisappear { get; set; }
        public override void OnClickObject() 
        {
            transform.parent.gameObject.SetActive(false);
            ScoreManager.Instance.AddScore(1);
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