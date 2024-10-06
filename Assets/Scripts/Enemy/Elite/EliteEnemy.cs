using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EliteEnemy : MonoBehaviour
{
    [SerializeField] private float _meleeRange = 10f;
    [SerializeField] private int _meleeDamage = 5;
    [SerializeField] private float _attackCooldown = 2f;

    private Transform _player;
    private float _lastAttackTime;
    private Animator _animator;
    private PlayerHealth _playerHealth;

    private void Awake() {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _playerHealth =  GetComponent<PlayerHealth>();
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
        // _animator.SetTrigger("Attack"); // Assuming you have an Animator

        // Deal damage to the player
        if (_playerHealth != null)
        {
            _playerHealth.TakeDamage(_meleeDamage);
            Debug.Log("Player took damage");
        }
    Debug.Log("Attacking Player");
        }
}
