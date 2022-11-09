using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
	public GameObject bulletPrefab;
	public Transform[] shootPointPositions;
	public float timeBetweenShoots = 4;
	private float timeSinceLastShoot = 0;

	private void Update()
	{
		timeSinceLastShoot += Time.deltaTime;

		if (timeSinceLastShoot > timeBetweenShoots)
		{
			int rand = Random.Range(0, shootPointPositions.Length);

			timeSinceLastShoot = 0;
			Instantiate(bulletPrefab, shootPointPositions[rand].position, shootPointPositions[rand].rotation);
		}
	}
}