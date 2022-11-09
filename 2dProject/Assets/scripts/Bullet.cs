using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public float speed = 10;

	private string playerTag = "Player";
	private string wallTag = "Wall";

	// Update is called once per frame
	private void Update()
	{
		transform.position += transform.right * Time.deltaTime * speed;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag(playerTag))
		{
			Destroy(gameObject);
		}
		if (collision.gameObject.CompareTag(wallTag))
		{
		}
	}
}