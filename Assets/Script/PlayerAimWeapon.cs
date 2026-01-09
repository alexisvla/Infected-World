using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerAimWeapon : MonoBehaviour
{
    public Transform Aim;
	public Transform Character;
	Animator animator;
	public GunController Weapon;
	public AudioSource ShootAudio;

	Vector3 lookDirections;
    float lookAngle;

	private void Start()
	{
		animator = GetComponent<Animator>();
	}

	
	void Update()
    {
        handleAiming();
		handleShooting();
    }

    void handleAiming()
    {

		Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		lookDirections = (mousePosition - transform.position).normalized;
		lookAngle = Mathf.Atan2(lookDirections.y, lookDirections.x) * Mathf.Rad2Deg;
		Aim.rotation = Quaternion.Euler(0,0,lookAngle);

		Vector2 scale = Aim.localScale;
		Vector3 playerScale = Character.localScale;

		if (lookDirections.x <= 0)
		{
			scale = new Vector3(-1, -1, 1);
			playerScale.x = -Mathf.Abs(playerScale.x);
		}
        else if (lookDirections.x >= 0)
        {
			scale = new Vector3(1, 1, 1);
			playerScale.x = Mathf.Abs(playerScale.x);
		}

		Character.localScale = playerScale;
		Aim.localScale = scale;
    }   

    void handleShooting()
    {
		if (Input.GetMouseButtonDown(0))
		{
			Debug.Log("entrasteeee");
			animator.SetBool("IsShooting", true);
			ShootAudio.Play();
			Weapon.Shoot();
			Debug.Log("Saliste");
		}
        else
        {
			animator.SetBool("IsShooting", false);
		}

    }

}
