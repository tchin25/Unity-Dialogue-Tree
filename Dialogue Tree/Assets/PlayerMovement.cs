using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float speed;

	public LayerMask ground;

	private Rigidbody2D rb;
	private BoxCollider2D col;
	private Transform groundCheckLeft;
	private Transform groundCheckRight;

	#region Awake Getting Components

	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		col = GetComponent<BoxCollider2D>();
		groundCheckLeft = transform.Find("Ground Check Left");
		groundCheckRight = transform.Find("Ground Check Right");
	}

	#endregion

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

		GroundCheck();
		if (Input.GetAxis("Horizontal") != 0)
		{
			rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);
		}
		else
		{
			rb.velocity = new Vector2(0f, rb.velocity.y);
		}
	}

	void GroundCheck()
	{
		if (Physics2D.OverlapPoint(groundCheckLeft.position, ground) || Physics2D.OverlapPoint(groundCheckRight.position, ground))
		{
			rb.velocity = new Vector2(rb.velocity.x, 0f);
		}
		else
		{
			rb.velocity = new Vector2(rb.velocity.x, -3f);
		}
	}
}
