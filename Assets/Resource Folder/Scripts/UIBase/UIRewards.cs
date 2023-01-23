using System.Collections;
using System.Collections.Generic;
using OziLib;
using Resource_Folder.Scripts.ScriptableObject;
using Resource_Folder.Scripts.UIScript;
using UnityEngine;

namespace Resource_Folder.Scripts.UIScript
{
    public class UIRewards : UIBase
    {
        [SerializeField] private Transform _contentParent;
        [SerializeField] private RewardPiece _rewardPiecePrefab;
        private SpinSO _spinSO;
        public override void ShowUI<T>(T data)
        {
            base.ShowUI(data);
            _spinSO = Resources.Load<SpinSO>("ScriptableObject/SpinSO");
            if (data is List<RewardData> rewardDatas)
            {
                StartCoroutine(GenerateReward(rewardDatas));
            }
        }

        private IEnumerator GenerateReward(List<RewardData> rewardDatas)
        {
            for (int i = 0; i < rewardDatas.Count; i++)
            {
                var piece = Instantiate(_rewardPiecePrefab, _contentParent);
                piece.SetItemIcon(_spinSO.SpinItemAtlas.GetSprite(rewardDatas[i].item.ItemIconName));
                piece.SetItemAmount(rewardDatas[i].amount);
                piece.RewardStartAnim(.5f,(() =>
                {
                
                }));
                yield return new WaitForSeconds(.5f);
            }
        
            yield return new WaitForSeconds(1.5f);
        
            EventManager.TriggerEvent(EventTags.LEVEL_END,this);
        }
    
    }

    public struct RewardData
    {
        public ItemSO item;
        public int amount;
    }
}