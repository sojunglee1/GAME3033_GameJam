using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Transform player;
    public NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    public void SetAgents()
    {
        agent.SetDestination(player.position);
        agent.speed = 1f;
    }

    public void RotateTowardsTarget()
    {
        if (agent.isStopped)
        {
            
            transform.LookAt(player);
            transform.eulerAngles = new Vector3 (0, transform.eulerAngles.y, transform.eulerAngles.z);
        }
    }
}
