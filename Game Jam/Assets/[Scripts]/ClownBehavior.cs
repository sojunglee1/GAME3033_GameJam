using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClownBehavior : EnemyController
{
    public Animator animator;
    public readonly int isRunning = Animator.StringToHash("isRunning");

    public void Update()
    {
        if (GameManager.instance.isLetterShowing() || GameManager.isGamePaused())
        {
            animator.SetBool(isRunning, false);
            return;
        }
        else
        {
            SetAgents();
            RotateTowardsTarget();

            if (agent.remainingDistance <= 5.0f && agent.hasPath)
            {
                GameManager.instance.PlayerDied = true;
                agent.isStopped = true;
                animator.SetBool(isRunning, false);
            }
            else if (inBoundingBox())
            {
                agent.isStopped = false;
                animator.SetBool(isRunning, true);
            }
        }
    }
}
