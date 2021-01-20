using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField]
    private LayerMask platformLayerMask;

    public Rigidbody2D rbBody;
    public float jump;
    private float horizontalMove;
    public bool facingRight = true;
    public float speed = 1f;
    public BoxCollider2D col;

    public bool useForce;
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = gameObject.transform.localScale;
        scale.x *= -1;
        gameObject.transform.localScale = scale;
    }

    bool IsGrounded()
    {
        RaycastHit2D rayCastHit = Physics2D.Raycast(col.bounds.center, Vector2.down, col.bounds.extents.y + 0.1f, platformLayerMask);
        return rayCastHit.collider != null;
    }

    void Update()
    {

        horizontalMove = Input.GetAxis("Horizontal");

        if (horizontalMove > 0.4f || horizontalMove < -0.4f)
        {
            if (useForce)
            {
               // rbBody.AddRelativeForce(Vector2.right * speed * Time.deltaTime * horizontalMove );
                rbBody.velocity +=Vector2.one* Vector2.right * (speed * Time.deltaTime * horizontalMove);

            }
            else
            {
                transform.position += transform.right * (speed * Time.deltaTime * horizontalMove);
            }
        }

        if (horizontalMove < 0 && facingRight)
        {
            Flip();
        }

        if (horizontalMove > 0 && !facingRight)
        {
            Flip();
        }

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Joystick1Button0) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (IsGrounded())
            {
                if (useForce)
                {
                  // rbBody.AddRelativeForce(Vector2.up * jump);
                    rbBody.velocity += Vector2.up * jump;

                }
                else
                {
                    rbBody.velocity = Vector2.up * jump;
                }
            }
        }

    }
}
