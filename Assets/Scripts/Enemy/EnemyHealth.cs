using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int _startingHealth = 10;
    [SerializeField] private float _knockBackForce = 15f;

    

    private int _currentHealth;
    private KnockBack _knockBack;

    private void Awake()
    {
        _knockBack = GetComponent<KnockBack>();
    }

    private void Start() {
        _currentHealth = _startingHealth;
    }

    public void TakeDamage(int damage) {
        _currentHealth -= damage;
        // _knockBack.GetNknockedBack(_damageSource: ControllerManager.Instance.transform, _knockBackForce);
        if (_currentHealth <= 0) {
            Die();
        }
    }

    private void Die() {
        Destroy(gameObject);
    }
}
