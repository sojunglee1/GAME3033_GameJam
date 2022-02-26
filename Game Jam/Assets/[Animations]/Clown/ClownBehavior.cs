using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClownBehavior : EnemyController
{
    public Animator animator;
    public readonly int reset = Animator.StringToHash("ResetAnimation");

    public void Update()
    {
        SetAgents();
        if (agent.remainingDistance < 5.0f)
        {
            agent.isStopped = true;
            animator.SetTrigger(reset);
        }

        
    }
}
