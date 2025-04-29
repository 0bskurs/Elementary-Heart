using Unity.VisualScripting;
using UnityEngine;
using System.Collections;
using Unity.Cinemachine;

public class BulletScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public float force;
    private Vector3 mouseWorldPosition;
    private Camera mainCam;
    public float bulletDamage;

    void Start()

    {
        
        rb = GetComponent<Rigidbody2D>();
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        Vector3 mouseScreenPosition = Input.mousePosition;
        float cameraToZPlane = -Camera.main.transform.position.z;

        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(
            mouseScreenPosition.x,
            mouseScreenPosition.y,
            cameraToZPlane
        ));
        Vector3 direction = mouseWorldPosition - transform.position;
        Vector3 rotation = transform.position - mouseWorldPosition;
        rb.linearVelocity = new Vector2(direction.x, direction.y).normalized * force;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);

    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
            Destroy(this.gameObject);
        else if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<EnemyHealth>().damageEnemy(bulletDamage);
            Destroy(gameObject);
        }
    }

}
