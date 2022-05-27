using Interfaces;
using Managers;
namespace Objects.TypesObjects
{
    public class Shield : BaseObject,IDisappear
    {
        public float delayDisappear { get; set; }
        private int clicksOnBreak;
        public override void OnClickObject() 
        {
            if (clicksOnBreak <= 0)
            {
                ScoreManager.Instance.AddScore(10);
                transform.parent.gameObject.SetActive(false);
            }
            else
            {
                clicksOnBreak--;   
            }
        }

        public override void OnLoseClickObject() 
        {
            ScoreManager.Instance.SubstractScore(5);
        }
    
        public void DisappearObject()
        {
            OnLoseClickObject();
        }
    }
}