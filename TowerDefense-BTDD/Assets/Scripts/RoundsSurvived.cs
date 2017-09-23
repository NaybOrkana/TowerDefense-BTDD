using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundsSurvived : MonoBehaviour
{
	public float m_TextDelay = 0;
	public Text m_RoundsText;

	private void OnEnable()
	{
		StartCoroutine (AnimateText ());
	}

	private IEnumerator AnimateText()
	{
		
		m_RoundsText.text = "0";
		int round = 0;

		yield return new WaitForSeconds (m_TextDelay);

		while (round < PlayerStats.m_Rounds) 
		{
			round++;
			m_RoundsText.text = round.ToString ();

			yield return new WaitForSeconds (.05f);
		}

	}

}         
