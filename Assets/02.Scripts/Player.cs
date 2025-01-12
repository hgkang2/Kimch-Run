using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Settings")]
    public float jumpForce;

    [Header("References")]
    public Rigidbody2D Rigidbody2D;

    public Animator PlayerAnimator;

    private bool isGrounded = true;

    
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if(Input.GetKeyDown (KeyCode.Space) && isGrounded)
        {
            Rigidbody2D.AddForceY(jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
            PlayerAnimator.SetInteger("State", 1);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Platform")
        {
            if (!isGrounded)
            {
                PlayerAnimator.SetInteger("State", 2);
            }
            isGrounded = true;  
        }
    }
}
