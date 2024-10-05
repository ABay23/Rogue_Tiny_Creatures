using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerManager : MonoBehaviour
{
    [SerializeField] private float _speed = 5.0f;

    private PlayerController _playerController;
    private Rigidbody2D _rb;

    private void Awake()    
    {
        playerController = new PlayerController();    
    }
}
