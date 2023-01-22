using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Resource_Folder.Scripts.Core
{
    public class LevelPiece : MonoBehaviour
    {
        [SerializeField] private Image _backgroundImage;
        [SerializeField] private Image _selectedImage;
        [SerializeField] private TextMeshProUGUI _levelText;
        private Tween _selectedTween;
    
        public void SetBackground(Sprite sprite, int level)
        {
            _backgroundImage.sprite = sprite;
            _levelText.text = level.ToString();
        }

        public void SelectedLevel()
        {
            _selectedImage.gameObject.SetActive(true);
            _selectedTween = _selectedImage.DOColor(Color.black, 0.5f).SetLoops(-1, LoopType.Yoyo);
        }
        
        public void DeselectedLevel()
        {
            _selectedTween?.Kill();
            _selectedImage.gameObject.SetActive(false);
        }
    }
}
