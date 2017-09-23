using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretComponent : MonoBehaviour
{
	[Header("Geeral Attibutes")]
	public float m_Range = 15f;

	[Header("Use Bullets (default)")]
	public float m_FireRate = 1f;
	private float m_FireCountdown = 0f;
	public GameObject m_BulletPrefab;

	[Header("Use Laser")]
	public bool m_UseLaser = false;
	public LineRenderer m_LineRenderer;
	public ParticleSystem m_ImpactEffect;
	public Light m_ImpactLight;

	public int m_DamageOverTime = 4;
	public float m_SlowAmount = .5f;

	[Header("Unity Setup")]
	public Transform m_PartToRotate;
	public string m_EnemyTag = "Enemy";
	public Transform m_FirePoint;
	public float m_TurnSpeed = 10f;

	private Transform m_Target;
	private EnemyComponent m_Enemy;


	private void Start () 
	{
		InvokeRepeating ("UpdateTarget", 0f, 0.5f);
	}

	private void UpdateTarget()
	{
		GameObject[] enemies = GameObject.FindGameObjectsWithTag (m_EnemyTag);
		float shortestDistance = Mathf.Infinity;
		GameObject nearestEnemy = null;

		foreach (GameObject enemy in enemies) 
		{
			float distanceToEnemy = Vector3.Distance (transform.position, enemy.transform.position);
			if (distanceToEnemy < shortestDistance) 
			{
				shortestDistance = distanceToEnemy;
				nearestEnemy = enemy;
			}
		}

		if (nearestEnemy != null && shortestDistance <= m_Range)
		{
			m_Target = nearestEnemy.transform;
			m_Enemy = nearestEnemy.GetComponent <EnemyComponent> ();
		} 
		else 
		{
			m_Target = null;
		}
	}


	private void Update () 
	{
		if (m_Target == null) 
		{
			if (m_UseLaser)
			{
				if (m_LineRenderer.enabled) 
				{
					m_LineRenderer.enabled = false;
					m_ImpactEffect.Stop ();
					m_ImpactLight.enabled = false;
				}
			}

			return;
		}

		LockOnTarget ();

		if (m_UseLaser) 
		{
			
			Lasering ();

		} else 
		{
			if (m_FireCountdown <= 0f) 
			{
				Shoot ();
				m_FireCountdown = 1f / m_FireRate;
			}
		}

		m_FireCountdown -= Time.deltaTime;	
	}

	private void Lasering()
	{
		m_Enemy.TakeDamage (m_DamageOverTime * Time.deltaTime);
		m_Enemy.Slowing (m_SlowAmount);

		if (!m_LineRenderer.enabled) 
		{
			m_LineRenderer.enabled = true;
			m_ImpactEffect.Play ();
			m_ImpactLight.enabled = true;
		}

		m_LineRenderer.SetPosition (0, m_FirePoint.position);
		m_LineRenderer.SetPosition (1, m_Target.position);

		Vector3 dir = m_FirePoint.position - m_Target.position;

		m_ImpactEffect.transform.position = m_Target.position + dir.normalized;

		m_ImpactEffect.transform.rotation = Quaternion.LookRotation (dir);
	}

	private void LockOnTarget()
	{

		Vector3 direction = m_Target.position - transform.position;
		Quaternion lookRotation = Quaternion.LookRotation (direction);
		Vector3 rotation = Quaternion.Lerp (m_PartToRotate.rotation, lookRotation, Time.deltaTime * m_TurnSpeed).eulerAngles;
		m_PartToRotate.rotation = Quaternion.Euler (0f, rotation.y, 0f); 
	}
		

	private void Shoot()
	{
		GameObject bulletGO = (GameObject) Instantiate (m_BulletPrefab, m_FirePoint.position, m_FirePoint.rotation);
		BulletComponent bullet = bulletGO.GetComponent<BulletComponent> ();

		if (bullet != null) 
		{
			bullet.Seek (m_Target);
		}
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (transform.position, m_Range);
	}
}
