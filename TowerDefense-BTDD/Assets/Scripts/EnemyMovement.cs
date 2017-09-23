using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyComponent))]
public class EnemyMovement : MonoBehaviour 
{
	private Transform m_Target;
	private int m_WaypointIndex = 0;

	private EnemyComponent m_Enemy;

	private void Start()
	{
		m_Enemy = GetComponent <EnemyComponent> ();
		m_Target = WaypointsManager.m_Points [0];
	}
		

	private void Update()
	{
		Vector3 direction = m_Target.position - transform.position;
		transform.Translate (direction.normalized * m_Enemy.m_Speed * Time.deltaTime, Space.World);

		if (Vector3.Distance(transform.position, m_Target.position) <= 0.4f) 
		{
			GetNextWaypoint ();
		}

		m_Enemy.m_Speed = m_Enemy.m_StartSpeed;
	}

	private void GetNextWaypoint ()
	{
		if (m_WaypointIndex >= WaypointsManager.m_Points.Length - 1) 
		{
			EndPath ();
			return;
		}

		m_WaypointIndex++;

		m_Target = WaypointsManager.m_Points [m_WaypointIndex];
	}

	private void EndPath()
	{
		PlayerStats.m_Lives--;
		WaveSpawner.m_EnemiesAlive--;
		Destroy (gameObject);
	}
}
