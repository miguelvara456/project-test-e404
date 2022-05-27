using Interfaces;
using Managers;

namespace Objects.TypesObjects
{
    public class Target : BaseObject,IDisappear
    {
        public float delayDisappear { get; set; }
        
        public override void OnClickObject() 
        {
            transform.parent.gameObject.SetActive(false);
            SpawnerManager.Instance.SpawnGroup(5,0);
        }

        public override void OnLoseClickObject() 
        {
            ScoreManager.Instance.SubstractScore(10);
        }
    
        public void DisappearObject()
        {
            OnLoseClickObject();
        }
    }
}