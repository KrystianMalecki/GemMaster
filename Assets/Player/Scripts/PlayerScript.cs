using CodeHelper;

using NaughtyAttributes;
using System.Collections;
using UnityEngine;

public class PlayerScript : Entity, IDamageable
{
    [SerializeField]
    private bool showMoreData;
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


    public float knockback;

    public override void Start()
    {
        base.Start();
        HeartDisplay.instance.UpdateHP(currentHP, maxHP);

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

        horizontalMove = Input.GetAxisRaw("Horizontal");

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
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Joystick1Button0) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (IsGrounded())
            {
                animator.Play("jump");
                ridgidBody2D.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            }
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

    public void TakeDamage(int number, Vector2 dir)
    {
        AddHP(-number);
        StartCoroutine("inmunityFrames");
        ridgidBody2D.AddForce((transform.position.toVector2() - dir).normalized * knockback, ForceMode2D.Impulse);
        /*make better knockback function
        maybe clamp dirtection to only 1 or -1 and then multiply by knockback force and little bit up?
         */

        if (currentHP <= 0)
        {
            Debug.Log("Player died.");
            return;
        }
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
                Debug.Log(4);

                po.Pickup(this);
            }
            //}
        }
    }
    public override void AddHP(int number)
    {
        base.AddHP(number);
        HeartDisplay.instance.UpdateHP(currentHP, maxHP);

    }
}
