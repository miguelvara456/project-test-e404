using Events;
using UnityEngine;
using Utilities;

namespace Managers
{
    public class GameManager : Singleton<GameManager>
    {
        [Header("Events")]
        [SerializeField] private CustomEvent startGame;
        [SerializeField] private CustomEvent OnUpdateGame;
        public bool IsGameplay {get; private set;}

        private void Awake()
        {
            startGame.OnEvent.AddListener(() => IsGameplay = true);
        }

        private void Update()
        {
            if (IsGameplay)
                OnUpdateGame.ActiveEvent();
        }
    }
}