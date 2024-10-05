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

    private void Update() {
        if (_isChasing)
        {
            MoveEnemy();
        }
    }

    private void MoveEnemy()
    {
        Vector2 direction = (_player.position - transform.position).normalized;
        _rb.velocity = new Vector2(direction.x * _speed, direction.y * _speed);
        // float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        // _rb.rotation = angle;
        // direction.Normalize();
        // _rb.MovePosition((Vector2)transform.position + (direction * _speed * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        _isChasing = true;
    }
}
