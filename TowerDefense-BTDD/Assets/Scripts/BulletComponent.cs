using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletComponent : MonoBehaviour
{
	public float m_Speed = 50f;
	public float m_ExplosiveRadius = 0f;
	public GameObject m_ImpactEffect;
	public int m_Damage = 10;

	private Transform m_Target;

	public void Seek(Transform target)
	{
		m_Target = target;
	}

	private void Update()
	{
		if (m_Target == null) 
		{
			Destroy (gameObject);
			return;
		}

		Vector3 direction = m_Target.position - transform.position;
		float distanceThisFrame = m_Speed * Time.deltaTime;

		if (direction.magnitude <= distanceThisFrame) 
		{
			HitTarget ();
			return;
		}

		transform.Translate (direction.normalized * distanceThisFrame, Space.World);
		transform.LookAt (m_Target);
	}

	private void HitTarget()
	{
		GameObject effectIns = (GameObject) Instantiate (m_ImpactEffect, transform.position, transform.rotation);
		Destroy (effectIns, 5f);

		if (m_ExplosiveRadius > 0f) 
		{
			Explode ();

		}else
		{
			Damage (m_Target);
		}
			
		Destroy (gameObject);
	}

	private void Explode()
	{
		Collider[] affectedObjects = Physics.OverlapSphere (transform.position, m_ExplosiveRadius);
		foreach (Collider collider in affectedObjects) 
		{
			if (collider.tag == "Enemy")
			{
				Damage (collider.transform);
			}
		}
	}

	private void Damage(Transform enemy)
	{
		EnemyComponent e = enemy.GetComponent <EnemyComponent>();
		if (e != null) 
		{
			e.TakeDamage (m_Damage);
		}
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (transform.position, m_ExplosiveRadius);
	}
}
