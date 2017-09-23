using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour 
{
	public Text m_RoundsText;
	public string m_MenuSceneName = "MainMenu";
	public SceneFade m_SceneFader;

	private void OnEnable()
	{
		m_RoundsText.text = PlayerStats.m_Rounds.ToString ();
	}

	public void Retry()
	{
		m_SceneFader.FateTo (SceneManager.GetActiveScene ().name);
	}

	public void Menu()
	{
		m_SceneFader.FateTo (m_MenuSceneName);
	}
}
