using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WallMovementType
{
    Forward,
    Backward,
    Left, 
    Right
}

public class WallBehavior : MonoBehaviour
{
    public WallMovementType type;    
    public bool isTouchingWall;
    public bool canMove;

    public GameObject player;

    private void Update()
    {
        if (canMove)
        {
            Move();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canMove = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canMove = false;
        }
    }

    private void Move()
    {
        //if (transform.parent.position.x > player.transform.position.x) type = WallMovementType.Forward;
        //else if (transform.parent.position.x < player.transform.position.x) type = WallMovementType.Backward;
        //else if (transform.parent.position.z > player.transform.position.z) type = WallMovementType.Left;
        //else if (transform.parent.position.z < player.transform.position.z) type = WallMovementType.Right;

        //switch (type)
        //{
        //    case WallMovementType.Forward:
        //    case WallMovementType.Backward:
        //        transform.parent.position = new Vector3(Mathf.Lerp(transform.parent.position.x, player.transform.position.x, Time.deltaTime * 0.25f),
        //            transform.parent.position.y);
        //        break;

        //    case WallMovementType.Left:
        //    case WallMovementType.Right:
        //        transform.parent.position = new Vector3(transform.parent.position.x, transform.position.y,
        //            Mathf.Lerp(transform.parent.position.z, player.transform.position.z, Time.deltaTime * 0.25f));
        //        break;
        //}

        //transform.parent.position += Vector3.right * Time.deltaTime;

        transform.parent.position += (player.gameObject.transform.position - transform.parent.position).normalized * Time.deltaTime;
    }
}
