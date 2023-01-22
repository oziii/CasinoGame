using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Resource_Folder.Scripts.Core;
using UnityEngine;
using UnityEngine.Serialization;

namespace Resource_Folder.Scripts.ScriptableObject
{
    [CreateAssetMenu(fileName = "SpinSO", menuName = "SO/SpinSO")]
    public class SpinSO : UnityEngine.ScriptableObject
    {
        [Header("Spin Prefabs")]
        [SerializeField] private SpinPiece _spinPiecePrefab;
        [SerializeField] private List<SpinField> _spinFields;
        [Space]
        [Header ("Spin Settings")]
        [SerializeField] private float _spinDuration = 1f;
        [SerializeField] [Range(2,8)]private int _spinPieceAmount = 8;
        [SerializeField] private Ease _spinEase;
        [Space]
        [Header ("Sound Settings")]
        [SerializeField] private AudioClip _spinAudioClip;
        [SerializeField] private AudioClip _spinStopAudioClip;
        [SerializeField] [Range (0f, 1f)] private float _volume = .5f;
        [SerializeField] [Range (-3f, 3f)] private float _pitch = 1f;

        [Space] 
        [Header("Spin Items")] 
        [SerializeField] private ItemSO _bombItem;
        [SerializeField] private List<SpinLevel> _spinLevels;
        public SpinPiece SpinPiecePrefab => _spinPiecePrefab;

        public float SpinDuration => _spinDuration;

        public int SpinPieceAmount => _spinPieceAmount;

        public AudioClip SpinAudioClip => _spinAudioClip;

        public float Volume => _volume;

        public float Pitch => _pitch;

        public Ease SpinEase => _spinEase;

        public AudioClip SpinStopAudioClip => _spinStopAudioClip;

        public List<SpinField> SpinFields => _spinFields;

        public ItemSO BombItem => _bombItem;

        public List<SpinLevel> SpinLevels => _spinLevels;
    }

    [Serializable]
    public class SpinField
    {
        public SpinType spinType;
        public Sprite spinBaseImage;
        public Sprite spinIndicatorImage;
    }

    public enum SpinType
    {
        Bronze,
        Silver,
        Gold
    }

    [Serializable]
    public class SpinLevel
    {
        public List<ItemSO> spinItems;
    }
}