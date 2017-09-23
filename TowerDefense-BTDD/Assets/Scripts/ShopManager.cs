using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
	public TurretBlueprint m_StandardTurret;
	public TurretBlueprint m_MissileLauncher;
	public TurretBlueprint m_LaserBeamer;

	public void SelectStandartTurret()
	{
		Debug.Log ("A Standard Turret was purchased.");
		BuildManager.m_ThisInstance.SelectTurretToBuild (m_StandardTurret);
	}

	public void SelectMissileLauncher()
	{
		Debug.Log ("A Missile Launcher was purchased.");
		BuildManager.m_ThisInstance.SelectTurretToBuild (m_MissileLauncher);
	}

	public void SelectLaserBeamer()
	{
		Debug.Log ("A Laser Beamer was purchased.");
		BuildManager.m_ThisInstance.SelectTurretToBuild (m_LaserBeamer);
	}
}
