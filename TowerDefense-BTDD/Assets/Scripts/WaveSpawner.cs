using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour 
{
	public static int m_EnemiesAlive = 0;

	public WaveComponent[] m_Waves;

	public Transform m_SpawnLocation;
	public float m_TimeBetweenWaves = 20f;
	public Text m_WaveCountdownText;

	public GameManager m_GameManager;

	private float m_Countdown = 3f;
	private int m_WaveNum = 0;

	private void Update()
	{
		if (m_EnemiesAlive > 0)
		{
			return;
		}

		if (m_WaveNum == m_Waves.Length) 
		{
			m_GameManager.WinLevel ();
			this.enabled = false;
		}

		if (m_Countdown <= 0f) 
		{
			StartCoroutine (SpawnWave ());
			m_Countdown = m_TimeBetweenWaves;
			return;
		}

		m_Countdown -= Time.deltaTime;
		m_Countdown = Mathf.Clamp (m_Countdown, 0f, Mathf.Infinity);

		m_WaveCountdownText.text = string.Format ("{0:00.00}", m_Countdown);
	}

	private IEnumerator SpawnWave()
	{
		
		PlayerStats.m_Rounds++;

		WaveComponent wave = m_Waves [m_WaveNum];

		m_EnemiesAlive = wave.m_Count;

		for (int i = 0; i < wave.m_Count; i++) 
		{
			SpawnEnemies (wave.m_Enemy);
			yield return new WaitForSeconds (1 / wave.m_Rate);
		}
		m_WaveNum++;
	
	}

	private void SpawnEnemies(GameObject enemy)
	{
		Instantiate (enemy, m_SpawnLocation.position, m_SpawnLocation.rotation);
	}
}
