using NaughtyAttributes;
using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using CodeHelper;
public class FollowerMovement : MonoBehaviour
{
    [SerializeField]
    private bool showMoreData;

    [Foldout("Static Data")] public PlayerScript playerScirpt;
    [Foldout("Static Data")] public BlockAccesPoint targetBAP;
    List<BlockAccesPoint> BAPsInRange = new List<BlockAccesPoint>();
    bool moveToBAP;
    public float moveSpeed;
    bool attachedToBAP;
    [Foldout("Static Data")] public Transform img;
    Vector2 moveDir => targetPosition - transform.position.ToVector2();// new Vector2(transform.position.x, transform.position.y);
    float targetDistSqr => moveDir.sqrMagnitude;
    public float speeder;
    Vector3 realPosition;
    public void Attach()
    {
        attachedToBAP = true;
        img.gameObject.SetActive(false);
    }
    public void Deattach()
    {
        img.gameObject.SetActive(true);
        attachedToBAP = false;

    }

    Vector2 targetPosition
    {
        get
        {
            if (moveToBAP)
            {
                return targetBAP.transform.position;
            }
            else
            {
                return playerScirpt.tvPoint.position;

            }
        }
    }
    private void Awake()
    {
      //  realPosition = transform.localPosition;
    }
    void Start()
    {
        // Bop();
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

                transform.Translate(moveDir.normalized * moveSpeed * Time.deltaTime);
             //   realPosition += moveDir.normalized.ToVector3() * moveSpeed * Time.deltaTime;
                // transform.localPosition = realPosition.AlignToPixel();
                transform.localScale = new Vector3(playerScirpt.facingRight ? -1 : 1, 1, 1);

            }
            if (moveToBAP)
            {
                if (targetDistSqr < 0.2f)
                {
                    targetBAP.Attach(this);
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (!attachedToBAP)
            {

                BlockAccesPoint bap = GetClosestBAP();
                if (bap != null)
                {

                    targetBAP = bap;
                    moveToBAP = true;
                }
            }
            else
            {
                targetBAP.Deattach();
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
