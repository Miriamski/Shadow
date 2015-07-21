using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
   
	[HideInInspector] public bool facingLeft = true;
    [HideInInspector] public bool isJumping = false;

    //restricted Speed and fixed Accelerations
    public float moveForce = 365f;
    public float maxSpeed = 5f;
    public float jumpForce = 1000f;
    //fixed Speed and Jumpheight
    //public float speed;
    //public float jumpHeight;
    public Transform groundCheck;
    public Animator animator;

    private bool grounded = false;
    private float moveHorizontal;
    private int random = 1;
    private bool isHiding;
    private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        if (Input.GetButtonDown("Jump") && grounded)
        {
            isJumping = true;
        }

        isHiding = Input.GetButton("Fire1");


	}

	void FixedUpdate () {
	
		moveHorizontal = Input.GetAxis ("Horizontal");

        if (moveHorizontal < 0 && !facingLeft)
        {
            Flip();
        }
        else if (moveHorizontal > 0 && facingLeft)
        {
            Flip();
        }

	    move ();
        animate();
		

	}

    void Flip()
    {
        facingLeft = !facingLeft;
        transform.localScale = new Vector3(transform.localScale.x*-1, transform.localScale.y, transform.localScale.z);    
    }

	void move() 
	{
		if (!isHiding) 
        {
			if (isJumping) 
            {
                rb.AddForce(new Vector2(0f, jumpForce));
                isJumping = false;
            }

            if (moveHorizontal * rb.velocity.x < maxSpeed)
            {
                rb.AddForce(Vector2.right * moveHorizontal * moveForce);
            }

            if (Mathf.Abs(rb.velocity.x) > maxSpeed)
            {
                rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x) * maxSpeed, rb.velocity.y);
            }

		}


	}

	void animate()
	{

	    animator.speed = Mathf.Abs(moveHorizontal);

		if (moveHorizontal != 0) 
        {
			animator.SetBool ("Walking", true);
		} 
        else 
        {
			animator.SetBool ("Walking", false);
		}

		if (isHiding) 
        {
			animator.SetInteger ("ShutEyes", random);
		} 
        else 
        {
			animator.SetInteger ("ShutEyes", 0);
			random = Random.Range(1, 3);
		}
	    
        //if(isJumping)
        //{
        //    animator.SetTrigger("Jump");
            
        //}
        
        

	}
}
