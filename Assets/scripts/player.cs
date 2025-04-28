using UnityEngine;

public class player : MonoBehaviour
{

    public float jumpForce = 10f; 
    public Transform groundCheck;  

    private Rigidbody2D rb;
    private bool isGrounded;
    private float groundRadius = 0.2f;


    public GameObject circleShape;  // 〇の形を持つオブジェクト
    public GameObject triangleShape; // △の形を持つオブジェクト
    public GameObject squareShape;   // □の形を持つオブジェクト

    private GameObject currentShape; 

    public LayerMask whatIsGround;  

    public enum ShapeType { Circle, Triangle, Square }
    public ShapeType currentShapeType { get; private set; }

    private int jumpCount = 0;
    public int maxJumpCount = 2;

    public AudioClip jumpSound;
    public AudioClip coinSound;
    private AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        circleShape.SetActive(true);
        triangleShape.SetActive(false);
        squareShape.SetActive(false);
        currentShape = circleShape;

        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        if (isGrounded && rb.linearVelocity.y <= 0.1f)
        {
            jumpCount = 0;
        }


        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJumpCount)
        {
            if(jumpCount < 3)
            {
                Debug.Log(jumpCount);
                Jump();
                jumpCount += 1;
            }
        }


        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeShape(circleShape, ShapeType.Circle);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangeShape(triangleShape, ShapeType.Triangle);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ChangeShape(squareShape, ShapeType.Square);
        }
    }

    void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);

        if (jumpSound != null)
        {
            audioSource.PlayOneShot(jumpSound);
        }
    }

    void ChangeShape(GameObject newShape, ShapeType type)
    {

        circleShape.SetActive(false);
        triangleShape.SetActive(false);
        squareShape.SetActive(false);


        ResetAllRotation(newShape);

        newShape.SetActive(true);
        currentShape = newShape;

        currentShapeType = type;
    }  

    void ResetAllRotation(GameObject obj)
    {
        foreach (Transform t in obj.GetComponentsInChildren<Transform>())
        {
            t.localRotation = Quaternion.identity;
        }
    }
    public void PlayCoinSound()
    {
        if (coinSound != null)
        {
            audioSource.PlayOneShot(coinSound);
        }
    }
}