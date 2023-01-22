using UnityEngine;

namespace Resource_Folder.Scripts.ScriptableObject
{
    [CreateAssetMenu(fileName = "GeneralSettingsSO", menuName = "SO/GeneralSettingsSO")]
    public class GeneralSettingsSO : UnityEngine.ScriptableObject
    {
        [SerializeField] private int _silverEachLevel=5;
        [SerializeField] private int _goldEachLevel=30;
        
        public int SilverEachLevel => _silverEachLevel;
        public int GoldEachLevel => _goldEachLevel;
    }
}
