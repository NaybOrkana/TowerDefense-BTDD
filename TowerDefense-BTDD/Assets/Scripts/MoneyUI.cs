using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyUI : MonoBehaviour 
{
	public Text m_MoneyText;

	private void Update()
	{
		m_MoneyText.text = "$" + PlayerStats.m_Money.ToString ();
	}
}
