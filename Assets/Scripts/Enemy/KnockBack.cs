using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    public bool IsGettingKnockedBack { get; private set; }

    [SerializeField] private float _knockBackDuration = 3f;

    private Rigidbody2D _rb;

    private void Awake() {
        _rb = GetComponent<Rigidbody2D>();
    }
    
    public void GetKnockedBack(Transform _damageSource, float _knockBackForce)
    {
        if (!IsGettingKnockedBack)
        {
        IsGettingKnockedBack = true;
        Vector2 _difference = (transform.position - _damageSource.position).normalized;
        Debug.Log($"KnockBack applied to {gameObject.name} with force {_knockBackForce}");
        _rb.AddForce(_difference * _knockBackForce * _rb.mass, ForceMode2D.Impulse);

        StartCoroutine(KnockBackRoutine());
        }
    }

    private IEnumerator KnockBackRoutine()
    {
        yield return new WaitForSeconds(_knockBackDuration);
        IsGettingKnockedBack = false;
    }

}
