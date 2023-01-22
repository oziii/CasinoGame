using System;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using OziLib;
using Resource_Folder.Scripts.Managers;
using Resource_Folder.Scripts.ScriptableObject;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Resource_Folder.Scripts.Core
{
    public class SpinController : MonoBehaviour
    {
        [SerializeField] private SpinSO _spinSO;
        [Header("SpinFields")]
        [SerializeField] private Button _spinButton;
        [SerializeField] private Image _spinIndicatorImage;
        [SerializeField] private Image _spinBaseImage;
        [SerializeField] private Transform _spinBaseTransform;
        [SerializeField] private Transform _spinItemsParent;
        [Header ("Sound")]
        [SerializeField] private AudioSource _audioSource;

        [SerializeField] private ItemSO[] _items;

        private List<SpinPiece> _spinPieceList = new List<SpinPiece>();
        private bool _isSpinning;

        private GeneralSettingsSO _generalSettingsSO;
        private float _pieceAngle;
        private int _levelIndex;
        private System.Random _random = new System.Random();
        #region UNITY_METHODS

        private void OnEnable()
        {
            EventManager.StartListening(EventTags.LEVEL_READY, OnLevelReady);
        }
    
        private void OnDisable()
        {
            EventManager.StopListening(EventTags.LEVEL_READY, OnLevelReady);
        }

        private void Start()
        {
            _spinButton.onClick.AddListener(OnSpinButtonClick);
        }

        #endregion

        #region PUBLIC_METHODS



        #endregion

        #region PRIVATE_METHODS
    
        private void SpinGenerate(int levelIndex)
        {
            _generalSettingsSO = GameManager.Instance.GetGeneralSetting();
            _levelIndex = levelIndex;
            
            if (_spinPieceList.Count > 0)
            {
                for (int i = 0; i < _spinPieceList.Count; i++)
                {
                    Destroy(_spinPieceList[i].gameObject);
                }
                _spinPieceList.Clear();
            }
            _pieceAngle = 360f / _spinSO.SpinPieceAmount;

            if (levelIndex == _generalSettingsSO.GoldEachLevel)
            {
                SetSpinFields(SpinType.Gold);
                SpinItemsCreate(true);
            }
            else if(levelIndex % _generalSettingsSO.SilverEachLevel == 0)
            {
                SetSpinFields(SpinType.Silver);
                SpinItemsCreate(true);
            }
            else
            {
                SetSpinFields(SpinType.Bronze);
                SpinItemsCreate(false);
            }
           
            SetAudio();
           
        }

        private void SpinItemsCreate(bool _isRiskFree)
        {
            _items = new ItemSO[_spinSO.SpinPieceAmount];
            var spinItems = _spinSO.SpinLevels[_levelIndex-1 % _spinSO.SpinLevels.Count].spinItems;
            if (!_isRiskFree)
            {
                _items[0] = _spinSO.BombItem;
                for (int i = 1; i < _spinSO.SpinPieceAmount; i++)
                {
                    _items[i] = spinItems[Random.Range(0, spinItems.Count)];
                }
            }
            else
            {
                for (int i = 0; i < _spinSO.SpinPieceAmount; i++)
                {
                    _items[i] = spinItems[Random.Range(0, spinItems.Count)];
                }
            }

            _items.Shuffle();
            for (int i = 0; i < _spinSO.SpinPieceAmount; i++)
            {
                var piece = Instantiate(_spinSO.SpinPiecePrefab, _spinItemsParent);
                piece.transform.RotateAround(_spinItemsParent.position, Vector3.back, _pieceAngle * i);
                _spinPieceList.Add(piece);
                piece.SetItem(_spinSO,_items[i], _levelIndex);
            }
        }

        private void SetSpinFields(SpinType spinType)
        {
            var spinField = _spinSO.SpinFields.FirstOrDefault(x => x.spinType == spinType);
            if (spinField == null) return;
            // _spinIndicatorImage.sprite = spinField.spinIndicatorImage;
            // _spinBaseImage.sprite = spinField.spinBaseImage;
            
            _spinBaseImage.sprite = _spinSO.SpinAtlas.GetSprite(spinField.spinBaseImage.name);
            _spinIndicatorImage.sprite = _spinSO.SpinAtlas.GetSprite(spinField.spinIndicatorImage.name);
        }
        
        private void SetAudio()
        {
            _audioSource.clip = _spinSO.SpinAudioClip;
            _audioSource.volume = _spinSO.Volume;
            _audioSource.pitch = _spinSO.Pitch;
        }
        
        private void SpinStart()
        {
            EventManager.TriggerEvent(EventTags.SPIN_START, _levelIndex);
            var randomIndex = GetRandomIndex();
            var selectedPiece = _spinPieceList[randomIndex];
        
            var selectedAngle = _pieceAngle * randomIndex;
        
            var targetAngle = 360 * _spinSO.SpinDuration + selectedAngle;
        
            var currentAngle = _spinBaseTransform.eulerAngles.z;
            var prevAngle = currentAngle;
            var isSound = false;
             _spinBaseTransform.
                DORotate(Vector3.forward * targetAngle, _spinSO.SpinDuration, RotateMode.FastBeyond360)
                .SetEase(_spinSO.SpinEase)
                .OnUpdate((() =>
                {
                    var angleDifference = Mathf.Abs(prevAngle - currentAngle);
                    if (angleDifference >= _pieceAngle)
                    {
                        if (isSound)
                        {
                            _audioSource.PlayOneShot(_spinSO.SpinAudioClip);
                        }

                        isSound = !isSound;
                        prevAngle = currentAngle;
                    }
                    currentAngle = _spinBaseTransform.eulerAngles.z;
                }))
                .OnComplete((() =>
                {
                    _audioSource.PlayOneShot(_spinSO.SpinStopAudioClip);
                    _isSpinning = false;
                    _spinButton.interactable = !_isSpinning;
                    EventManager.TriggerEvent(EventTags.SPIN_END, selectedPiece);
                })).SetLink(_spinBaseTransform.gameObject);
        }
        
        private float CalculatedSpinChance()
        {
            float totalChance = 0;
            for (int i = 0; i < _spinPieceList.Count; i++)
            {
                totalChance += _spinPieceList[i].GetItem().ItemChance;
                _spinPieceList[i].SetChanceWeight(totalChance);
            }

            return totalChance;
        }
    
        private int GetRandomIndex()
        {
            var chanceRandom = _random.NextDouble() * CalculatedSpinChance();

            for (int i = 0; i < _spinPieceList.Count; i++)
            {
                if(_spinPieceList[i].GetChanceWeight() > chanceRandom)
                {
                    return i;
                }
            }
        
            return Random.Range(0, _spinPieceList.Count);
        }

        #endregion

        #region OVERRIDE_METHODS

        #endregion

        #region EVENTS
    
        private void OnSpinButtonClick()
        {
            Debug.Log("Spin Button Clicked");
            _isSpinning = true;
            _spinButton.interactable = !_isSpinning;
            SpinStart();
        }
    
        private void OnLevelReady(object arg0)
        {
            if(arg0 is int levelIndex)
            {
                SpinGenerate(levelIndex);
            }
        }

        #endregion
    }
}
