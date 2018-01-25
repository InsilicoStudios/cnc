using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CNCUICanvas : MonoBehaviour {

	public Vector3 MachinePosition {get { return m_machinePosition; } set { m_machinePosition = value; }}
	public Vector3 WorkPosition {get { return m_workPosition; } set { m_workPosition = value; }}

	[SerializeField]
	private ButtonController m_buttonController;
	[SerializeField]
	private GameObject m_panelTopLeft;
	[SerializeField]
	private GameObject m_panelTopRight;
	[SerializeField]
	private GameObject m_panelBottomLeft;
	[SerializeField]
	private GameObject m_panelBottomRight;
	[SerializeField]
	private GameObject m_panelBottom;

	[SerializeField]
	private GameObject m_auxFuncPrefab;
	[SerializeField]
	private GameObject m_machinePosPrefab;
	[SerializeField]
	private GameObject m_mdiCommandPrefab;
	[SerializeField]
	private GameObject m_tfsValuePrefab;
	[SerializeField]
	private GameObject m_workPosPrefab;
	[SerializeField]
	private GameObject m_blankViewPrefab;
	[SerializeField]
	private GameObject m_measureDisplayPrefab;

	private Vector3 m_machinePosition = new Vector3 ();
	private Vector3 m_workPosition = new Vector3 (5f, 5f, 5f);

	private List<GameObject> m_panels = new List<GameObject>();


	private void Awake()
	{
		m_panels.Add (m_panelTopLeft);
		m_panels.Add (m_panelTopRight);
		m_panels.Add (m_panelBottomLeft);
		m_panels.Add (m_panelBottomRight);
		m_panels.Add (m_panelBottom);			
	}


	// Use this for initialization
	void Start () 
	{
		ShowMDIDisplay ();
		//ShowWorkPosDisplay ();
		/*
		Instantiate<GameObject> (m_machinePosPrefab, m_panelTopLeft.transform);
		Instantiate<GameObject> (m_tfsValuePrefab, m_panelTopRight.transform);
		Instantiate<GameObject> (m_measureDisplayPrefab, m_panelBottom.transform);
		*/
	}

	public void ShowMDIDisplay()
	{
		ClearPanels ();
		Instantiate<GameObject> (m_machinePosPrefab, m_panelTopLeft.transform);
		Instantiate<GameObject> (m_tfsValuePrefab, m_panelTopRight.transform);
		Instantiate<GameObject> (m_mdiCommandPrefab, m_panelBottom.transform);
		m_buttonController.SetContextButtons ("mdiMode");
	}

	public void ShowWorkPosDisplay()
	{
		ClearPanels ();
		Instantiate<GameObject> (m_workPosPrefab, m_panelTopLeft.transform);
		Instantiate<GameObject> (m_tfsValuePrefab, m_panelTopRight.transform);
		Instantiate<GameObject> (m_blankViewPrefab, m_panelBottomLeft.transform);
		Instantiate<GameObject> (m_auxFuncPrefab, m_panelBottomRight.transform);
		m_buttonController.SetContextButtons ("posDisplay");

	}

	public void ShowMeasureWorkpieceDisplay()
	{
		m_buttonController.SetContextButtons ("measureWorkPiece");
	}

	public void ShowProbeCycleDisplay()
	{
		ClearPanels ();
		Instantiate<GameObject> (m_workPosPrefab, m_panelTopLeft.transform);
		Instantiate<GameObject> (m_tfsValuePrefab, m_panelTopRight.transform);
		Instantiate<GameObject> (m_measureDisplayPrefab, m_panelBottom.transform);
		m_buttonController.SetContextButtons ("probeCycle");
	}

	public void ShowWorksOffsetDisplay()
	{
		ClearPanels ();
		Instantiate<GameObject> (m_workPosPrefab, m_panelTopLeft.transform);
		Instantiate<GameObject> (m_tfsValuePrefab, m_panelTopRight.transform);
		Instantiate<GameObject> (m_blankViewPrefab, m_panelBottom.transform);
		m_buttonController.SetContextButtons ("worksOffset");
	}

	private void ClearPanels()
	{
		foreach (GameObject pnl in m_panels)
		{
			for (int i = 0; i < pnl.transform.childCount; i++)
			{
				Destroy (pnl.transform.GetChild(0).gameObject);
			}
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.Alpha1))
		{
			ShowMDIDisplay ();
		}
		if (Input.GetKeyDown (KeyCode.Alpha2))
		{
			ShowWorkPosDisplay ();
		}
		if (Input.GetKeyDown (KeyCode.Alpha3))
		{
			ShowMeasureWorkpieceDisplay ();
		}
		if (Input.GetKeyDown (KeyCode.Alpha4))
		{
			ShowProbeCycleDisplay ();
		}
		if (Input.GetKeyDown (KeyCode.Alpha5))
		{
			ShowWorksOffsetDisplay ();
		}
	}





}
