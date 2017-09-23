using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesUI : MonoBehaviour
{
	public Text m_LivesText;

	private void Update()
	{
		m_LivesText.text = PlayerStats.m_Lives + " HITS LEFT";
	}
}
