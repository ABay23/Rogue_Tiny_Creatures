using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{
    [SerializeField] private float _speed = 3.5f;
    private bool _isChasing;
    private Transform _player;
    private bool _isFacingRight = true;

    private Rigidbody2D _rb;
    private KnockBack _knockBack;

    private void Awake() 
    {
        _rb = GetComponent<Rigidbody2D>();
        _player = GameObject.Find("Player").transform;   
        _knockBack = GetComponent<KnockBack>();
    }

    private void FixedUpdate() {
        if (_isChasing && !_knockBack.IsGettingKnockedBack)
        {
            MoveEnemy();
        }
    }

    private void MoveEnemy()
    {
        Vector2 direction = (_player.position - transform.position).normalized;
        _rb.velocity = direction * _speed;

        // Check if the player is on the right side of the enemy
        if (_player.position.x > transform.position.x && _isFacingRight)
        {
            Flip();
        }
        else if (_player.position.x < transform.position.x && !_isFacingRight)
        {
            Flip();
        } 
    }

        private void Flip()
        {
            // Flip the facing direction
            _isFacingRight = !_isFacingRight;
            // Rotate the enemy to face the opposite direction
            transform.Rotate(0f, 180f, 0f);
        }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        _isChasing = true;
    }
}
