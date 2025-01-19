using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Settings")]
    public float jumpForce;

    [Header("References")]
    public Rigidbody2D Rigidbody2D;

    public Animator PlayerAnimator;

    public BoxCollider2D PlayerCollider;

    private bool isGrounded = true;

    
    public bool isInvincible = false;

    
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

    public void KillPlayer()
    {
        PlayerCollider.enabled = false;
        PlayerAnimator.enabled = false;
        Rigidbody2D.AddForceY(jumpForce, ForceMode2D.Impulse);
    }
    void Hit()
    {
        GameManager.Instance.Lives -= 1;
     
    }
    void Heal()
    {
        GameManager.Instance.Lives = Mathf.Min(3, GameManager.Instance.Lives + 1);
    }
    void StartInvincible()
    {
        isInvincible = true;
        Invoke("StopInvincible", 5f); 
    }
    void StopInvincible()
    {
        isInvincible = false;
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

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "enemy")
        {
            if (!isInvincible)
            {
                Destroy(collider.gameObject);
                Hit();
            }
        }
        else if (collider.gameObject.tag == "food")
        {
            Destroy(collider.gameObject);
            Heal();
        }
        else if(collider.gameObject.tag == "golden")
        {
            if (isInvincible.Equals(true))
                return;

            Destroy(collider.gameObject);
            StartInvincible();
        }
    }
}
