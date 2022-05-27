using Utilities;
using UnityEngine;
using Events;
namespace Managers
{
    public class TimerManager : Singleton<TimerManager>
    {
        [Header("Events")]
        [SerializeField] private CustomEvent startGame;
        [SerializeField] private CustomEvent onUpdateGame;
        [SerializeField] private CustomEvent onChangeTimerGame;
        public float CurrentTime { get; private set; }
        private void Awake()
        {
            startGame.OnEvent.AddListener(InitializeTimer);
            onUpdateGame.OnEvent.AddListener(UpdateTimer);
        }

        private void UpdateTimer()
        {
            CurrentTime -= 1 * Time.deltaTime;
            onChangeTimerGame.ActiveEvent();
        }

        private void InitializeTimer()
        {
            CurrentTime = 120f;
        }
            
    
    }
}