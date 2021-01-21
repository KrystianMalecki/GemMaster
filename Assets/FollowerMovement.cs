using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
public class FollowerMovement : MonoBehaviour
{
    public PlayerScript playerScirpt;
    public BlockAccesPoint targetPoint;
    public List<BlockAccesPoint> BAPsInRange = new List<BlockAccesPoint>();
    public bool moveToBAP;
    public float moveSpeed;
    public bool attachedToBAP;
    public Transform img;
    public Vector2 moveDir => targetPosition - new Vector2(transform.position.x, transform.position.y);
    public float targetDistSqr => moveDir.sqrMagnitude;

    public Vector2 targetPosition
    {
        get
        {
            if (moveToBAP)
            {
                return targetPoint.transform.position;
            }
            else
            {
                return playerScirpt.lightPoint.position;

            }
        }
    }
    void Start()
    {
        Bop();
    }
    void Bop()
    {
        img.transform.DOLocalMoveY(0.2f, 1f).OnComplete(Bap);
    }
    void Bap()
    {
        img.transform.DOLocalMoveY(-0.2f, 1f).OnComplete(Bop);


    }
    void Update()
    {
        if (!attachedToBAP)
        {
            if (targetDistSqr > 0.2f)
            {
                transform.Translate(moveDir.normalized * moveSpeed);
                transform.localScale = new Vector3(playerScirpt.facingRight ? -1 : 1, 1, 1);
            }
            if (moveToBAP)
            {
                if (targetDistSqr < 0.2f)
                {
                    targetPoint.Attach(this);
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!attachedToBAP)
            {
                 
                    BlockAccesPoint bap= GetClosestBAP();
                if (bap != null)
                {

                    targetPoint = bap;
                    moveToBAP = true;
                }
            }
            else
            {
                targetPoint.Deattach();
                moveToBAP = false;
            }
        }

    }

    BlockAccesPoint GetClosestBAP()
    {
        if (BAPsInRange.Count == 0)
        {
            return null;
        }
        float currDist = 10000f;
        int currId = 0;
        for (int i = 0; i < BAPsInRange.Count; i++)
        {
            float dist = (BAPsInRange[i].transform.position - transform.position).sqrMagnitude;
            if (currDist >= dist)
            {
                currDist = dist;
                currId = i;
            }
        }
        return BAPsInRange[currId];
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BAP"))
        {
            BAPsInRange.Add(collision.GetComponent<BlockAccesPoint>());
        }

    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("BAP"))
        {
            BAPsInRange.Remove(collision.GetComponent<BlockAccesPoint>());
        }

    }
}
