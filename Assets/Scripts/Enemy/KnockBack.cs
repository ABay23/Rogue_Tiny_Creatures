using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    public bool _gettingKnockedBack { get; private set; }
    private Rigidbody2D _rb;
    
    public void GetNknockedBack(Transform _damageSource, float _knockbackForce)
    {
        _gettingKnockedBack = true;
        Vector2 _difference = (transform.position - _damageSource.position).normalized * _knockbackForce * _rb.mass;
        _rb.AddForce(_difference * _knockbackForce, ForceMode2D.Impulse);


    }

}
