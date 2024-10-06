using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{   
    public enum EnemyType { Poison, Fire, Ice}

    [SerializeField] private EnemyType _enemyType;
    [SerializeField] private GameObject _poisonAilment;
    [SerializeField] private GameObject _fireAilment;
    [SerializeField] private GameObject _iceAilment;

    [SerializeField] private int _startingHealth = 10;
    [SerializeField] private float _knockBackForce = 15f;

    

    private int _currentHealth;
    private KnockBack _knockBack;

    private void Awake()
    {
        _knockBack = GetComponent<KnockBack>();
    }

    private void Start() {
        _currentHealth = _startingHealth;
    }

    public void TakeDamage(int damage) {
        _currentHealth -= damage;
        // _knockBack.GetNknockedBack(_damageSource: ControllerManager.Instance.transform, _knockBackForce);
        if (_currentHealth <= 0) {
            Die();
        }
    }

    private void Die() 
    {
        SpawnAilment();
        Destroy(gameObject);
    }

    private void SpawnAilment()
    {
        switch (_enemyType)
        {
            case EnemyType.Poison:
                Instantiate(_poisonAilment, transform.position, Quaternion.identity);
                break;
            case EnemyType.Fire:
                Instantiate(_fireAilment, transform.position, Quaternion.identity);
                break;
            case EnemyType.Ice:
                Instantiate(_iceAilment, transform.position, Quaternion.identity);
                break;
            // case EnemyType.Normal:
            //     break;
        }
    }
}
