using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    private int _currentHealth;
    
    public void Start()
    {
        _maxHealth = _currentHealth;
    }
}
