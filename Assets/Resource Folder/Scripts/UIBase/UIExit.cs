using System.Collections;
using System.Collections.Generic;
using OziLib;
using Resource_Folder.Scripts.UIScript;
using UnityEngine;
using UnityEngine.UI;

public class UIExit : UIBase
{
   [SerializeField] private Button _collectRewardsButton;
   [SerializeField] private Button _goBackButton;
   
   public override void ShowUI()
   {
      
      _collectRewardsButton.onClick.AddListener(OnCollectRewardsButtonClick);
      _goBackButton.onClick.AddListener(OnGoBackButtonClick);
      base.ShowUI();
   }
   
   public override void HideUI()
   {
      _collectRewardsButton.onClick.RemoveListener(OnCollectRewardsButtonClick);
      _goBackButton.onClick.RemoveListener(OnGoBackButtonClick);
      base.HideUI();
   }
   
   private void OnCollectRewardsButtonClick()
   {
      EventManager.TriggerEvent(EventTags.COLLECT_REWARD, this);
      HideUI();
   }
   
   private void OnGoBackButtonClick()
   {
      HideUI();
   }
}
