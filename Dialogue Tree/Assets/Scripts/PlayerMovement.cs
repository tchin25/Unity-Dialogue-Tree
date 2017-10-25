using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float speed;

	private Rigidbody2D rb;

	#region Awake Getting Components

	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	#endregion

	void Update()
	{
		if (Input.GetAxis("Horizontal") != 0)
		{
			rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed * Time.deltaTime, rb.velocity.y);
		}
		else
		{
			rb.velocity = new Vector2(0f, rb.velocity.y);
		}
	}
}
