using UnityEngine;
using Utilities;

namespace Managers
{
    public class ScoreManager : Singleton<ScoreManager>
    {
        public int Score { get; private set; }

        public void AddScore(int amount)
        {
            Score += amount;
        }

        public void SubstractScore(int amount)
        {
            Score -= amount;
        }
    }
}