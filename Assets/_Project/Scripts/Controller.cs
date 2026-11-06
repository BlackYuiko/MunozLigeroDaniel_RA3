using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent (typeof (Rigidbody2D))]
public class Controller : MonoBehaviour, InputSystem_Actions.IGravityManActions
{
    private InputSystem_Actions inputActions;

    public float speed = 5f;
    public float jumpForce = 12f;
	public float rayLength = 0.8f;

	private Rigidbody2D rb;
    private SpriteRenderer sp;

    public LayerMask groundLayer;
    private Vector2 horizontalInput;
    


    public void Awake()
    {
        inputActions = new InputSystem_Actions();
        inputActions.GravityMan.SetCallbacks(this);

		rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
	}
    private void OnEnable() => inputActions.Enable();
    private void OnDisable() => inputActions.Disable();

    void Start()
    {
        
    }

    bool isGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, rayLength, groundLayer);
        return hit.collider != null;
    }

    
    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontalInput.x * speed, rb.linearVelocity.y);

        Debug.DrawRay(transform.position, Vector2.down * rayLength, Color.red);
    }


    public void OnChangeGravity(InputAction.CallbackContext context)
    {
        if (!context.performed || !isGrounded()) return;
        
        //rb.linearVelocity = new Vector2(rb.linearVelocityX, jumpForce*Time.deltaTime);
        ChangeGravity();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        horizontalInput = context.ReadValue<Vector2>();
    }

    public void ChangeGravity()
    {
        sp.flipY = !sp.flipY;
        rb.gravityScale *= -1;
        rayLength *= -1;

    }
}