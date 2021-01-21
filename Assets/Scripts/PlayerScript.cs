using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField]
    private LayerMask platformLayerMask;

    public Rigidbody2D rbBody;
    public float jump;
    private float horizontalMove;
    public bool facingRight = true;
    public float speed;
    public BoxCollider2D groundCheckCol;
    public BoxCollider2D playerCol;
    public Animator anim;
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = gameObject.transform.localScale;
        scale.x *= -1;
        gameObject.transform.localScale = scale;
    }

    bool IsGrounded()
    {
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
    }

    void FixedUpdate()
    {          
       
        horizontalMove = Input.GetAxisRaw("Horizontal");
                                     
        rbBody.velocity = new Vector2(horizontalMove * speed, rbBody.velocity.y);        


        if (horizontalMove < 0 && facingRight)
        {
            Flip();
        }

        if (horizontalMove > 0 && !facingRight)
        {
            Flip();
        }
      
        SetAnim();
    }

     void Update()
     {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Joystick1Button0) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (IsGrounded())
            {
                anim.Play("jump");
                rbBody.AddForce(Vector2.up * jump);
            }
        }
     }

    public void SetAnim()
    {
        if (anim != null)
        {
            anim.SetFloat("speedx", Mathf.Abs( rbBody.velocity.x));
            anim.SetFloat("speedy", Mathf.Abs(rbBody.velocity.y));

        }
    }
}
