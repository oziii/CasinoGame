using UnityEngine;

namespace Resource_Folder.Scripts.UIScript
{
    public abstract class UIBase : MonoBehaviour
    {
        [SerializeField] protected UIType _uiType;

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
        
        public UIType GetUIType()
        {
            return _uiType;
        }
    
    }
    
    public enum UIType
    { 
        Game,
        Exit,
        Fail,
        Rewards
    }
}
