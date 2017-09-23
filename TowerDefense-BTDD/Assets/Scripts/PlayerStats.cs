using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour 
{
	public static int m_Money;
	public int m_StartMoney = 400;

	public static int m_Lives;
	public int m_StartLives = 5;

	public static int m_Rounds;

	private void Start()
	{
		m_Money = m_StartMoney;
		m_Lives = m_StartLives;

		m_Rounds = 0;
	}
}
