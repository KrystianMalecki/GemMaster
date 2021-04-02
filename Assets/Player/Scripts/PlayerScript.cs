using System.Collections;
using CodeHelper;
using DG.Tweening.Core;
using DG.Tweening;
using NaughtyAttributes;
using UnityEngine;

public class PlayerScript : Entity, IDamageable
{

    [Foldout("Static Data")] public LayerMask platformLayerMask;

    [Foldout("Static Data")] public Rigidbody2D ridgidBody2D;
    public float jumpPower;
    private float horizontalMove;
    [Foldout("Static Data")] public bool facingRight = true;
    public float speed;
    [Foldout("Static Data")] public BoxCollider2D groundCheckCol;
    [Foldout("Static Data")] public Animator animator;
    [Foldout("Static Data")] public Transform tvPoint;
    [Foldout("Static Data")] public BoxCollider2D playerCollider;
    [Foldout("Static Data")] public HeartDisplay heartdisplay;
    public float timeLeftToJump = 0;
    public float knockback;
    [SerializeReference]
    public static InteractableObject closestInteractableObject;

    public override void Start()
    {
        base.Start();
        heartdisplay.UpdateHP(currentHP, maxHP);
        bob(true);
    }
    public void bob(bool b)
    {
        animator.transform.DOLocalMoveY(0.0625f * (b ? 1f : -1f), (Mathf.Abs(ridgidBody2D.velocity.x) > 0.2f ? 0.25f : 0.5f)).SetEase(Ease.OutSine).OnComplete(() => { bob(!b); });
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = gameObject.transform.localScale;
        scale.x *= -1;
        gameObject.transform.localScale = scale;
    }
    bool IsGrounded()
    {
        RaycastHit2D rayCastHit = Physics2D.BoxCast(groundCheckCol.bounds.center, groundCheckCol.bounds.size, 0f, Vector2.down, 0.2f, platformLayerMask);
        return rayCastHit.collider != null;
    }
    void FixedUpdate()
    {

        //  horizontalMove = Input.GetAxisRaw("Horizontal");
        horizontalMove = 0;
        if (Input.GetKey(SettingsManager.instance.GetKey(GameKey.Right)))
        {
            horizontalMove += 1;
        }
        if (Input.GetKey(SettingsManager.instance.GetKey(GameKey.Left)))
        {
            horizontalMove += -1;

        }

        ridgidBody2D.velocity = new Vector2(horizontalMove * speed, ridgidBody2D.velocity.y);


        if (horizontalMove < 0 && facingRight)
        {
            Flip();
        }

        if (horizontalMove > 0 && !facingRight)
        {
            Flip();
        }

        SetAnimation();
    }
    void Update()
    {
        if (timeLeftToJump > 0)
        {
            timeLeftToJump -= Time.deltaTime;
        }

        animator.SetBool("running", Mathf.Abs(ridgidBody2D.velocity.x) > 0.2);

        if (Input.GetKey(SettingsManager.instance.GetKey(GameKey.Jump)) && timeLeftToJump <= 0)
        {
            if (IsGrounded())
            {
                animator.Play("jump");
                ridgidBody2D.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
                timeLeftToJump = 0.4f;
            }
        }
        if (Input.GetKeyDown(SettingsManager.instance.GetKey(GameKey.Interact)))
        {
            closestInteractableObject?.OnInteract.Invoke();
        }
    }
    void SetAnimation()
    {
        if (animator != null)
        {
            animator.SetFloat("speedx", Mathf.Abs(ridgidBody2D.velocity.x));
            animator.SetFloat("speedy", ridgidBody2D.velocity.y);

        }
    }
    public override void TakeDamage(int number, Vector2 dir)
    {
        base.TakeDamage(number, dir);
        StartCoroutine("inmunityFrames");
        ridgidBody2D.AddForce((transform.position.ToVector2() - dir).normalized * knockback, ForceMode2D.Impulse);
        /*make better knockback function
        maybe clamp dirtection to only 1 or -1 and then multiply by knockback force and little bit up?
         */


    }
    IEnumerable inmunityFrames()
    {
        playerCollider.enabled = false;
        yield return new WaitForSeconds(0.5f);
        playerCollider.enabled = true;

    }
    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.isTrigger)
        {

            //  if (collision.otherCollider.CompareTag("Pickup")){ //idk if all pickup objects will have ONLY Pickup tag. Maybe add later
            PickupObject po = collision.GetComponent<PickupObject>();
            if (po != null)
            {
                if (po is HeartPickup)
                {
                    if (currentHP == maxHP)
                    {
                        return;
                    }
                }
                po.Pickup(this);
            }
            //}
        }
    }
    public override void AddHP(int number)
    {
        base.AddHP(number);
        heartdisplay.UpdateHP(currentHP, maxHP);

    }
    public override void Die()
    {
        base.Die();
        Debug.Log("Player died.");
    }
}
