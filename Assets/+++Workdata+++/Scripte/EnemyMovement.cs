using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    private int direction = 1;
    public float leftBoundary = 5f;
    public float rightBoundary = -5f;
    
    private SpriteRenderer spriteRenderer;
    
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right * direction * Time.deltaTime * speed;
        
        if (transform.position.x >= rightBoundary)
        {
            direction = -1;
        }
        else if (transform.position.x <= leftBoundary)
        {
            direction = 1;
        }
        
        //Rotation
        if (transform.position.x <= leftBoundary)
        {
            spriteRenderer.flipX = true;
        } else if (transform.position.x >= rightBoundary)
        {
            spriteRenderer.flipX = false;
        }
    }
}
