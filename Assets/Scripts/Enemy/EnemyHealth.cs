using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int _startingHealth = 10;

    private int _currentHealth;

    private void Start() {
        _currentHealth = _startingHealth;
    }

    public void TakeDamage(int damage) {
        _currentHealth -= damage;
        Debug.Log("Current health: " + _currentHealth);
        if (_currentHealth <= 0) {
            Die();
        }
    }

    private void Die() {
        Destroy(gameObject);
    }
}
