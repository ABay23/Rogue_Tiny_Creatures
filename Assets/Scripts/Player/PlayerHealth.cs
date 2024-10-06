using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _startingHealth = 500;
    [SerializeField] private float _knockBackForce = 10f;
    
    private KnockBack _knockBack;
    private int _currentHealth;
    private Transform _enemyCollision;

    
    private void Awake() 
    {
        _knockBack = GetComponent<KnockBack>();
        // _enemyCollision = GameObject.Find("Enemy").transform;
    }
    
    private void Start() 
    {
        _currentHealth = _startingHealth;
    }

    private void OnCollisionStay2D(Collision2D other) 
    {
        _enemyCollision = other.gameObject.tag == "Enemy" ? other.transform : _enemyCollision;

        if (_enemyCollision)
        {
            TakeDamage(1);

            _knockBack.GetKnockedBack(_enemyCollision, _knockBackForce);
        }
    }

    public void TakeDamage( int damage)
    {
        _currentHealth -= damage;
        Debug.Log($"Player took {damage} damage. Current health: {_currentHealth}");
        CheckDeath();
    }

    private void CheckDeath()
    {
        if (_currentHealth <= 0)
        {
            // Destroy(gameObject);
            Debug.Log("Player is dead");
        }
    }
}
