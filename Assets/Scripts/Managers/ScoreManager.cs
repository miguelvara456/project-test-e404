using Events;
using UnityEngine;
using Utilities;

namespace Managers
{
    public class ScoreManager : Singleton<ScoreManager>
    {
        [Header("Events")] 
        [SerializeField] private CustomEvent onChangePoint;
        public int Score { get; private set; }

        public void AddScore(int amount)
        {
            Score += amount;
            if (Score >= 100)
                Score = 100;
            onChangePoint.ActiveEvent();
        }

        public void SubstractScore(int amount)
        {
            Score -= amount;
            if (Score <= 0)
                Score = 0;
            else
                onChangePoint.ActiveEvent();
        }
    }
}