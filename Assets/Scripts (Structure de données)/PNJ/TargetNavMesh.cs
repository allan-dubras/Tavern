using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TargetNavMesh : MonoBehaviour
{
    [SerializeField]
    public GameObject goal;

    private NavMeshAgent agent;
    private void Start()
    {
        agent=this.GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        agent.SetDestination(goal.transform.position);
    }
}
