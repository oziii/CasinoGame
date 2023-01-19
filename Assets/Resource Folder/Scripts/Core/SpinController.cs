using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using OziLib;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

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

    private List<SpinPiece> _spinPieceList;
    private bool _isSpinning;


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
    
    #endregion

    #region PUBLIC_METHODS



    #endregion

    #region PRIVATE_METHODS
    
    private void SpinGenerate(int levelIndex)
    {
        _levelIndex = levelIndex;
        _spinPieceList = new List<SpinPiece>();
        _pieceAngle = 360f / _spinSO.SpinPieceAmount;
        SpinItemsCreate();
        SetAudio();
        _spinButton.onClick.AddListener(OnSpinButtonClick);
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
        
        var spinTween = _spinBaseTransform.
            DORotate(Vector3.forward * targetAngle, _spinSO.SpinDuration, RotateMode.FastBeyond360)
            .SetEase(_spinSO.SpinEase)
            .OnUpdate((() =>
            {
                var angleDifference = Mathf.Abs(prevAngle - currentAngle);
                if (angleDifference >= _pieceAngle)
                {
                    _audioSource.PlayOneShot(_spinSO.SpinAudioClip);
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
            }));
    }

    private void SpinItemsCreate()
    {
        ListHelper.Shuffle(_items);
        for (int i = 0; i < _spinSO.SpinPieceAmount; i++)
        {
            var piece = Instantiate(_spinSO.SpinPiecePrefab, _spinItemsParent);
            piece.transform.RotateAround(_spinItemsParent.position, Vector3.back, _pieceAngle * i);
            _spinPieceList.Add(piece);
            piece.SetItem(_items[i], _levelIndex);
        }
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
    
    private void SetAudio()
    {
        _audioSource.clip = _spinSO.SpinAudioClip;
        _audioSource.volume = _spinSO.Volume;
        _audioSource.pitch = _spinSO.Pitch;
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
