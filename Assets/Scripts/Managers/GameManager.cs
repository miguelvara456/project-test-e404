using Events;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utilities;

namespace Managers
{
    public class GameManager : Singleton<GameManager>
    {
        [Header("Events")]
        [SerializeField] private CustomEvent startGame;
        [SerializeField] private CustomEvent onUpdateGame;
        [SerializeField] private CustomEvent onChangePoint;
        [SerializeField] private CustomEvent onEndGame;
        [SerializeField] private CustomEvent onChangeTimerGame;
        public bool IsGameplay {get; private set;}
        private const int SCORE_TO_WIN = 100;
        private const float LOSE_TIMER = 0f;

        private void Awake()
        {
            onChangePoint.OnEvent.AddListener(CheckScore);
            onChangeTimerGame.OnEvent.AddListener(CheckTimer);
            onEndGame.OnEvent.AddListener(() => IsGameplay = false);
            startGame.OnEvent.AddListener(() => IsGameplay = true);
        }

        private void Update()
        {
            if (IsGameplay) onUpdateGame.ActiveEvent();
        }

        private void CheckScore()
        {
            if (ScoreManager.Instance.Score >= SCORE_TO_WIN)
            {
                UIManager.Instance.ActivePanel(2);
                onEndGame.ActiveEvent();
            }
        }

        private void CheckTimer()
        {
            if (TimerManager.Instance.CurrentTime <= LOSE_TIMER)
            {
                UIManager.Instance.ActivePanel(3);
                onEndGame.ActiveEvent();
            }
        }

        public void ChargeScene()
        {
            SceneManager.LoadScene(0);
        }
        
    }
}