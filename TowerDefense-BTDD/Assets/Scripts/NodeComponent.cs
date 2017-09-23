using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NodeComponent : MonoBehaviour 
{
	public Color m_HoverColor;
	public Vector3 m_Offset;

	[HideInInspector]
	public GameObject m_Turret;
	[HideInInspector]
	public TurretBlueprint m_Blueprint;
	[HideInInspector]
	public bool m_isTurretUpgraded = false;

	private Color m_StartColor;
	private Renderer m_Rend;

	private void Start()
	{
		m_Rend = GetComponent<Renderer> ();
		m_StartColor = m_Rend.material.color;
	}

	public Vector3 GetBuildPosition()
	{
		return transform.position + m_Offset;
	}

	private void OnMouseDown()
	{
		if (EventSystem.current.IsPointerOverGameObject ()) 
		{
			return;
		}
			
		if (m_Turret != null) 
		{
			BuildManager.m_ThisInstance.SelectedNode (this);
			return;
		}

		if (!BuildManager.m_ThisInstance.CanBuild) 
		{
			return;
		}

		BuildTurret (BuildManager.m_ThisInstance.GetTurretToBuild ());

	}

	private void BuildTurret(TurretBlueprint blueprint)
	{
		if (PlayerStats.m_Money < blueprint.m_Cost) 
		{
			Debug.Log ("Not enough resources to build that.");
			return;
		}

		PlayerStats.m_Money -= blueprint.m_Cost;

		GameObject turret = (GameObject)Instantiate (blueprint.m_TurretPrefab, GetBuildPosition (), Quaternion.identity);
		m_Turret = turret;

		m_Blueprint = blueprint;

		GameObject effect = (GameObject)Instantiate (BuildManager.m_ThisInstance.m_BuildEffect, GetBuildPosition (), Quaternion.identity);
		Destroy (effect, 2f);

		Debug.Log ("Turret built! Resources left: " + PlayerStats.m_Money);
	}

	public void UpgradeTurret()
	{
		if (PlayerStats.m_Money < m_Blueprint.m_UpgradeCost) 
		{
			Debug.Log ("Not enough resources to upgrade.");
			return;
		}

		PlayerStats.m_Money -= m_Blueprint.m_UpgradeCost;
			
		Destroy (m_Turret);

		GameObject turret = (GameObject)Instantiate (m_Blueprint.m_UpgradedTurretPrefab, GetBuildPosition (), Quaternion.identity);
		m_Turret = turret;

		GameObject effect = (GameObject)Instantiate (BuildManager.m_ThisInstance.m_BuildEffect, GetBuildPosition (), Quaternion.identity);
		Destroy (effect, 3f);

		m_isTurretUpgraded = true;

		Debug.Log ("Turret upgraded!");
	}

	public void SellTurret()
	{
		if (m_isTurretUpgraded) 
		{
			PlayerStats.m_Money += m_Blueprint.m_SellValue + m_Blueprint.GetSellUpgrade ();
		} 
		else 
		{
			PlayerStats.m_Money += m_Blueprint.m_SellValue;
		}

		GameObject effect = (GameObject)Instantiate (BuildManager.m_ThisInstance.m_SoldEffect, GetBuildPosition (), Quaternion.identity);
		Destroy (effect, 3f);

		Destroy (m_Turret);
		m_Blueprint = null;
		m_isTurretUpgraded = false;

	}

	private void OnMouseEnter()
	{

		if (EventSystem.current.IsPointerOverGameObject ()) 
		{
			return;
		}

		if (!BuildManager.m_ThisInstance.CanBuild) 
		{
			return;
		} 
			

		if (BuildManager.m_ThisInstance.EnoughMoney) 
		{
			m_Rend.material.color = m_HoverColor;
		} else 
		{
			m_Rend.material.color = Color.red;
		}
			

	}

	private void OnMouseExit()
	{
		m_Rend.material.color = m_StartColor;
	}

}
