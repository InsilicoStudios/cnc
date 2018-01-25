using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CNCUIPanel : CNCUIAbstractPanel
{
	[SerializeField]
	private POSITION m_panelPosition;

	public override POSITION PanelPosition {get { return m_panelPosition; } }



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
