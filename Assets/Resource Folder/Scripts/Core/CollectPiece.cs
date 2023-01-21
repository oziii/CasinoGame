using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CollectPiece : MonoBehaviour
{
    [SerializeField] private Image _itemImage;
    [SerializeField] private TextMeshProUGUI _itemAmountText;
    private ItemSO _itemSO;
    private int _itemAmount;
    public void SetPiece(Sprite sprite, int amount)
    {
        _itemImage.sprite = sprite;
        _itemAmount += amount;
        _itemAmountText.text = "x"+_itemAmount;
    }
    
    public void SetItemSO(ItemSO itemSO)
    {
        _itemSO = itemSO;
    }
    
    public ItemSO GetItemSO()
    {
        return _itemSO;
    }
}
