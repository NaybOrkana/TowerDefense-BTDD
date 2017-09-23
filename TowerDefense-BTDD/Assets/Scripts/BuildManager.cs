using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
	public static BuildManager m_ThisInstance;

	public GameObject m_BuildEffect;
	public GameObject m_SoldEffect;
	public NodeUI m_NodeUI;

	private TurretBlueprint m_TurretToBuild;
	private NodeComponent m_SelectedNode;


	private void Awake()
	{
		if (m_ThisInstance != null) 
		{
			Debug.LogError ("There is more than one BuildManager.");
		}
		m_ThisInstance = this;
	}

	public bool CanBuild { get { return m_TurretToBuild != null; } }
	public bool EnoughMoney { get { return PlayerStats.m_Money >= m_TurretToBuild.m_Cost; } }


	public void SelectedNode(NodeComponent node)
	{
		if (m_SelectedNode == node) 
		{
			DeselectNode ();
			return;
		}
		
		m_SelectedNode = node;
		m_TurretToBuild = null;

		m_NodeUI.SetTarget (node);
	}


	public void DeselectNode()
	{
		m_SelectedNode = null;
		m_NodeUI.Hide ();

	}
	public void SelectTurretToBuild(TurretBlueprint turretBlue)
	{
		m_TurretToBuild = turretBlue;

		DeselectNode ();

	}

	public TurretBlueprint GetTurretToBuild()
	{
		return m_TurretToBuild;
	}
}
