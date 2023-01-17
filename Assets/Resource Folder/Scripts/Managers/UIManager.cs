using System.Collections;
using System.Collections.Generic;
using OziLib;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    #region UNITY_METHODS

    private void OnEnable()
    {
        EventManager.StartListening(EventTags.LEVEL_START, OnGameStart);
        EventManager.StartListening(EventTags.LEVEL_START, OnGameEnd);
    }

    private void OnDisable()
    {
        EventManager.StopListening(EventTags.LEVEL_START, OnGameStart);
        EventManager.StopListening(EventTags.LEVEL_START, OnGameEnd);
    }
    
    #endregion
    
    #region PUBLIC_METHODS
    
    #endregion
    
    #region PRIVATE_METHODS
    
    #endregion
    
    #region OVERRIDE_METHODS
    
    #endregion

    #region EVENTS
    
    private void OnGameEnd(object arg0)
    {
        
    }

    private void OnGameStart(object arg0)
    {
        
    }
    
    #endregion
}

#region UNITY_METHODS

#endregion
    
#region PUBLIC_METHODS
    
#endregion
    
#region PRIVATE_METHODS
    
#endregion
    
#region OVERRIDE_METHODS
    
#endregion

#region EVENTS

#endregion