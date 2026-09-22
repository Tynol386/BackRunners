using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy_ai : MonoBehaviour
{
    [SerializeField] private Transform movePositionTransform ;

    private NavMeshAgent navMeshAgent;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        //transform.LookAt(new Vector3(0, 0, 0));
        navMeshAgent.destination = movePositionTransform.position;
    }
}
