using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour {

	public Transform player;
	public float time = .1f;
	public float speed = 5f;
	public float verticalOffset = 1f;

	private Vector3 velocity = Vector3.zero;
	private float nextTimeToSearch;

	void FixedUpdate()
	{
		transform.position = Vector3.SmoothDamp(
			transform.position,
			new Vector3(player.position.x, player.position.y + verticalOffset, transform.position.z),
			ref velocity,
			time,
			speed,
			Time.fixedDeltaTime);
	}
}
