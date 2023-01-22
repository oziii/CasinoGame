using Resource_Folder.Scripts.ScriptableObject;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Resource_Folder.Scripts.Core
{
    public class SpinPiece : MonoBehaviour
    {
        [SerializeField] private Image _itemIconImage;
        [SerializeField] private TextMeshProUGUI _itemAmountText;
        private ItemSO _itemSO;
        private float _chanceWeight;
        private int _pieceIndex;
        private int _itemAmount;
        #region UNITY_METHODS

        #endregion
    
        #region PUBLIC_METHODS
    
        public void SetItem(SpinSO spinSO,ItemSO itemSO, int amount)
        {
            _itemSO = itemSO;
            _itemIconImage.sprite = spinSO.SpinItemAtlas.GetSprite(itemSO.ItemIconName);
            _itemAmount = amount * Random.Range(1, itemSO.İtemMaxAmount);
            _itemAmountText.text = "x" + _itemAmount;
        }
    
        public ItemSO GetItem()
        {
            return _itemSO;
        }
    
        public int GetAmount()
        {
            return _itemAmount;
        }
    
        public void SetChanceWeight(float chanceWeight)
        {
            _chanceWeight = chanceWeight;
        }
    
        public float GetChanceWeight()
        {
            return _chanceWeight;
        }
    
        #endregion
    
        #region PRIVATE_METHODS
    
        #endregion
    
        #region OVERRIDE_METHODS
    
        #endregion

        #region EVENTS

        #endregion
    }
}
