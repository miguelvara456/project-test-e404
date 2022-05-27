using Interfaces;
using Managers;

namespace Objects.TypesObjects
{
    
    public class BlueSphere : BaseObject,IDisappear
    {
        public float delayDisappear { get; set; }
        public override void OnClickObject() 
        {
            ScoreManager.Instance.AddScore(2);
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