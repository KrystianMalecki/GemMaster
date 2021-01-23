using ConditionalAttribute;
using UnityEngine;
using CodeHelper;
using System.Collections.Generic;
using System.Collections;

public class PlayerScript : MonoBehaviour, IDamageable
{
    [SerializeField]
    private bool showMoreData;
    [ConditionalField("showMoreData")] public LayerMask platformLayerMask;

    [ConditionalField("showMoreData")] public Rigidbody2D ridgidBody2D;
    public float jumpPower;
    private float horizontalMove;
    [ConditionalField("showMoreData")] public bool facingRight = true;
    public float speed;
    [ConditionalField("showMoreData")] public BoxCollider2D groundCheckCol;
    [ConditionalField("showMoreData")] public Animator animator;
    [ConditionalField("showMoreData")] public Transform tvPoint;
    [ConditionalField("showMoreData")] public BoxCollider2D playerCollider;

    public int maxHP;
    public int currentHP;
    public float knockback;

    public void Start()
    {
        //For now, max hp at start
        currentHP = maxHP;
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

    public void TakeDamage(int number,Vector2 dir)
    {
        currentHP -= number;
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
        HeartDisplay.instance.UpdateHP(currentHP, maxHP);
    }
    IEnumerable inmunityFrames()
    {
        playerCollider.enabled = false;
        yield return new WaitForSeconds(0.5f);
        playerCollider.enabled = true;

    }
}
