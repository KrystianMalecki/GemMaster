using UnityEngine;
using ConditionalAttribute;
public class PlayerScript : MonoBehaviour
{
    [SerializeField]
    private bool showMoreData;
    [ConditionalField("showMoreData")]public LayerMask platformLayerMask;

    [ConditionalField("showMoreData")] public Rigidbody2D ridgidBody2D;
    public float jumpPower;
    private float horizontalMove;
    [ConditionalField("showMoreData")] public bool facingRight = true;
   public float speed;
    [ConditionalField("showMoreData")] public BoxCollider2D groundCheckCol;
    [ConditionalField("showMoreData")] public BoxCollider2D playerCol;
    [ConditionalField("showMoreData")] public Animator animator;
    [ConditionalField("showMoreData")] public Transform tvPoint;

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = gameObject.transform.localScale;
        scale.x *= -1;
        gameObject.transform.localScale = scale;
    }

    bool IsGrounded() => groundCheckCol.IsTouchingLayers(platformLayerMask);
   /* {
       // RaycastHit2D rayCastHit = Physics2D.Raycast(col.bounds.center, Vector2.down, col.bounds.extents.y + 0.2f, platformLayerMask);
       // return rayCastHit.collider != null;

        if (groundCheckCol.IsTouchingLayers(platformLayerMask))
        {
            return true;
        }
        else
        {
            return false;
        }
    }*/

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
                ridgidBody2D.AddForce(Vector2.up * jumpPower);
            }
        }
     }

     void SetAnimation()
    {
        if (animator != null)
        {
            animator.SetFloat("speedx", Mathf.Abs( ridgidBody2D.velocity.x));
            animator.SetFloat("speedy", ridgidBody2D.velocity.y);

        }
    }
}
