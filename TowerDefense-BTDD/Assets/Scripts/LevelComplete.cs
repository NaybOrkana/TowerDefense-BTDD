using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelComplete : MonoBehaviour
{
	public string m_MenuSceneName = "MainMenu";

	public string m_NextLevel = "Level02";
	public int m_LevelToUnlock = 2;

	public SceneFade m_SceneFader;


	public void Continue()
	{
		PlayerPrefs.SetInt ("levelReached", m_LevelToUnlock);
		m_SceneFader.FateTo (m_NextLevel);
	}

	public void Menu ()
	{
		m_SceneFader.FateTo (m_MenuSceneName);
	}
}
