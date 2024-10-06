using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyElements : MonoBehaviour
{
    public enum EnemyType { Poison, Fire, Ice, Normal }

    [SerializeField] private EnemyType _enemyType;
    [SerializeField] private GameObject _poisonAilment;
    [SerializeField] private GameObject _fireAilment;
    [SerializeField] private GameObject _iceAilment;

    
}
