using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
   
	[HideInInspector] public bool facingLeft = true;
	[HideInInspector] public bool isJumping = false;
	// mutual exclusive basic states of player
	// Standard: stand, walk, jump, fall (standard physics effecsts)
	public enum State {Standard, Dead, Hiding, TimeTraveling}
	public State state {
		get;
		protected set;
	}

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
    private Rigidbody2D rb;
	private float defaultGravityScale = 20.0f;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		setState (State.Standard);
	}
	
	// Update is called once per frame
	void Update () 
    {
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

		switch (state) {
		case State.Dead:
			break;
		case State.Hiding:
			if (Input.GetAxis("Vertical") >= 0) 
				setState(State.Standard);
			break;
		case State.Standard:
			isJumping = (Input.GetButtonDown ("Jump") && grounded);
			if (Input.GetAxis("Vertical") < 0)
				setState(State.Hiding);
			break;
		case State.TimeTraveling:
			break;
		}
	    
        //Call jump from here since FixedUpdate's framerate is not frequent enough
        jump();
	}

	void FixedUpdate () 
    {
		moveHorizontal = Input.GetAxis("Horizontal");
		if (moveHorizontal < 0 && !facingLeft)
			Flip ();
		else if (moveHorizontal > 0 && facingLeft)
			Flip ();
		move();
		animate();
	}

	public void travelTime ()
	{
		setState (State.TimeTraveling);
	}

	public void stopTravelingTime ()
	{
		setState (State.Standard);	
	}

   	public void die ()
	{
		setState (State.Dead);
	}

	void setState(State s) // allows more control over changing state
	{
		if (s.Equals(state))
			return;
		print(state.ToString()+" -> "+s.ToString());

		// previous state
		switch (state) {
		case State.Dead:
			return; // stay dead forever!
		case State.Hiding:
			animator.SetInteger ("ShutEyes", 0);
			break;
		case State.TimeTraveling:
			rb.gravityScale = defaultGravityScale;
			break;
		case State.Standard:
			break;
		}
		// next state
		switch (s) {
		case State.Dead:
			rb.gravityScale = 0;
			rb.velocity = Vector2.zero;
			random = Random.Range(1, 2);
			animator.SetInteger ("Dead", random);
			break;
		case State.Hiding:
			random = Random.Range(1, 5);
			animator.SetInteger ("ShutEyes", random);
			break;
		case State.TimeTraveling:
			rb.gravityScale = 0;
			rb.velocity = Vector2.zero;
			break;
		case State.Standard:
			rb.gravityScale = defaultGravityScale;
			break;
		}

		state = s;

	}

	void Flip()
	{
		facingLeft = !facingLeft;
		transform.localScale = new Vector3(transform.localScale.x*-1, transform.localScale.y, transform.localScale.z);    
	}

    void jump()
    {
        if (state != State.Standard)
			return;
	    if (isJumping)
            rb.AddForce(new Vector2(0f, jumpForce));
    }

    void move() 
	{
		switch (state) {
		case State.Dead:
		case State.TimeTraveling:
			break;
		case State.Hiding:
			rb.velocity = new Vector2 (0, rb.velocity.y);
			break;
		case State.Standard:
			if (moveHorizontal * rb.velocity.x < maxSpeed)
				rb.AddForce (Vector2.right * moveHorizontal * moveForce);
			if (Mathf.Abs (rb.velocity.x) > maxSpeed)
				rb.velocity = new Vector2 (Mathf.Sign (rb.velocity.x) * maxSpeed, rb.velocity.y);
			break;
		}
	}

	void animate()
	{
		switch (state) {
		case State.Dead:
			break;
		case State.Hiding:
			break;
		case State.TimeTraveling:
			break;
		case State.Standard:
			if (moveHorizontal != 0) 
				animator.SetBool ("Walking", true);
			else 
				animator.SetBool ("Walking", false);
			if(isJumping)
				animator.SetTrigger("Jump");            
			break;
		}
	}
}
