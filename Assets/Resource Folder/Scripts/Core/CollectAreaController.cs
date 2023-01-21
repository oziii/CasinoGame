using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using OziLib;
using UnityEngine;

public class CollectAreaController : MonoBehaviour
{
    [SerializeField] private CollectAreaSO _collectAreaSO;
    [SerializeField] private Transform _contentParent;

    private List<CollectPiece> _collectPieces;
    
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
    }

    #endregion
    
    #region PUBLIC_METHODS
    
    #endregion
    
    #region PRIVATE_METHODS

    private void CreateCollectItem(SpinPiece spinPiece)
    {
        var collectItem = _collectPieces.FirstOrDefault(x => x.GetItemSO() == spinPiece.GetItem());
        if (collectItem == null)
        {
            collectItem = Instantiate(_collectAreaSO.CollectPiecePrefab, _contentParent);
            collectItem.SetItemSO(spinPiece.GetItem());
            _collectPieces.Add(collectItem);
        }
        collectItem.SetPiece(spinPiece.GetItem().ItemIcon, spinPiece.GetAmount());
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
                EventManager.TriggerEvent(EventTags.LEVEL_FAIL, this);
                return;
            }
            //Collect UI bir şeyler yap
            EventManager.TriggerEvent(EventTags.LEVEL_COMPLETE, this);
            CreateCollectItem(spinPiece);
        }
    }
    
    #endregion
}
