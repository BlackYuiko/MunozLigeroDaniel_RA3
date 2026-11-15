using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

[RequireComponent (typeof (Rigidbody2D))]

public class PlayerController : MonoBehaviour, InputSystem_Actions.IGravityManActions
{
    private InputSystem_Actions inputActions;

    public float speed = 5f;
    public float jumpForce = 12f;
	private float rayLength = 1.4f;

	private Rigidbody2D rb;
    private SpriteRenderer sp;
    private Animator animator;

    public LayerMask groundLayer;
    private Vector2 horizontalInput;

    private static readonly int IsRunningHash =
        Animator.StringToHash("IsRunning");

    public void Awake()
    {
        inputActions = new InputSystem_Actions();
        inputActions.GravityMan.SetCallbacks(this);

		rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();

        animator = GetComponent<Animator>();
    }

    private void OnEnable() => 
        inputActions.Enable();
    private void OnDisable() => 
        inputActions.Disable();

    void Start() { }

    void Update()
    {
        if (animator != null)
        {
            bool running = Mathf.Abs(rb.linearVelocity.x) > 0.01f;
            animator.SetBool(IsRunningHash, running);
        }

        if (horizontalInput.x > 0.01f)
            sp.flipX = false;
        else if (horizontalInput.x < -0.01f)
            sp.flipX = true;

    }
    bool isGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, rayLength, groundLayer);
        return hit.collider != null;
    }

    bool IsLevelOne()
    {
        int activeSceneIndex = SceneManager.GetActiveScene().buildIndex;
        string activeSceneString = SceneManager.GetActiveScene().name;

        if (activeSceneIndex == 1 || activeSceneString == "LevelOne")
        {
            return true;
        }
        return false;
    }

    
    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontalInput.x * speed, rb.linearVelocity.y);

        Debug.DrawRay(transform.position, Vector2.down * rayLength, Color.red);
    }


    public void OnChangeGravity(InputAction.CallbackContext context)
    {
        if (!context.performed || !isGrounded() || IsLevelOne()) return;
        
        ChangeGravity();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        horizontalInput = context.ReadValue<Vector2>();
    }

    public void ChangeGravity()
    {
        GameEvents.PlayGravityBoing();

        sp.flipY = !sp.flipY;
        rb.gravityScale *= -1;
        rayLength *= -1;

    }
}