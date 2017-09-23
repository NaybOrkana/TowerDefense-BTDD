using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour 
{
	public GameObject m_UI;

	public string m_MenuSceneName = "MainMenu";

	public SceneFade m_SceneFader;

	private void Update()
	{
		if (Input.GetKeyDown (KeyCode.Escape) || Input.GetKeyDown (KeyCode.P)) 
		{
			TogglePause ();
		}
	}

	public void TogglePause()
	{
		m_UI.SetActive (!m_UI.activeSelf);

		if (m_UI.activeSelf) 
		{
			Time.timeScale = 0f;
		} else 
		{
			Time.timeScale = 1f;
		}
	}

	public void Retry()
	{
		TogglePause ();
		m_SceneFader.FateTo (SceneManager.GetActiveScene ().name);
	}

	public void Menu()
	{
		TogglePause ();
		m_SceneFader.FateTo (m_MenuSceneName);
	}
}
