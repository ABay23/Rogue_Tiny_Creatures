using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    public bool IsGettingKnockedBack { get; private set; }

    [SerializeField] private float _knockBackDuration = 0.2f;

    private Rigidbody2D _rb;

    private void Awake() {
        _rb = GetComponent<Rigidbody2D>();
    }
    
    public void GetKnockedBack(Transform _damageSource, float _knockbackForce)
    {
        IsGettingKnockedBack = true;
        Vector2 _difference = (transform.position - _damageSource.position).normalized;
        _rb.AddForce(_difference * _knockbackForce * _rb.mass, ForceMode2D.Impulse);


    }

}
