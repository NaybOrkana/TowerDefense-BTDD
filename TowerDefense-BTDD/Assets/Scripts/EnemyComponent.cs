using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyComponent : MonoBehaviour 
{
	public float m_StartHealth = 10f;
	public int m_Value = 50;
	public float m_StartSpeed = 10f;
	[HideInInspector]public float m_Speed;
	public GameObject m_DeathEffect;
	public Image m_HealthBar;

	private float m_Health;
	private bool m_isDead = false;

	private void Start()
	{
		m_Speed = m_StartSpeed;
		m_Health = m_StartHealth;
	}

	public void TakeDamage(float amount)
	{
		m_Health -= amount;
		m_HealthBar.fillAmount = m_Health / m_StartHealth;

		if (m_Health <= 0 && !m_isDead) 
		{
			Die ();
		}
	}

	public void Slowing(float amount)
	{
		m_Speed = m_StartSpeed * (1f - amount);
	}

	private void Die()
	{
		m_isDead = true;

		GameObject effect = (GameObject)Instantiate (m_DeathEffect, transform.position, Quaternion.identity);
		Destroy (effect, 5f);
		WaveSpawner.m_EnemiesAlive--;

		PlayerStats.m_Money += m_Value;
		Destroy (gameObject);
	}
}
