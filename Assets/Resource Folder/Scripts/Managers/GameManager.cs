using OziLib;
using Resource_Folder.Scripts.Helpers;
using Resource_Folder.Scripts.ScriptableObject;
using UnityEngine;

namespace Resource_Folder.Scripts.Managers
{
    public class GameManager : OziSingleton<GameManager>
    {
    
        [SerializeField] private GeneralSettingsSO _generalSettingsSO;
        private int _currentLevel;
        #region UNITY_METHODS

        private void OnEnable()
        {
            EventManager.StartListening(EventTags.LEVEL_COMPLETE, OnLevelComplete);
            EventManager.StartListening(EventTags.LEVEL_END, OnLevelEnd);       
        }
    
        private void OnDisable()
        {
            EventManager.StopListening(EventTags.LEVEL_COMPLETE, OnLevelComplete);
            EventManager.StopListening(EventTags.LEVEL_END, OnLevelEnd);
        }



        private void Start()
        {
            _currentLevel = 1;
            EventManager.TriggerEvent(EventTags.LEVEL_READY, _currentLevel);
        }

        #endregion
    
        #region PUBLIC_METHODS


        public GeneralSettingsSO GetGeneralSetting()
        {
            return _generalSettingsSO;
            
        }
        
        #endregion
    
        #region PRIVATE_METHODS
    
        #endregion
    
        #region OVERRIDE_METHODS
    
        #endregion

        #region EVENTS
    
        private void OnLevelEnd(object arg0)
        {
        
        }

        private void OnLevelComplete(object arg0)
        {
            _currentLevel++;
            EventManager.TriggerEvent(EventTags.LEVEL_READY, _currentLevel);
        }


        #endregion
    }
}
