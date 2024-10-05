using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{
    [SerializeField] private float _speed = 3.5f;
    private bool _isChasing;
    // [SerializeField]//
    private Transform _player;

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
        _rb.velocity = new Vector2(direction.x * ( _speed * Time.fixedDeltaTime), direction.y * (_speed * Time.fixedDeltaTime));
        // float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        // transform.rotation = Quaternion.Euler(0, 0, angle -180);
        // // _rb.rotation = angle;
        // direction.Normalize();
        // tranform
        // _rb.MovePosition((Vector2)transform.position + (direction * _speed * Time.fixedDeltaTime));
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        _isChasing = true;
    }
}
