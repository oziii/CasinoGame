using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Resource_Folder.Scripts.ScriptableObject
{
    [CreateAssetMenu(fileName = "ItemSO", menuName = "SO/ItemSO")]
    public class ItemSO : UnityEngine.ScriptableObject
    {
        [SerializeField] private ItemType _itemType;
        [SerializeField] private Sprite _itemIcon;
        [SerializeField] private string _itemName;
        [SerializeField] private int _itemMaxAmount;
        [SerializeField] private int _itemPrice;
        [SerializeField] private int _itemID;
        [Tooltip("Item Chance")]
        [Range(0, 100f)]
        [SerializeField] private float _itemChance;
    
        public Sprite ItemIcon => _itemIcon;
        public string ItemName => _itemName;
        public int ItemPrice => _itemPrice;
        public int ItemID => _itemID;
        public float ItemChance => _itemChance;
        public int İtemMaxAmount => _itemMaxAmount;
    
        public ItemType ItemType => _itemType;
        
        public string ItemIconName => _itemIcon.name;
    }

    public enum ItemType
    {
        Point,
        Weapon,
        Gold,
        Chest,
        Clothes,
        Bomb
    }
}