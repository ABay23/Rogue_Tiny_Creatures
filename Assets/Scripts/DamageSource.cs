using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSource : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if( other.gameObject.GetComponent<Enemy_Movement>()) 
        {
    Debug.Log("Enemy hit");
        }
    }
}
