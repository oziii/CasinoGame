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
    
    #region UNITY_METHODS

    #endregion
    
    #region PUBLIC_METHODS
    
    public void SetItem(ItemSO itemSO)
    {
        _itemSO = itemSO;
    }
    
    public ItemSO GetItem()
    {
        return _itemSO;
    }
    
    #endregion
    
    #region PRIVATE_METHODS
    
    #endregion
    
    #region OVERRIDE_METHODS
    
    #endregion

    #region EVENTS

    #endregion
}
