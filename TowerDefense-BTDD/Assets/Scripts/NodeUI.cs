using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
	public GameObject m_UI;
	public Text m_CostText;
	public Text m_SellText;
	public Button m_UpgradeButton;

	private NodeComponent m_Target;

	public void SetTarget(NodeComponent thisTarget)
	{
		m_Target = thisTarget;

		transform.position = m_Target.GetBuildPosition ();

		if (!m_Target.m_isTurretUpgraded) 
		{
			m_CostText.text = "$" + m_Target.m_Blueprint.m_UpgradeCost; 
			m_SellText.text = "$" + m_Target.m_Blueprint.m_SellValue;
			m_UpgradeButton.interactable = true;
		} else 
		{
			m_CostText.text = "MAXED";
			m_SellText.text = "$" + (m_Target.m_Blueprint.GetSellUpgrade () + m_Target.m_Blueprint.m_SellValue);
			m_UpgradeButton.interactable = false;
		}





		m_UI.SetActive (true);
	}

	public void Hide()
	{
		m_UI.SetActive (false);
	}

	public void Upgrade()
	{
		m_Target.UpgradeTurret ();
		BuildManager.m_ThisInstance.DeselectNode ();
	}

	public void Sell()
	{
		m_Target.SellTurret ();
		BuildManager.m_ThisInstance.DeselectNode ();
	}
}
