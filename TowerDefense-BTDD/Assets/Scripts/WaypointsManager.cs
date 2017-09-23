using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointsManager : MonoBehaviour
{
	public static Transform[] m_Points;

	private void Awake()
	{
		m_Points = new Transform[transform.childCount];

		for (int i = 0; i < m_Points.Length; i++) 
		{
			m_Points[i] = transform.GetChild (i);
		}
	}

}
