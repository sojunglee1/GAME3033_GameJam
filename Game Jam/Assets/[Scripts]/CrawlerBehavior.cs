using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrawlerBehavior : EnemyController
{
    private void OnBecameVisible()
    {
        if ((GameManager.instance.isLetterShowing() && GameManager.isGamePaused() && GameManager.instance.PlayerDied).Equals(false) &&
    agent.remainingDistance <= 10.0f)
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

            if (agent.remainingDistance <= 5.0f && agent.remainingDistance > 1.0f)
            {
                print(agent.remainingDistance);
                StopRunning();
                GameManager.instance.PlayerDied = true;
                return;
            }
            else StartRunning();
        }
    }
}

