using System.Collections;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;


public class Damage1 : MonoBehaviour
{
    public playerHealth pHealth;
    public float damage;
    public Player playerMovement;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerMovement.KBCounter = playerMovement.KBTotalTime;
            if(collision.transform.position.x <= transform.position.x)
            {
                playerMovement.KnockFromRight = true;
            }
            if (collision.transform.position.x > transform.position.x)
            {
                playerMovement.KnockFromRight = false;
            }

            pHealth.health -= damage;

            StartCoroutine(IFrames());

        }
    }
    IEnumerator IFrames()
    {
        Physics2D.IgnoreLayerCollision(8, 9, true);
        yield return new WaitForSeconds(3);
        Physics2D.IgnoreLayerCollision(8, 9, false);
    }
}
