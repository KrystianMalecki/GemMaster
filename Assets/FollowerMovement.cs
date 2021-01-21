using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerMovement : MonoBehaviour
{
    public PlayerScript playerScirpt;
    public Transform targetPoint;
    public float moveSpeed;
    public Vector2 moveDir => targetPosition -new Vector2( transform.position.x, transform.position.y);
    public float targetDistSqr => moveDir.sqrMagnitude;

    public Vector2 targetPosition
    {
        get
        {
            return playerScirpt.lightPoint.position;
        }
    }
    public void Update()
    {
        if (targetDistSqr > 0.2f)
        {
            transform.Translate(moveDir.normalized * moveSpeed);
            transform.localScale = new Vector3(playerScirpt.facingRight?-2:2,2,2);
        }
    }
}
