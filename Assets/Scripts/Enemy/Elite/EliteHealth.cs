using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliteHealth : MonoBehaviour , IDamageable
{
    [SerializeField] private int _startingHealth = 10;

    private int _currentHealth;

    private void Start() 
    {
        _currentHealth = _startingHealth;
    }

    public void TakeDamage(int damage, Transform _damageSource) 
    {
        _currentHealth -= damage;
        Debug.Log($"Elite took {damage} damage. Current health: {_currentHealth}");
        CheckDeath();
        
    }

    private void CheckDeath() 
    {   
        if (_currentHealth <= 0) 
        {
            Destroy(gameObject);
        }
    }
}
