using System.Runtime.CompilerServices;
using UnityEngine;


public class enemyPatrol_redemoinho_9 : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    private Rigidbody2D rb2;
    private Animator anim;
    private Transform currentPoint2;
    public float speed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentPoint2 = pointA.transform;
        anim.SetBool("isRunning", true);

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 point = currentPoint2.position - transform.position;
        if (currentPoint2 == pointA.transform)
        {
            rb2.linearVelocity = new Vector2(-speed, 0);
        }
        else
        {
            rb2.linearVelocity = new Vector2(speed, 0);
        }

        if (Vector2.Distance(transform.position, currentPoint2.position) < 0.5f && currentPoint2 == pointA.transform)
        {
            currentPoint2 = pointB.transform;
        }
        if (Vector2.Distance(transform.position, currentPoint2.position) < 0.5f && currentPoint2 == pointB.transform)
        {
            currentPoint2 = pointA.transform;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pointA.transform.position, 0.5f);
        Gizmos.DrawWireSphere(pointB.transform.position, 0.5f);
        Gizmos.DrawLine(pointA.transform.position, pointB.transform.position);
    }
}
