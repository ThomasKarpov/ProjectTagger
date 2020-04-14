using Mirror;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float characterSpeed = 3f;
    [SerializeField] private float characterJumpForce = 5f;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private TMP_Text characterNameText;



    private CharacterController cc;
    private Animator anim;
    private NetworkIdentity netID;
    private bool isGrounded;
    private bool isFacingRight = true;

    void Start()
    {
        netID = GetComponent<NetworkIdentity>();
        if (netID && !netID.isLocalPlayer)
        {
            characterNameText.text = $"Player {netID.netId}";
            enabled = false;
        }
        else
        {
            characterNameText.text = "You";
        }

        cc = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        isGrounded = Physics.Linecast(transform.position + new Vector3(0,0.25f,0), new Vector2(transform.position.x, transform.position.y - 0.5f), groundMask);
        anim.SetBool("Grounded", isGrounded);
        Debug.DrawLine(transform.position, new Vector2(transform.position.x, transform.position.y - 0.5f), isGrounded?Color.green:Color.red);

        GetInput();
    }

    void GetInput()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        MoveCharacter(horizontalInput);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }
    }

    void Jump()
    {
        anim.SetTrigger("Jump");
        cc.Jump();
    }

    void MoveCharacter(float h)
    {
        //Vector2 velocity = new Vector2(h * characterSpeed, cc.characterSpeed rb.velocity.y);
        //rb.velocity = velocity;

        //if((velocity.x > 0 && !isFacingRight) ||
        //    (velocity.x < 0 && isFacingRight))
        //{
        //    Flip();
        //}

        //anim.SetFloat("Speed", Mathf.Abs(velocity.x));
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.rotation = Quaternion.Euler(0, isFacingRight?90:-90, 0);
    }
}
