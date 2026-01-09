using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
	public GameObject bulletPrefab;
	public Transform firePoint;
	public float fireForce;

	public float fireRate = 1f; 

	private float nextFireTime = 0f;

	public void Shoot()
	{
		if (Time.time >= nextFireTime)
		{
			GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
			Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
			rb.velocity = firePoint.right * fireForce;

			nextFireTime = Time.time + 0.1f / fireRate;
		}
	}
}
