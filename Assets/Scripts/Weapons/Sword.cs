using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    
    [SerializeField] private GameObject _swingEffect;
    [SerializeField] private Transform _swingEffectPosition;
    [SerializeField] private Transform _weaponCollider;


    private PlayerController _playerController;
    private Animator _animator;
    private ControllerManager _controllerManager;
    private ActiveWeapon _activeWeapon;

    private GameObject _slashAnimation;

    private void Awake() {
        _animator = GetComponent<Animator>();
        _playerController = new PlayerController();
        _controllerManager = GetComponentInParent<ControllerManager>();
        _activeWeapon = GetComponentInParent<ActiveWeapon>();
        _weaponCollider = GetComponent<Transform>();
        
    }

    private void OnEnable() {
        _playerController.Enable();
    }

    void Start()
    {
        _playerController.Combat.Attack.started += _ => Attack();
    }

    private void Attack()
    {
        _animator.SetTrigger("Attack");
        _weaponCollider.gameObject.SetActive(true);
        
    
        _slashAnimation = Instantiate(_swingEffect, _swingEffectPosition.position, Quaternion.identity.normalized);
        _slashAnimation.transform.parent = this.transform.parent;
        SwingAnimation();
    }

    private void DoneAttacking()
    {
        _weaponCollider.gameObject.SetActive(false);
    }

    public void SwingAnimation()
    {
        _slashAnimation.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);

        if ( _controllerManager.FacingLeft)
        {
            _slashAnimation.GetComponent<SpriteRenderer>().flipX = true;
        }
        
    }

    private void MouseFollow()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 playerCreenPosition = Camera.main.WorldToScreenPoint(_controllerManager.transform.position);

        float angle = Mathf.Atan2(mousePosition.y, mousePosition.x) * Mathf.Rad2Deg;

        if (mousePosition.x < playerCreenPosition.x)
        {
            _activeWeapon.transform.rotation = Quaternion.Euler(180, 0, -angle);
            _weaponCollider.transform.rotation = Quaternion.Euler(180, 0, -angle);
        }
        else
        {
            _activeWeapon.transform.rotation = Quaternion.Euler(0, 0, angle);
            _weaponCollider.transform.rotation = Quaternion.Euler(0, 0, angle);
        }

        
    }
}
