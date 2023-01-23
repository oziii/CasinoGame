using System;
using System.Collections.Generic;
using OziLib;
using Resource_Folder.Scripts.Core;
using Resource_Folder.Scripts.Helpers;
using Resource_Folder.Scripts.ScriptableObject;
using Resource_Folder.Scripts.UIScript;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Resource_Folder.Scripts.Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        
        [SerializeField] private GeneralSettingsSO _generalSettingsSO;
        private int _currentLevel;
        private List<RewardData> _rewardDatas;
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
        
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }
        
        private void Start()
        {
            _rewardDatas = new List<RewardData>();
            _currentLevel = 1;
            EventManager.TriggerEvent(EventTags.LEVEL_READY, _currentLevel);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                OnLevelComplete(null);
            }
        }

        #endregion
    
        #region PUBLIC_METHODS
        
        public void AddRewardPiece(CollectPiece rewardPiece)
        {
            var data = new RewardData
            {
                item = rewardPiece.GetItemSO(),
                amount = rewardPiece.GetItemAmount()
            };
            _rewardDatas.Add(data);

        }
        
        public List<RewardData> GetRewardData()
        {
            return _rewardDatas;
        }
        
        #endregion
    
        #region PRIVATE_METHODS
    
        #endregion
    
        #region OVERRIDE_METHODS
    
        #endregion

        #region EVENTS
    
        private void OnLevelEnd(object arg0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        private void OnLevelComplete(object arg0)
        {
            _currentLevel++;
            if (_currentLevel > _generalSettingsSO.GoldEachLevel)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                return;
            }
            EventManager.TriggerEvent(EventTags.LEVEL_READY, _currentLevel);
        }


        #endregion
    }
}
