using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSource : MonoBehaviour
{   

    [SerializeField] private int _damageAmount = 2;

    private void OnTriggerEnter2D(Collider2D other) {
        if( other.gameObject.GetComponent<Enemy_Movement>()) 
        {
            EnemyHealth enemyHealth = other.gameObject.GetComponent<EnemyHealth>();
            enemyHealth.TakeDamage(2);
        }
    }
}
