using System.Collections.Generic;
using DG.Tweening;
using OziLib;
using Resource_Folder.Scripts.ScriptableObject;
using UnityEngine;

namespace Resource_Folder.Scripts.Core
{
    public class LevelAreaController : MonoBehaviour
    {
        [SerializeField] private LevelAreaSO _levelAreaSO;
        [SerializeField] private Transform _contentParent;
    
        private GeneralSettingsSO _generalSettingsSO;
        private List<LevelPiece> _levelPieces = new List<LevelPiece>();
        private int _currentLevelPieceIndex = 0;
        #region UNITY_METHODS
    
        private void Start()
        {
            _generalSettingsSO = Resources.Load<GeneralSettingsSO>("ScriptableObject/GeneralSettingsSO");
            LevelAreaGenerate();
        }

        private void OnEnable()
        {
            EventManager.StartListening(EventTags.SPIN_END, OnLevelCompleted);
            EventManager.StartListening(EventTags.LEVEL_READY, OnLevelReady);
        }
    
        private void OnDisable()
        {
            EventManager.StopListening(EventTags.LEVEL_READY, OnLevelReady);
            EventManager.StopListening(EventTags.SPIN_END, OnLevelCompleted);
        }

        #endregion
    
        #region PUBLIC_METHODS
    
        #endregion
    
        #region PRIVATE_METHODS 
    
        private void LevelAreaGenerate()
        {
            for (int i = 0; i < _generalSettingsSO.GoldEachLevel; i++)
            {
                var contentPiece = Instantiate(_levelAreaSO.LevelPiecePrefab, _contentParent);
                if ((i+1) % _generalSettingsSO.SilverEachLevel == 0)
                {
                    contentPiece.SetBackground(_levelAreaSO.LevelPieceAtlas.GetSprite(_levelAreaSO.LevelPieceNames[0]), i+1);
                }
                else
                {
                    contentPiece.SetBackground(_levelAreaSO.LevelPieceAtlas.GetSprite(_levelAreaSO.LevelPieceNames[1]), i+1);
                }
                _levelPieces.Add(contentPiece);
            }
        }

        private void NewLevelSelected()
        {
            _contentParent.DOLocalMoveX(_currentLevelPieceIndex * _levelAreaSO.NextLevelPiecePositionX, _levelAreaSO.NextLevelDuration)
                .SetEase(_levelAreaSO.NextLevelEase)
                .OnComplete((() =>
                {
                    _levelPieces[_currentLevelPieceIndex].SelectedLevel();
                    _currentLevelPieceIndex++;
                }));  
        }
    
        #endregion
    
        #region OVERRIDE_METHODS
    
        #endregion

        #region EVENTS
    
        private void OnLevelReady(object arg0)
        {
            NewLevelSelected();
        }   
    
        private void OnLevelCompleted(object arg0)
        {
            _levelPieces[_currentLevelPieceIndex -1].DeselectedLevel();
       
        }

        #endregion
    }
}
