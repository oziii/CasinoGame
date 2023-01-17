using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIBase : MonoBehaviour
{
    public virtual void ShowUI()
    {
        gameObject.SetActive(true);
    }
    
    public virtual void HideUI()
    {
        gameObject.SetActive(false);
    }
    
    public virtual void UpdateUI<T>(T data)
    {
        // Update UI
    }
    
    public virtual void UpdateUI()
    {
        // Update UI
    }
    
}
