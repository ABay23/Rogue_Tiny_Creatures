using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSource : MonoBehaviour
{   

    [SerializeField] private int _damageAmount = 2;
    [SerializeField] private Transform _damageSource;

    private void OnTriggerEnter2D(Collider2D other) 
    { 
        IDamageable damageable = other.gameObject.GetComponent<IDamageable>();
        if( damageable != null) 
        {
            damageable.TakeDamage( _damageAmount, _damageSource);
        }

        // if( other.gameObject.GetComponent<Enemy_Movement>()) 
        // {
        //     EnemyHealth enemyHealth = other.gameObject.GetComponent<EnemyHealth>();
        // }
    }
}
