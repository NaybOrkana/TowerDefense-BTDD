using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	public float m_PanSpeed = 50f;
	public float m_PanBorderThickness = 10f;
	public float m_ScrollSpeed = 5f;
	public float m_MinY = 10f;
	public float m_MaxY = 100f;


	private void Update()
	{
		if (GameManager.m_GameEnded) 
		{
			this.enabled = false;
			return;
		}

		if (Input.GetKey ("w") || Input.mousePosition.y >= Screen.height - m_PanBorderThickness) 
		{
			transform.Translate (Vector3.forward * m_PanSpeed * Time.deltaTime, Space.World);
		}

		if (Input.GetKey ("s") || Input.mousePosition.y <= m_PanBorderThickness) 
		{
			transform.Translate (Vector3.back * m_PanSpeed * Time.deltaTime, Space.World);
		}

		if (Input.GetKey ("d") || Input.mousePosition.x >= Screen.width - m_PanBorderThickness) 
		{
			transform.Translate (Vector3.right * m_PanSpeed * Time.deltaTime, Space.World);
		}

		if (Input.GetKey ("a") || Input.mousePosition.x <= m_PanBorderThickness) 
		{
			transform.Translate (Vector3.left * m_PanSpeed * Time.deltaTime, Space.World);
		}

		float scroll = Input.GetAxis ("Mouse ScrollWheel");

		Vector3 posi = transform.position;

		posi.y -= scroll * 1000f * m_ScrollSpeed * Time.deltaTime;
		posi.y = Mathf.Clamp (posi.y, m_MinY, m_MaxY);

		transform.position = posi;
	}

}
