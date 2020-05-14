/*
 * Project Name: Project Alpha
 *       Author: Erk
 *         Date: 2020/04/26
 *  Description: The class that handles the movement logic of the player character.
 */

using Mirror;
using UnityEngine;

public class PlayerMovement : NetworkBehaviour
{
    [Header("Movement")]
    [Tooltip("The max horizontal speed when running")]
    [SerializeField] private float moveSpeed = 3f;
    [Tooltip("The max vertical height to reach when jumping")]
    [SerializeField] private float jumpHeight = 5f;
    [Tooltip("The amount the speed is reduced per axis over time")]
    [SerializeField] private Vector2 drag = new Vector2(0.25f, 0.4f);
    [Tooltip("The specifies the gravity on the Y-axis, should be a negative value.")]
    [SerializeField] private float gravity = -15f;

    [Header("Dash Settings")]
    [Tooltip("The max distance to travel on a dash")]
    [SerializeField] private float dashDistance = 5f;
    [Tooltip("The duration a dash lasts. Horizontal input is ignored during this time.")]
    [SerializeField] private float dashDuration = 1f;
    [Tooltip("Cooldown for how often a dash can be performed")]
    [SerializeField] private float dashCooldown = 1f;

    [Header("Other")]
    [Tooltip("The distance to check for ground from players position")]
    [SerializeField] private float groundCheckDist = 1f;
    [Tooltip("Specifies which layers should be seen as 'ground' for the player.")]
    [SerializeField] private LayerMask groundMask;
    [Tooltip("Specifies which layers should be seen as 'ground' for the player.")]

    // Floats
   
    private float dashCooldownTimer = 0;
    private float dashTimer = 0;

    // Components
    private CharacterController cc;
    private Vector3 moveDirection;
    private Animator anim;
    
    // Bools
    private bool isGrounded;
    private bool isFacingRight = true;
    private bool isDashing;

    void Start()
    {
        cc = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        FindObjectOfType<GameplayContext>().SetPlayer(this);
    }

    public override void OnStartAuthority()
    {
        enabled = true;
    }

    void Update()
    {
        isGrounded = Physics.Linecast(transform.position + new Vector3(0,0.25f,0), new Vector2(transform.position.x, transform.position.y - groundCheckDist), groundMask);
        anim.SetBool("Grounded", isGrounded);
        Debug.DrawLine(transform.position, new Vector2(transform.position.x, transform.position.y - 0.5f), isGrounded?Color.green:Color.red);

        DashTimers();
    }

    private void FixedUpdate()
    {
        if(isGrounded && moveDirection.y < 0)
        {
            moveDirection.y = 0;
        }
        else // Apply gravity
        {
            moveDirection.y += gravity * Time.deltaTime;
        }

        moveDirection.z = 0;
        MoveCharacter();
        AddDrag();
    }

    /// <summary>
    /// All dash related timers are updated here.
    /// </summary>
    void DashTimers()
    {
        if (dashTimer > 0)
        {
            dashTimer -= Time.deltaTime;
        }
        else if (isDashing)
        {
            isDashing = false;
        }

        if (dashCooldownTimer > 0)
        {
            dashCooldownTimer -= Time.deltaTime;
        }
    }

    /// <summary>
    /// Adds vertical and horizontal drag to the movement.
    /// This is used to simulate air/ground resistance.
    /// </summary>
    void AddDrag()
    {
        moveDirection.x /= 1 + drag.x * Time.deltaTime;
        moveDirection.y /= 1 + drag.y * Time.deltaTime;
    }

    /// <summary>
    /// Adds the movement to the playercontroller
    /// Flips the player if necessary
    /// Sets the speed for the animator
    /// </summary>
    void MoveCharacter()
    {
        cc.Move(moveDirection * Time.deltaTime);

        if ((moveDirection.x > 0 && !isFacingRight) ||
            (moveDirection.x < 0 && isFacingRight))
        {
            Flip();
        }

        anim.SetFloat("Speed", Mathf.Abs(moveDirection.x) / moveSpeed);
    }

    /// <summary>
    /// Flips the character so it faces the correct direction.
    /// This is based on the players horizontal movement speed.
    /// </summary>
    void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.rotation = Quaternion.Euler(0, isFacingRight?90:-90, 0);
    }

    /// <summary>
    /// Sets the horizontal speed of the character.
    /// Speed is increased based on input and is capped based on 'moveSpeed'
    /// </summary>
    /// <param name="input"></param>
    public void SetHorizontalSpeed(float input)
    {
        if (isDashing)
            return; 
        float newSpeed = moveDirection.x + input;
        moveDirection.x = Mathf.Clamp(newSpeed, -moveSpeed, moveSpeed);
    }

    /// <summary>
    /// Makes the player jump by adding a burst of speed upwards
    /// Only works if the player IS grounded
    /// Also plays the jump animation
    /// </summary>
    public void Jump()
    {
        if (!isGrounded)
            return;

        anim.SetTrigger("Jump");
        moveDirection.y += jumpHeight;
    }

    /// <summary>
    /// Performs a dash by adding a burst of speed in the direciton the player is facing.
    /// Is only performed if previous dash duration is over.
    /// </summary>
    public void Dash()
    {
        if (dashCooldownTimer > 0)
            return;

        moveDirection +=
            Vector3.Scale(transform.forward,
            dashDistance * new Vector3((Mathf.Log(1f / (Time.deltaTime * drag.x + 1)) / -Time.deltaTime),
            0,
            (Mathf.Log(1f / (Time.deltaTime * drag.y + 1)) / -Time.deltaTime)));
        isDashing = true;
        dashTimer = dashDuration;
        dashCooldownTimer = dashCooldown;

        // TODO: Add dash effect? After images? Trail? Particles?
    }
}
