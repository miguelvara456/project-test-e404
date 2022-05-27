using Events;
using TMPro;
using UnityEngine;
using Utilities;

namespace Managers
{
    public class UIManager : Singleton<UIManager>
    {
        [SerializeField] private GameObject[] panels;
        [SerializeField] private TextMeshProUGUI textTimer;
        [SerializeField] private TextMeshProUGUI textScore;
        [Header("Events")]
        [SerializeField] private CustomEvent onChangePoint;
        [SerializeField] private CustomEvent onChangeTimerGame;
        [SerializeField] private CustomEvent startGame;
    
        private void Awake()
        {
            onChangePoint.OnEvent.AddListener(UpdateScoreText);
            onChangeTimerGame.OnEvent.AddListener(UpdateTimerText);
            startGame.OnEvent.AddListener(() =>
            {
                UpdateScoreText();
                UpdateTimerText();
                CloseAllPanels();
                ActivePanel(1);
            });
        }
    
        void Start()
        {
            CloseAllPanels();
            ActivePanel(0);
        }
        
        public void CloseAllPanels()
        {
            foreach (var panel in panels)
                panel.SetActive(false);
        }
        
        public void ActivePanel(int panelIndex)
        {
            panels[panelIndex].SetActive(true);
        }
    
        public void UpdateTimerText()
        {
            textTimer.text = $"Time: {TimerManager.Instance.CurrentTime:00}";
        }
        
        public void UpdateScoreText()
        {
            textScore.text = $"Score: {ScoreManager.Instance.Score}";
        }
    }   
}
