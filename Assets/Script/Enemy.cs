using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Enemy : MonoBehaviour
{

    public GameObject player;
    public float speed;
    public float health = 15;
	public float damage = 10;
	Animator animator;

	


    private float distance;

	void Start()
    {
		player = GameObject.FindGameObjectWithTag("Player");
		animator = GetComponent<Animator>();
	}

   
    void Update()
    {

		if (player != null)
		{
			chasePlayer();
			healthEnemy();
		}
		else
		{
			
			player = GameObject.FindGameObjectWithTag("Player");
		}
	}

    void healthEnemy()
    {
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    void chasePlayer()
    {
		distance = Vector2.Distance(transform.position, player.transform.position);
		Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();

		transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);

		if (direction.x > 0) 
		{
			transform.rotation = Quaternion.Euler(0, 0, 0); 
		}
		else if (direction.x < 0) 
		{
			transform.rotation = Quaternion.Euler(0, 180, 0); 
		}
	}

	
	private void OnCollisionEnter2D(Collision2D collision)
	{

		if (collision.gameObject.CompareTag("Player"))
		{
			
			HealthPlayer Health = collision.gameObject.GetComponent<HealthPlayer>();
			if (Health != null)
			{

				Health.TakeDamage(damage);
			}
			
		}
	}

	public void TakeDamage(float damageEnemy)
	{
		health -= damageEnemy;
		animator.SetTrigger("Hit");
		Debug.Log("Enemy hit, health: " + health);
		animator.SetTrigger("Run enemy");
	}
}
