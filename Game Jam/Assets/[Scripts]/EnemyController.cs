using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Transform player;
    public NavMeshAgent agent;

    public GameObject boundingbox;
    public Bounds bound;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        bound = new Bounds(boundingbox.transform.position, boundingbox.GetComponent<BoxCollider>().size);
    }

    // Update is called once per frame
    public void SetAgents()
    {
        agent.SetDestination(player.position);
    }

    public void RotateTowardsTarget()
    {
        if (agent.isStopped)
        {
            transform.LookAt(player);
            transform.eulerAngles = new Vector3 (0, transform.eulerAngles.y, transform.eulerAngles.z);
        }
    }

    public bool inBoundingBox()
    {
        return bound.Contains(player.position);
    }
}
