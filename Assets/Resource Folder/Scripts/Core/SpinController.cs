using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpinController : MonoBehaviour
{
    [SerializeField] private SpinSO _spinSO;
    [Header("SpinFields")]
    [SerializeField] private Button _spinButton;
    [SerializeField] private Image _spinIndicatorImage;
    [SerializeField] private Image _spinBaseImage;
    [SerializeField] private Transform _spinBaseTransform;
    [SerializeField] private Transform _spinItemsParent;
    [Header ("Sound")]
    [SerializeField] private AudioSource _audioSource;



    private List<SpinPiece> _spinPieceList;
    private bool _isSpinning;

    #region UNITY_METHODS
    private void Start()
    {
        _spinPieceList = new List<SpinPiece>();
        for (int i = 0; i < _spinItemsParent.childCount; i++)
        {
            _spinPieceList.Add(_spinItemsParent.GetChild(i).GetComponent<SpinPiece>());
        }
        _spinButton.onClick.AddListener(OnSpinButtonClick);
    }



    #endregion

    #region PUBLIC_METHODS

    #endregion

    #region PRIVATE_METHODS
    
    private void OnSpinButtonClick()
    {
        Debug.Log("Spin Button Clicked");
        _isSpinning = true;
        _spinButton.interactable = !_isSpinning;
    }

    #endregion

    #region OVERRIDE_METHODS

    #endregion

    #region EVENTS

    #endregion
}
