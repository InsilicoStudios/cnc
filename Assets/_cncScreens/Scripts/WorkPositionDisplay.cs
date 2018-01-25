using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkPositionDisplay : MonoBehaviour 
{
	[SerializeField]
	private Text m_xText;
	[SerializeField]
	private Text m_yText;
	[SerializeField]
	private Text m_zText;

	private CNCUICanvas m_cncCanvas;
	private Vector3 m_position = new Vector3();

	// Use this for initialization
	void Start () 
	{
		m_cncCanvas = FindObjectOfType<CNCUICanvas> ();
		SetText ();
	}

	private void SetText()
	{
		m_xText.text = m_position.x.ToString ();
		m_yText.text = m_position.y.ToString ();
		m_zText.text = m_position.z.ToString ();
	}

	void Update () 
	{
		if (m_position != m_cncCanvas.WorkPosition)
		{
			m_position = m_cncCanvas.WorkPosition;
			SetText ();
		}
	}
}
