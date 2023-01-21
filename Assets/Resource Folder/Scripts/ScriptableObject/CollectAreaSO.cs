using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CollectAreaSO", menuName = "SO/CollectAreaSO")]
public class CollectAreaSO : ScriptableObject
{
    [SerializeField] private CollectPiece _collectPiecePrefab;
    
    public CollectPiece CollectPiecePrefab => _collectPiecePrefab;
}
