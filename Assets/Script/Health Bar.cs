using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthPlayer : MonoBehaviour
{
	public float MaxHealth = 100f;
	private float CurrentlyHealth;
	public Image HealthBarFill;
	public TextMeshProUGUI HealthText;
	Animator animator;

	void Start()
	{
		CurrentlyHealth = MaxHealth;
		UpdateBarFill();
		HealthText.text = CurrentlyHealth + "%";
		animator = GetComponent<Animator>();
	}

	void Update()
	{
		CheckHealth();
	}

	void CheckHealth()
	{
		if (CurrentlyHealth <= 0)
		{
			Die();
		}
	}

	public void TakeDamage(float damage)
	{
		CurrentlyHealth -= damage;
		CurrentlyHealth = Mathf.Clamp(CurrentlyHealth, 0, MaxHealth);
		Debug.Log("Player health: " + CurrentlyHealth);
		HealthText.text = CurrentlyHealth + "%";
		UpdateBarFill();

		if (CurrentlyHealth <= 0)
		{
			animator.SetTrigger("Dead");
			Die();
		}
	}

	public void UpdateBarFill()
	{
		if (HealthBarFill != null)
		{
			float TargetFillAmount = CurrentlyHealth / MaxHealth;
			HealthBarFill.fillAmount = TargetFillAmount;
		}
		else
		{
			Debug.LogError("HealthBarFill no sirve");
		}
	}

	void Die()
	{
		
		Debug.Log("Player died!");
		Destroy(gameObject);

		ResetLevel();
	}

	public void ResetLevel()
	{
		Scene scene = SceneManager.GetActiveScene();
		SceneManager.LoadScene(scene.buildIndex);
	}

}
