using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClownBehavior : EnemyController
{
    private void OnBecameVisible()
    {
        if (!GameManager.instance.isLetterShowing() && !GameManager.isGamePaused() && !GameManager.instance.PlayerDied)
        {
            jumpScare.Play();
        }
    }

    public void Update()
    {
        if (GameManager.instance.isLetterShowing() || GameManager.isGamePaused() || GameManager.instance.PlayerDied)
        {
            StopRunning();
            SFX.Stop();
        }
        else
        {
            SetAgents();
            RotateTowardsTarget();

            if (agent.remainingDistance <= 5.0f && agent.hasPath)
            {
                StopRunning();
                GameManager.instance.PlayerDied = true;
                return;
            }
            else StartRunning();
        }


    }
}
