using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] private float runningSpeed = 5f;
   // [SerializeField] private float dashSpeed = 10f;

    Rigidbody2D myRigidBody;
    Animator myAnimator;
    CapsuleCollider2D myBodyCollider;
    BoxCollider2D myFeetCollider;
    float gravityScaleAtStart;
    public bool isRun = true;

    bool isAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myBodyCollider = GetComponent<CapsuleCollider2D>();
        myFeetCollider = GetComponent<BoxCollider2D>();
        gravityScaleAtStart = myRigidBody.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAlive) { return; }
        Jump();
        Run();
        Die();
    }

    private void Jump()
    {
       
        if (myBodyCollider.IsTouchingLayers(LayerMask.GetMask("foreground")))
        {
            
            if (CrossPlatformInputManager.GetButton("Jump"))
            {
                //Vector2 jumpVelocityToAdd = new Vector2(0f, jumpSpeed);
                // myRigidBody.velocity += jumpVelocityToAdd;
                myRigidBody.velocity = Vector2.up * jumpSpeed;

            }
        }
       
    }

    private void Run()
    {
        if (isRun)
        {
            Vector2 playerVelocity = new Vector2(1 * runningSpeed, myRigidBody.velocity.y);
            myRigidBody.velocity = playerVelocity;
            
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Dash")
        {
            isRun = false;
        }
        else
        {
            isRun = true;
        }
     
    }

    private void Die()
    {
        if (myBodyCollider.IsTouchingLayers(LayerMask.GetMask("enemy")))
        {
            isAlive = false;
           // myAnimator.SetTrigger("Death");
            FindObjectOfType<GameSession>().ProcessPlayerDeath();
        }
    }


}
