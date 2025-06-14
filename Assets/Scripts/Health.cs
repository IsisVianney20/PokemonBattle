using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField]
    private Slider _healthSlider;

    [SerializeField]
    private float _initialHealth = 200f;

    [SerializeField]
    private UnityEvent<float> _onUpdateHealth;

    [SerializeField]
    private UnityEvent _onDefeated;

    [SerializeField]
    private UnityEvent _onTakeDamage;

    private float _currentHeath;

    public float CurrentHealth => _currentHeath;

    public void InitialHealth()
    {
        _currentHeath = _initialHealth;
        UpdateHealth();
    }

    private void UpdateHealth()
    {
        _onUpdateHealth?.Invoke(_currentHeath / _initialHealth);
    }

    public void TakeDamage(float damage)
    {
        _currentHeath -= damage;
        if (_currentHeath < 0)
        {
            _onDefeated?.Invoke();
            _currentHeath = 0;
        }
        else
        {
            _onTakeDamage?.Invoke();
        }
        UpdateHealth();
    }
}
