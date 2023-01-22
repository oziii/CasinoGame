using Resource_Folder.Scripts.Core;
using UnityEngine;

namespace Resource_Folder.Scripts.ScriptableObject
{
    [CreateAssetMenu(fileName = "CollectAreaSO", menuName = "SO/CollectAreaSO")]
    public class CollectAreaSO : UnityEngine.ScriptableObject
    {
        [SerializeField] private CollectPiece _collectPiecePrefab;
    
        public CollectPiece CollectPiecePrefab => _collectPiecePrefab;
    }
}
