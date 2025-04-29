using System.Runtime.CompilerServices;
using UnityEngine;


public class enemyPatrol2 : MonoBehaviour
{
    public GameObject pointC;
    public GameObject pointD;
    private Rigidbody2D rb;
    private Animator anim;
    private Transform currentPoint;
    public float speed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentPoint = pointD.transform;
        anim.SetBool("isRunning", true);
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 point = currentPoint.position - transform.position;
        if (currentPoint == pointD.transform)
        {
            rb.linearVelocity = new Vector2(0, speed);
        }
        else
        {
            rb.linearVelocity = new Vector2(0, -speed);
        }

        if(Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointD.transform)
        {
            currentPoint = pointC.transform;
        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointC.transform)
        {
            currentPoint = pointD.transform;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pointC.transform.position, 0.5f);
        Gizmos.DrawWireSphere(pointD.transform.position, 0.5f);
        Gizmos.DrawLine(pointC.transform.position, pointD.transform.position);
    }
}
