using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarMovement : MonoBehaviour
{
	// Start is called before the first frame update

	private Rigidbody2D rb;
	public float movementSpeed;

	private float movementDirection;

	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	private void Update()
	{
		movementDirection = Input.GetAxisRaw("Vertical");
	}

	private void FixedUpdate()
	{
		rb.velocity = new Vector3(0, movementDirection * movementSpeed, 0);
	}
}