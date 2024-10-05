using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerManager : MonoBehaviour
{
    [SerializeField] private float _speed = 5.0f;

    private PlayerController _playerController;
    private Rigidbody2D _rb;
    private Vector2 _movement;

    private void Awake()    
    {
        _playerController = new PlayerController();    
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _playerController.Enable();
    }

    private void Update()
    {
        PlayerActions();
    }

    private void PlayerActions()
    {
        _movement = _playerController.Movement.Move.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        _rb.MovePosition( _rb.position + _movement * _speed * Time.fixedDeltaTime);
    }
}
