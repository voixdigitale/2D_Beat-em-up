using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public static Action<Entity> OnDeath;

    [SerializeField] private int _maxHealth;
    private int _currentHealth;

    private Entity _entity;

    private void Awake() {
        _entity = GetComponent<Entity>();
    }

    public void Start()
    {
         _currentHealth = _maxHealth;
    }

    public void ReduceHealth(int points) {
        if (_currentHealth > points) {
            _currentHealth -= points;
        } else {
            _currentHealth = 0;
            OnDeath?.Invoke(_entity);
        }
    }

    public void IncreaseHealth(int points) {
        if (_currentHealth + points < _maxHealth) {
            _currentHealth += points;
        } else {
            _currentHealth = _maxHealth;
        }
    }

    public int GetHP() => _currentHealth;
}
