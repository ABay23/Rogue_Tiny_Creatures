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

    private void Awake() 
    {
        _rb = GetComponent<Rigidbody2D>();
        _player = GameObject.Find("Player").transform;   
    }

    private void FixedUpdate() {
        if (_isChasing)
        {
            MoveEnemy();
        }
    }

    private void MoveEnemy()
    {
        Vector2 direction = (_player.position - transform.position).normalized;
        _rb.velocity = new Vector2(direction.x * (_speed * Time.fixedDeltaTime), direction.y * (_speed * Time.fixedDeltaTime));

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
