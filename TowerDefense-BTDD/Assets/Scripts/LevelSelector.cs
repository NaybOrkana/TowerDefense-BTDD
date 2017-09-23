using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
	public SceneFade m_Fader;

	public Button[] m_LevelButtons;


	private void Start()
	{
		int levelReached = PlayerPrefs.GetInt("levelReached", 1);

		for (int i = 0; i < m_LevelButtons.Length; i++) 
		{
			if (i + 1 > levelReached) 
			{
				m_LevelButtons [i].interactable = false;
			}

		}
	}

	public void SelectAndFade(string levelName)
	{
		m_Fader.FateTo (levelName);
	}

}
