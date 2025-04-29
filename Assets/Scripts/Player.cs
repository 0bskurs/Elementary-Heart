using System.Collections;
using UnityEngine;



public class Player : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private Rigidbody2D _rigidbody;
    private float moveX;
    private Vector2 movement;
    public float MoveSpeed = 5f;

    public float JumpForce = 10f;
    public LayerMask GroundLayer;
    public BoxCollider2D GroundCollider;
    public bool OnGround;

    private int extraJumps, extraJumpsInitial;
    public int extraJumpsValue;

    public float KBForce;
    public float KBCounter;
    public float KBTotalTime;



    [Tooltip("Material to switch to during the flash.")]
    [SerializeField] private Material flashMaterial;

    [Tooltip("Duration of the flash.")]
    [SerializeField] private float duration;




    private SpriteRenderer spriteRenderer;


    private Material originalMaterial;

   
    private Coroutine flashRoutine;

    public bool KnockFromRight;
    
    void Start()
    {
        extraJumps = extraJumpsValue;
        extraJumpsInitial = extraJumpsValue;
        _rigidbody = GetComponent<Rigidbody2D>();
        OnGround = true;

        spriteRenderer = GetComponent<SpriteRenderer>();
        originalMaterial = spriteRenderer.material;
    }

    void Update()
    {
        var jumpInputReleased = Input.GetKeyUp(KeyCode.Space);

        moveX = Input.GetAxisRaw("Horizontal");

        if (moveX != 0)
        {
            _animator.SetBool("isRunning", true);
        }
        else if (moveX == 0)
        {
            _animator.SetBool("isRunning", false);
        }

        if (moveX > 0)
        {
            gameObject.transform.localScale = new Vector3(2f, 2f, 2f);
        }
        else if (moveX < 0)
        {
            gameObject.transform.localScale = new Vector3(-2f, 2f, 2f);
        }

        if (Input.GetKeyDown(KeyCode.Space) && OnGround == true)
        {
            extraJumps = extraJumpsValue;
        }

        if (Input.GetKeyDown(KeyCode.Space) && extraJumps > 0)
        {
            _rigidbody.linearVelocity = new Vector2(_rigidbody.linearVelocity.x, JumpForce);
            extraJumps--;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && extraJumps == 0 && OnGround == true)
        {
            _rigidbody.linearVelocity = Vector2.up * JumpForce;
        }

        if (jumpInputReleased && _rigidbody.linearVelocity.y > 0)
        {
            _rigidbody.linearVelocity = new Vector2(_rigidbody.linearVelocity.x, _rigidbody.linearVelocity.y / 2);
        }
    }
    public void Flash()
    {
        if (flashRoutine != null)
        {
            StopCoroutine(flashRoutine);
        }

        flashRoutine = StartCoroutine(FlashRoutine());
    }


    private IEnumerator FlashRoutine()
    {
        spriteRenderer.material = flashMaterial;
        yield return new WaitForSeconds(duration);
        spriteRenderer.material = originalMaterial;
        flashRoutine = null;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (GroundLayer == (1 << other.gameObject.layer))
        {
            OnGround = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        OnGround = false;
    }

    void FixedUpdate()
    {
        if (KBCounter <= 0)
        {
            movement = new Vector2(moveX * MoveSpeed, _rigidbody.linearVelocity.y);
            _rigidbody.linearVelocity = movement;

        }
        else
        {
            if(KnockFromRight == true)
            {
                _rigidbody.linearVelocity = new Vector2(-KBForce, KBForce);
            }
            if(KnockFromRight == false)
            {
                _rigidbody.linearVelocity = new Vector2(KBForce, KBForce);
            }

            KBCounter -= Time.deltaTime;
        }

        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Flash();
            StartCoroutine(IFrames());
        }
    }
    IEnumerator IFrames()
    {
        Physics2D.IgnoreLayerCollision(9, 8, true);
        yield return new WaitForSeconds(1);
        Physics2D.IgnoreLayerCollision(9, 8, false);
    }

}