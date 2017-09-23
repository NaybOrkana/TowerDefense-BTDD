using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour 
{
	public string m_LevelToLoad = "Scene01";

	public SceneFade m_SceneFader;

	public void Play()
	{
		m_SceneFader.FateTo (m_LevelToLoad);
	}

	public void Quit()
	{
		Debug.Log ("Exting...");
		Application.Quit ();
	}

}
