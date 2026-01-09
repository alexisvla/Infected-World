using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovements : MonoBehaviour
{
	Rigidbody2D rb;
	Animator animator;
	SpriteRenderer spriteRenderer;

	float horizontal;
	float vertical;

	public float runSpeed;
	
	void Start()
    {
		runSpeed = 5f;
		rb = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

    // Update is called once per frame
    void Update()
    {
		Move();
	}

	void Move()
	{
		horizontal = Input.GetAxisRaw("Horizontal") * runSpeed;
		vertical = Input.GetAxisRaw("Vertical") * runSpeed;
		rb.velocity = new Vector2(horizontal, vertical);

		if (horizontal > 0 || vertical > 0)
		{
			animator.SetBool("Run", true);
		}
		else if (horizontal < 0 || vertical < 0)
        {
			animator.SetBool("Run", true);
		}
        else
        {
			animator.SetBool("Run", false);
		}
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
        if (collision.gameObject.CompareTag("NextLevel"))
        {
			NextLevel();
        }
    }

	void NextLevel()
	{
		Scene scene = SceneManager.GetActiveScene();
		SceneManager.LoadScene(scene.buildIndex + 1);
	}
}
