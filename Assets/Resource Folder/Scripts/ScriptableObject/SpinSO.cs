using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "SpinSO", menuName = "SO/SpinSO")]
public class SpinSO : ScriptableObject
{
    [Header("Spin Prefabs")]
    [SerializeField] private SpinPiece _spinPiecePrefab;
    
    [Space]
    [Header ("Spin Settings")]
    [SerializeField] private float _spinDuration = 1f;
    [SerializeField] [Range(2,8)]private int _spinPieceAmount = 10;
    
    [Space]
    [Header ("Sound Settings")]
    [SerializeField] private AudioClip _spinAudioClip;
    [SerializeField] [Range (0f, 1f)] private float _volume = .5f;
    [SerializeField] [Range (-3f, 3f)] private float _pitch = 1f;

    public SpinPiece SpinPiecePrefab => _spinPiecePrefab;

    public float SpinDuration => _spinDuration;

    public int SpinPieceAmount => _spinPieceAmount;

    public AudioClip SpinAudioClip => _spinAudioClip;

    public float Volume => _volume;

    public float Pitch => _pitch;
}
