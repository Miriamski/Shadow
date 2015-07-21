using UnityEngine;
using System.Collections;

public class PlayerController_old: MonoBehaviour {

	public Animator animator;
	public float speed = 6f;
	Vector3 movement;
	Vector2 newPosition;

	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {


	}

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Move (moveHorizontal, moveVertical);

	}

	void Move (float h, float v) 
	{
		movement.Set (h, 0.0f, 5*v);
		
		movement = movement.normalized * speed * Time.deltaTime;
		
		newPosition.Set (transform.position.x + movement.x, transform.position.z + movement.z);
		
		rb.MovePosition (newPosition);
	}

	void Animate (float h, float v)
	{
		if (h != 0) {
			animator.SetBool("Walking", true);
		}
	}
}
