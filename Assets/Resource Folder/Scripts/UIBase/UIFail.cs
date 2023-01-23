using System.Collections;
using System.Collections.Generic;
using OziLib;
using Resource_Folder.Scripts.UIScript;
using UnityEngine;
using UnityEngine.UI;

public class UIFail : UIBase
{
    [SerializeField] private Button _giveUpButton;
    [SerializeField] private Button _reviveButton;
    
    public override void ShowUI()
    {
        _giveUpButton.onClick.AddListener(OnGiveUpButtonClick);
        _reviveButton.onClick.AddListener(OnReviveButtonClick);
        base.ShowUI();
    }
    
    public override void HideUI()
    {
        _giveUpButton.onClick.RemoveListener(OnGiveUpButtonClick);
        _reviveButton.onClick.RemoveListener(OnReviveButtonClick);
        base.HideUI();
    }

    private void OnReviveButtonClick()
    {
        EventManager.TriggerEvent(EventTags.LEVEL_COMPLETE, this);
        HideUI();
    }

    private void OnGiveUpButtonClick()
    {
        EventManager.TriggerEvent(EventTags.LEVEL_END, this);
        HideUI();
    }
}
