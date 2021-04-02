using UnityEngine;

public class TVscript : MonoBehaviour
{
    public Transform player;
    public PlayerScript playerScript;
    float xVelocity = 0.0f, yVelocity = 0.0f, newPositionx, newPositiony, closestDistance;
    public float speedx, speedy;
    private GameObject closest;
    void Update()
    {
        FindClosestEnemy();

        if (closestDistance < 70f)
        {
            newPositionx = Mathf.SmoothDamp(transform.position.x, closest.transform.position.x, ref xVelocity, 0.2f);
            newPositiony = Mathf.SmoothDamp(transform.position.y, closest.transform.position.y + 1.5f, ref yVelocity, 0.2f);

            Debug.DrawLine(transform.position, closest.transform.position, Color.red);
        }
        else
        {
            if (Input.GetAxis("Horizontal") > 0.4f || Input.GetAxis("Horizontal") < -0.4f)
            {
                if (playerScript.facingRight)
                {
                    newPositionx = Mathf.SmoothDamp(transform.position.x, player.position.x + 6f, ref xVelocity, speedx);
                    newPositiony = Mathf.SmoothDamp(transform.position.y, player.position.y + 2f, ref yVelocity, speedy);
                }
                else
                {
                    newPositionx = Mathf.SmoothDamp(transform.position.x, player.position.x - 6f, ref xVelocity, speedx);
                    newPositiony = Mathf.SmoothDamp(transform.position.y, player.position.y + 2f, ref yVelocity, speedy);
                }
            }
            else
            {
                newPositionx = Mathf.SmoothDamp(transform.position.x, player.position.x, ref xVelocity, speedx, 2f);
                newPositiony = Mathf.SmoothDamp(transform.position.y, player.position.y + 2f, ref yVelocity, speedy);
            }

            Debug.DrawLine(transform.position, closest.transform.position, Color.green);
        }

        transform.position = new Vector3(newPositionx, newPositiony, transform.position.z);
    }

    void FindClosestEnemy()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Programmable");
        closest = null;
        closestDistance = Mathf.Infinity;
        Vector3 position = player.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < closestDistance)
            {
                closest = go;
                closestDistance = curDistance;
            }
        }
    }

}
