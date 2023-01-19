using System;
using System.Collections;
using System.Collections.Generic;
using OziLib;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region UNITY_METHODS

    private void Start()
    {
        EventManager.TriggerEvent(EventTags.LEVEL_READY, 1);
    }

    #endregion
    
    #region PUBLIC_METHODS
    
    #endregion
    
    #region PRIVATE_METHODS
    
    #endregion
    
    #region OVERRIDE_METHODS
    
    #endregion

    #region EVENTS

    #endregion
}
