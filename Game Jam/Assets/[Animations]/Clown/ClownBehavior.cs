using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClownBehavior : EnemyController
{
    public Animator animator;
    public readonly int isRunning = Animator.StringToHash("isRunning");
    public readonly int isStanding = Animator.StringToHash("isStanding");

    public void Update()
    {
        SetAgents();
        RotateTowardsTarget();
        if (agent.remainingDistance <= 10.0f)
        {
            agent.isStopped = true;
            animator.SetBool(isRunning, false);
        }
        else
        {
            agent.isStopped = false;
            animator.SetBool(isRunning, true);
        }
        
    }

}
