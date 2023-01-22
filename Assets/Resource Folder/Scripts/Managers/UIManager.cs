using System;
using System.Linq;
using OziLib;
using Resource_Folder.Scripts.UIScript;
using UnityEngine;

namespace Resource_Folder.Scripts.Managers
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private UIBase[] _uiBases;
        
        #region UNITY_METHODS

        private void OnEnable()
        {
            EventManager.StartListening(EventTags.LEVEL_START, OnGameStart);
            EventManager.StartListening(EventTags.LEVEL_END, OnGameEnd);
            EventManager.StartListening(EventTags.LEVEL_FAIL, OnGameFail);
        }

        private void OnDisable()
        {
            EventManager.StopListening(EventTags.LEVEL_START, OnGameStart);
            EventManager.StopListening(EventTags.LEVEL_END, OnGameEnd);
            EventManager.StopListening(EventTags.LEVEL_FAIL, OnGameFail);
        }

        private void Start()
        {
            SetUIBase();
        }

        #endregion
    
        #region PUBLIC_METHODS
    
        #endregion
    
        #region PRIVATE_METHODS
        
        private void SetUIBase()
        {
            _uiBases = FindObjectsOfType<UIBase>();
        }

        private UIBase GetUI(UIType uıType)
        {
            return _uiBases.FirstOrDefault(uiBase => uiBase.GetUIType() == uıType);
        }
    
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
        
        private void OnGameFail(object arg0)
        {
        
        }
    
        #endregion
    }
}

#region UNITY_METHODS

#endregion
    
#region PUBLIC_METHODS
    
#endregion
    
#region PRIVATE_METHODS
    
#endregion
    
#region OVERRIDE_METHODS
    
#endregion

#region EVENTS

#endregion