using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour 
{
	public GameObject m_GameOverUI;
	public GameObject m_CompleteLevelUI;
	
	public static bool m_GameEnded;


	private void Start()
	{
		m_GameEnded = false;
	}

	private void Update()
	{
		if (m_GameEnded == true) 
		{
			return;
		}

		if (PlayerStats.m_Lives <= 0) 
		{
			EndGame ();
		}
	}

	private void EndGame()
	{
		m_GameEnded = true;
		m_GameOverUI.SetActive (true);
	}

	public void WinLevel()
	{
		m_GameEnded = true;
		m_CompleteLevelUI.SetActive (true);
	}
}
