using UnityEngine;

public class PlayerDash : MonoBehaviour

{
    private Rigidbody2D playerRigidBody;
    private float dashTime;
    public float startDashTime;
    private bool isDash = false;
    private GameObject _player;

    [SerializeField] private float dashSpeed;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player");
        playerRigidBody = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;

    }

    // Update is called once per frame
    void Update()
    {
        if (isDash)
        {
            if (dashTime <= 0)
            {
                isDash = false;
                _player.GetComponent<Player>().isRun = true;
                dashTime = startDashTime;
               // playerRigidBody.gravityScale = 8.5f;
            }
            else
            {
                //playerRigidBody.gravityScale = 0;
                dashTime -= Time.deltaTime;
                playerRigidBody.velocity = Vector2.right * dashSpeed;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        isDash = (other.tag == "Dash") ? true : false;
        Debug.Log(isDash);
    }
}
