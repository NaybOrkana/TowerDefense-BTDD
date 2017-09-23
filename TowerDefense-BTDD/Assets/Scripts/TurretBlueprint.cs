using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TurretBlueprint 
{
	public GameObject m_TurretPrefab;
	public int m_Cost;
	public int m_SellValue;

	public GameObject m_UpgradedTurretPrefab;
	public int m_UpgradeCost;

	public int GetSellUpgrade()
	{
		return m_UpgradeCost / 3;
	}

}
