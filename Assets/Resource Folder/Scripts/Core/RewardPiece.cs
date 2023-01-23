using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RewardPiece : MonoBehaviour
{
    [SerializeField] private Image _itemIconImage;
    [SerializeField] private TextMeshProUGUI _itemAmountText;
    
    public void SetItemIcon(Sprite icon)
    {
        _itemIconImage.sprite = icon;
    }
    
    public void SetItemAmount(int amount)
    {
        _itemAmountText.text = amount.ToString();
    }
    
    public void RewardStartAnim(float duration,System.Action callback)
    {
        transform.localScale = Vector3.one * 0.01f;
        transform.DOScale(Vector3.one, duration).SetEase(Ease.OutBack).OnComplete(() =>
        {
            callback?.Invoke();
        });
    }
}
