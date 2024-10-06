using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerManager : MonoBehaviour
{
    public bool FacingLeft { get { return _facingLeft; } set { _facingLeft = value; } }
    // public static ControllerManager Instance;

    [SerializeField] private float _speed = 5.0f;

    private PlayerController _playerController;
    private Rigidbody2D _rb;
    private Vector2 _movement;
    private Animator _animator;
    

    private bool _facingLeft = false;

    private KnockBack _knockBack;

    private void Awake()    
    {
        // Instance = this;
        _playerController = new PlayerController();    
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _knockBack = GetComponent<KnockBack>();
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

        _animator.SetFloat("moveX", _movement.x);
        _animator.SetFloat("moveY", _movement.y);

    }

    private void FixedUpdate()
    {
        MovePlayer();
        FixedDirection();
    }

    private void MovePlayer()
    {
        if (_knockBack.IsGettingKnockedBack)
        {
            return;
        }
        _rb.MovePosition( _rb.position + _movement * _speed * Time.fixedDeltaTime);
    }

    private void FixedDirection()
    {
        if (Input.mousePosition.x - Camera.main.WorldToScreenPoint(transform.position).x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            FacingLeft = true;
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
            FacingLeft = false;
        }
    }
}
