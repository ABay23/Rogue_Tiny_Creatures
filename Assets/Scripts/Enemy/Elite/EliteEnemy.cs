using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EliteEnemy : MonoBehaviour
{
    [SerializeField] private float _meleeRange = 10f;
    [SerializeField] private float _meleeDamage = 5f;
    [SerializeField] private float _attackCooldown = 2f;

    private Transform _player;
    private float _lastAttackTime;

    private void Awake() {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update() 
    {
        float _distanceToPlayer = Vector2.Distance(transform.position, _player.position);

        if (_distanceToPlayer <= _meleeRange && Time.time >= _lastAttackTime + _attackCooldown)
        {
            MeleeAttack();
            _lastAttackTime = Time.time;
        }
    }

    private void MeleeAttack()
    {
        // Trigger attack animation
    // Animator.SetTrigger("Attack"); // Assuming you have an Animator

    // Deal damage to the player
    // PlayerHealth playerHealth = playerTransform.GetComponent<PlayerHealth>();
    // if (playerHealth != null)
    // {
    //     playerHealth.TakeDamage(meleeDamage);
    // }
Debug.Log("Attacking Player");
    }
}
