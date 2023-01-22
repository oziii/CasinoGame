using DG.Tweening;
using Resource_Folder.Scripts.Core;
using UnityEngine;
using UnityEngine.U2D;

namespace Resource_Folder.Scripts.ScriptableObject
{
    [CreateAssetMenu(fileName = "LevelAreaSO", menuName = "SO/LevelAreaSO")]
    public class LevelAreaSO : UnityEngine.ScriptableObject
    {
        [SerializeField] private LevelPiece _levelPiecePrefab;
        [SerializeField] private SpriteAtlas _levelPieceAtlas;
        [SerializeField] private string[] _levelPieceNames;
        [SerializeField] private float _nextLevelPiecePositionX;
        [SerializeField] private float _nextLevelDuration;
        [SerializeField] private Ease _nextLevelEase;
        public LevelPiece LevelPiecePrefab => _levelPiecePrefab;

        public SpriteAtlas LevelPieceAtlas => _levelPieceAtlas;

        public string[] LevelPieceNames => _levelPieceNames;

        public float NextLevelPiecePositionX => _nextLevelPiecePositionX;

        public float NextLevelDuration => _nextLevelDuration;

        public Ease NextLevelEase => _nextLevelEase;
    }
}
