using System;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using OziLib;
using Resource_Folder.Scripts.Managers;
using Resource_Folder.Scripts.ScriptableObject;
using UnityEngine;
using UnityEngine.UI;

namespace Resource_Folder.Scripts.Core
{
    public class CollectAreaController : MonoBehaviour
    {
        [SerializeField] private CollectAreaSO _collectAreaSO;
        [SerializeField] private Transform _contentParent;
        [SerializeField] private Image _rewardItemImage;
        
        private List<CollectPiece> _collectPieces;
        private SpinSO _spinSO;
        #region UNITY_METHODS

        private void OnEnable()
        {
            EventManager.StartListening(EventTags.SPIN_END, OnSpinEnd);
        }
    
        private void OnDisable()
        {
            EventManager.StopListening(EventTags.SPIN_END, OnSpinEnd);
        }

        private void Start()
        {
            _collectPieces = new List<CollectPiece>();
            _spinSO = Resources.Load<SpinSO>("ScriptableObject/SpinSO");
        }

        #endregion
    
        #region PUBLIC_METHODS
    
        #endregion
    
        #region PRIVATE_METHODS

        private void CreateCollectItem(SpinPiece spinPiece)
        {
            var collectItem = _collectPieces.Find(x => x.GetItemSO() == spinPiece.GetItem());
            if (collectItem == null)
            {
                collectItem = Instantiate(_collectAreaSO.CollectPiecePrefab, _contentParent);
                collectItem.SetItemSO(spinPiece.GetItem());
                _collectPieces.Add(collectItem);
            }
            collectItem.SetPiece(_spinSO.SpinItemAtlas.GetSprite(spinPiece.GetItem().ItemIconName), spinPiece.GetAmount());
            GameManager.Instance.AddRewardPiece(collectItem);
        }

        private void CollectItemAnim(SpinPiece spinPiece, Action callback)
        {
            _rewardItemImage.sprite = _spinSO.SpinItemAtlas.GetSprite(spinPiece.GetItem().ItemIconName);
            _rewardItemImage.transform.localScale = Vector3.one * .1f;
            _rewardItemImage.gameObject.SetActive(true);
            _rewardItemImage.transform.DOScale(Vector3.one, .5f)
                .SetEase(Ease.OutBack)
                .OnComplete(() =>
                {
                    _rewardItemImage.transform.DOScale(Vector3.one * .1f, .5f)
                        .SetEase(Ease.InBack)
                        .SetDelay(.7f)
                        .OnComplete(() =>
                        {
                            _rewardItemImage.gameObject.SetActive(false);
                            callback?.Invoke();
                        });
                });
        }
    
        #endregion
    
        #region OVERRIDE_METHODS
    
        #endregion

        #region EVENTS

        private void OnSpinEnd(object arg0)
        {
            if (arg0 is SpinPiece spinPiece)
            {
                if (spinPiece.GetItem().ItemType == ItemType.Bomb)
                {
                    Debug.Log("Level Fail");
                    EventManager.TriggerEvent(EventTags.LEVEL_FAIL, this);
                    return;
                }

                Debug.Log("Level Completed");
                CollectItemAnim(spinPiece, () =>
                {
                    CreateCollectItem(spinPiece);
                    EventManager.TriggerEvent(EventTags.LEVEL_COMPLETE, this);
                });
            }
        }
    
        #endregion
    }
}
