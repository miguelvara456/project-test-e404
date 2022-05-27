using Interfaces;
using Managers;
namespace Objects.TypesObjects
{
    public class RedBox : BaseObject,IDisappear
    {
        public float delayDisappear { get; set; }
        public override void OnClickObject() 
        {
            transform.parent.gameObject.SetActive(false);
            ScoreManager.Instance.SubstractScore(5);
            
        }

        public override void OnLoseClickObject() 
        {
            
        }
    
        public void DisappearObject()
        {
           
        }
    }
}