using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private RectTransform _barRect; // The RectTransform of the health bar
    [SerializeField] private RectMask2D _mask; // Mask component for the health bar
    [SerializeField] private TMP_Text _hpIndicator; // Text to show current HP

    private PlayerHealth _playerHealth; // Reference to PlayerHealth

    private float _maxRightMask; // The maximum width of the mask
    private float _initialRightMask; // Initial mask width

    private void Start()
    {
        _playerHealth = FindObjectOfType<PlayerHealth>(); 
        _maxRightMask = _barRect.rect.width;
        UpdateHealthBar();
    }

    public void SetValue(int newValue)
    {
        if (_playerHealth == null) return; 

        
        float targetWidth = newValue * _maxRightMask / _playerHealth.MaxHP;

        
        _barRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, targetWidth);

     
        Vector3 newPosition = _barRect.localPosition;
        newPosition.x = (_maxRightMask - targetWidth) / 2; 
        _barRect.localPosition = newPosition;

        UpdateHealthBar(); 
    }

    private void UpdateHealthBar()
    {
        if (_playerHealth != null)
        {
            _hpIndicator.SetText($"{_playerHealth.HP}/{_playerHealth.MaxHP}");
        }
    }
}
