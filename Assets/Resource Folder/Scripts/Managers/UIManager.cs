using System;
using System.Collections.Generic;
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
            EventManager.StartListening(EventTags.LEVEL_EXIT, OnGameExit);
            EventManager.StartListening(EventTags.COLLECT_REWARD, OnCollectReward);
        }

        private void OnDisable()
        {
            EventManager.StopListening(EventTags.LEVEL_START, OnGameStart);
            EventManager.StopListening(EventTags.LEVEL_END, OnGameEnd);
            EventManager.StopListening(EventTags.LEVEL_FAIL, OnGameFail);
            EventManager.StopListening(EventTags.LEVEL_EXIT, OnGameExit);
            EventManager.StopListening(EventTags.COLLECT_REWARD, OnCollectReward);
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
            AllUIHide();
            GetUI(UIType.Game).ShowUI();
            
        }

        private UIBase GetUI(UIType uıType)
        {
            return _uiBases.FirstOrDefault(uiBase => uiBase.GetUIType() == uıType);
        }

        private void AllUIHide()
        {
            foreach (var uiBase in _uiBases)
            {
                uiBase.HideUI();
            }
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
            GetUI(UIType.Fail).ShowUI();
        }
        
        private void OnGameExit(object arg0)
        {
            Debug.Log("Level Exit");
            GetUI(UIType.Exit).ShowUI();
        }
        
        private void OnCollectReward(object arg0)
        {
            Debug.Log("Level Reward");
            var data = GameManager.Instance.GetRewardData();
            GetUI(UIType.Rewards).ShowUI(data);
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