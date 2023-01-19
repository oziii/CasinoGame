using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpinPiece : MonoBehaviour
{
    [SerializeField] private Image _itemIconImage;
    [SerializeField] private TextMeshProUGUI _itemAmountText;
    private ItemSO _itemSO;
    private float _chanceWeight;
    private int _pieceIndex;
    #region UNITY_METHODS

    #endregion
    
    #region PUBLIC_METHODS
    
    public void SetItem(ItemSO itemSO, int amount)
    {
        _itemSO = itemSO;
        _itemIconImage.sprite = _itemSO.ItemIcon;
        _itemAmountText.text = "x" + amount * Random.Range(1,itemSO.İtemMaxAmount);
    }
    
    public ItemSO GetItem()
    {
        return _itemSO;
    }
    
    public int GetAmount()
    {
        return int.Parse(_itemAmountText.text.Substring(1));
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
