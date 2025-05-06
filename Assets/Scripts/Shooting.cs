using System.Collections;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mouseWorldPosition;
    public GameObject bullet;
    public Transform bulletTransform;
    public bool canFire;
    public bool pausa;
    private float timer;
    public float timeBetweenFiring;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouseScreenPosition = Input.mousePosition;
        float cameraToZPlane = -Camera.main.transform.position.z;

        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(
            mouseScreenPosition.x,
            mouseScreenPosition.y,
            cameraToZPlane
        ));
        Vector3 rotation = mouseWorldPosition - transform.position;
        
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        
        transform.rotation = Quaternion.Euler(0, 0, rotZ);
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            StartCoroutine(PauseDelay());
        }
        if (!canFire)
        {
            timer += Time.deltaTime;
            if (timer > timeBetweenFiring)
            {
                canFire = true;
                timer = 0;
            }
        }
        if (Input.GetMouseButtonDown(0) && canFire && !pausa)
        {
            canFire = false;
            Instantiate(bullet, bulletTransform.position, Quaternion.identity);
        }
    }
    private IEnumerator PauseDelay()
    {
        if (!pausa)
        {
            pausa = true;
            yield return new WaitForSeconds(0.3f);
            pausa = false;
        }
        
    }
}
