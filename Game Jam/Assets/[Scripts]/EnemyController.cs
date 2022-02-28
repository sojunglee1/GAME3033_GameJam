using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Transform player;
    public NavMeshAgent agent;

    public Animator animator;
    public readonly int isRunning = Animator.StringToHash("isRunning");

    public AudioSource jumpScare;
    public AudioSource SFX;

    public GameObject boundingbox;
    public Bounds bound;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        bound = new Bounds(boundingbox.transform.position, boundingbox.GetComponent<BoxCollider>().size);
        SFX.Play();
    }

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
        if (player != null) return bound.Contains(player.position);
        else return false;
    }

    public void StopRunning()
    {
        agent.isStopped = true;
        animator.SetBool(isRunning, false);
    }

    public void StartRunning()
    {
        if (inBoundingBox())
        {
            agent.isStopped = false;
            animator.SetBool(isRunning, true);
        }
    }
}
