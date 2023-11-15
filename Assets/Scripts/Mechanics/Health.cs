using UnityEngine;

public class Health : MonoBehaviour
{
    private int _maxHealth;
    private int _currentHealth;
    
    public void Init(int maxHealth)
    {
        _maxHealth = _currentHealth = maxHealth;
    }
}
