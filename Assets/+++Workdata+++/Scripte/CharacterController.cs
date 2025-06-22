using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterController : MonoBehaviour
{
    private float direction = 0f;
    [SerializeField] float speed = 5f;
    [SerializeField] float jumpForce = 10f;
    
    private Rigidbody2D rb;
    
    [SerializeField] private EggManager EggManager;
    [SerializeField] private uiManager uiManager;

    [Header("GroundCheck")] 
    [SerializeField] private Transform transformGroundCheck;
    [SerializeField] private LayerMask layerGround;
    
    private SpriteRenderer spriteRenderer;

    public bool canMove = true;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            direction = 0;

            if (Keyboard.current.aKey.isPressed)
            {
                direction = -1;
            }

            if (Keyboard.current.dKey.isPressed)
            {
                direction = 1;
            }

            if (Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                Jump();
            }

            rb.linearVelocity = new Vector2(direction * speed, rb.linearVelocity.y);
            
            //Rotation
            if (Keyboard.current.aKey.isPressed)
            {
                spriteRenderer.flipX = true;
            } else if (Keyboard.current.dKey.isPressed)
            {
                spriteRenderer.flipX = false;
            }
        }
    }

    void Jump()
    {
        if(Physics2D.OverlapCircle(transformGroundCheck.position, .3f, layerGround))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {

        Debug.Log("We collided with something!");

        if (other.CompareTag("Egg"))
        {
            Debug.Log("It was an egg");
            Destroy(other.gameObject);
            EggManager.EggCollected();
        } else if (other.CompareTag("Meat"))
        {
            Debug.Log("It was a meat");
            Destroy(other.gameObject);
            speed++;
            EggManager.MeatCollected();
        }
        else if (other.CompareTag("Enemy"))
        {
            Debug.Log("It was an Enemy");
            uiManager.LosePanel();
            canMove = false;
        }else if (other.CompareTag("Lava"))
        {
            Debug.Log("It was a Lavapit");
            uiManager.LosePanel();
            canMove = false;
        }

        if (other.CompareTag("Nest"))
        {
            Debug.Log("It was a nest");
            if (EggManager.counterEggs >= 4)
            {
                uiManager.WinPanel();
                canMove = false;
            }
        }
    }
}
