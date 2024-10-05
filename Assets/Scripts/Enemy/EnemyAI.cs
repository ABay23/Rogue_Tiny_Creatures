using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private enum State {
        Roaming
    }

    private State _state;
    private EnemyPathfinder _enemyPathfinder;

    private void Awake()
    {
        _enemyPathfinder = GetComponent<EnemyPathfinder>();
        _state = State.Roaming;
    }
}
