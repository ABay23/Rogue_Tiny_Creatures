using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    
    private PlayerController _playerController;
    private Animator _animator;

    private void Awake() {
        _animator = GetComponent<Animator>();
        _playerController = GetComponent<PlayerController>();
    }

    void Start()
    {
        _playerController.Combat.Attack.started +=_animator => Attack();
    }

    private void Attack()
    {
        _animator.SetTrigger("Attack");
    }
}
