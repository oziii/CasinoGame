using OziLib;
using UnityEngine;
using UnityEngine.UI;

namespace Resource_Folder.Scripts.UIScript
{
    public class UIGame : UIBase
    {
        [SerializeField] private Button _exitButton;
    
    
        #region UNITY_METHODS

        private void OnEnable()
        {
            EventManager.StartListening(EventTags.LEVEL_START, OnGameStart);
            EventManager.StartListening(EventTags.LEVEL_START, OnGameEnd);
        }

        private void OnDisable()
        {
            EventManager.StopListening(EventTags.LEVEL_START, OnGameStart);
            EventManager.StopListening(EventTags.LEVEL_START, OnGameEnd);
        }

        private void Start()
        {
            _exitButton.onClick.AddListener(OnExitButtonClicked);
        }



        #endregion
    
        #region PUBLIC_METHODS
    
        #endregion
    
        #region PRIVATE_METHODS
    
        #endregion
    
        #region OVERRIDE_METHODS

        #endregion

        #region EVENTS
    
        private void OnGameEnd(object arg0)
        {
        
        }

        private void OnGameStart(object arg0)
        {
        
        }
    
        private void OnExitButtonClicked()
        { 
            EventManager.TriggerEvent(EventTags.LEVEL_END, null);
        }
    
        #endregion
    
    

    }
}
