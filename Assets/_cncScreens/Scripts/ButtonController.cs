using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour 
{

	[SerializeField]
	private GameObject m_sideContainer;
	[SerializeField]
	private GameObject m_bottomContainer;
	[SerializeField]
	private GameObject m_buttonPrefab;
	/*
	[SerializeField]
	private GameObject m_cb_measureWorkPiecePrefab;
	[SerializeField]
	private GameObject m_cb_RectSpigotBtnPrefab;
	[SerializeField]
	private GameObject m_cb_SetWOBtnPrefab;
	*/
	[SerializeField]
	private Sprite[] m_buttonSprites;

	private List<Button> m_sideButtons = new List<Button>();
	private List<Button> m_bottomButtons = new List<Button>();
	private Dictionary<string, Sprite> m_buttonImgs = new Dictionary<string, Sprite>();

	private CNCUICanvas m_cncCanvas;


	private void Awake()
	{
		m_cncCanvas = GetComponentInParent<CNCUICanvas> ();
		foreach (Sprite spr in m_buttonSprites)
		{
			m_buttonImgs.Add (spr.name, spr);
		}
		GenerateButtons ();
	}

	private void GenerateButtons()
	{
		for (int i = 0; i < 7; i++)
		{
			GameObject btn = Instantiate<GameObject> (m_buttonPrefab, m_bottomContainer.transform);
			m_bottomButtons.Add (btn.GetComponent<Button> ());
			m_bottomButtons [m_bottomButtons.Count - 1].GetComponentInChildren<Text> ().text = "";
		}
		for (int i = 0; i < 9; i++)
		{
			GameObject btn = Instantiate<GameObject> (m_buttonPrefab, m_sideContainer.transform);
			m_sideButtons.Add (btn.GetComponent<Button> ());
			m_sideButtons [m_sideButtons.Count - 1].GetComponentInChildren<Text> ().text = "";
		}

	}

	private void ResetButtons()
	{
		foreach (Button b in m_sideButtons)
		{
			Destroy (b.gameObject);
		}
		foreach (Button b in m_bottomButtons)
		{
			Destroy (b.gameObject);
		}
		m_bottomButtons.Clear ();
		m_sideButtons.Clear ();
		GenerateButtons ();
	}

	public void SetContextButtons(string a_screenContext)
	{
		ResetButtons ();
		switch (a_screenContext)
		{
			case "mdiMode":
				m_sideButtons [0].GetComponentInChildren<Text> ().text = "G\nfunctions";
				m_sideButtons [1].GetComponentInChildren<Text> ().text = "Auxilliary\nfunctions";
				m_sideButtons [4].GetComponentInChildren<Text> ().text = "Delete\nblocks";
				m_sideButtons [6].GetComponentInChildren<Text> ().text = "Act. values\nMachine";

				m_bottomButtons [0].image.sprite = m_buttonImgs ["btnLoadMDI"];
				m_bottomButtons [0].onClick.AddListener (m_cncCanvas.ShowWorkPosDisplay);
				m_bottomButtons [1].image.sprite = m_buttonImgs ["btnSaveMDI"];	
				m_bottomButtons [3].image.sprite = m_buttonImgs ["btnProgCntrl"];
				break;

			case "posDisplay":
				m_sideButtons [0].GetComponentInChildren<Text> ().text = "G\nfunctions";
				m_sideButtons [1].GetComponentInChildren<Text> ().text = "Auxilliary\nfunctions";
				m_sideButtons [6].GetComponentInChildren<Text> ().text = "Act. values\nMachine";

				m_bottomButtons [0].image.sprite = m_buttonImgs ["btnTSM"];
				m_bottomButtons [1].image.sprite = m_buttonImgs ["btnSetWO"];
				m_bottomButtons [2].image.sprite = m_buttonImgs ["btnMeasWorpBtm"];
				m_bottomButtons [2].onClick.AddListener (m_cncCanvas.ShowMeasureWorkpieceDisplay);
				m_bottomButtons [3].image.sprite = m_buttonImgs ["btnMeasTool"];
				m_bottomButtons [4].image.sprite = m_buttonImgs ["btnPosiTion"];
				m_bottomButtons [6].image.sprite = m_buttonImgs ["btnFaceMill"];

				break;

			case "measureWorkPiece":
				m_sideButtons [0].image.sprite = m_buttonImgs ["btnCalibrateProbe"];
				m_sideButtons [1].image.sprite = m_buttonImgs ["btnSquare1"];
				m_sideButtons [2].image.sprite = m_buttonImgs ["btnSquare2"];
				m_sideButtons [3].image.sprite = m_buttonImgs ["btnSquare5"];
				m_sideButtons [4].image.sprite = m_buttonImgs ["btnSquare7"];
				m_sideButtons [5].image.sprite = m_buttonImgs ["btnSquare11"];
				m_sideButtons [6].image.sprite = m_buttonImgs ["btnSquare10"];
				m_sideButtons [6].onClick.AddListener (m_cncCanvas.ShowProbeCycleDisplay);
				m_sideButtons [7].GetComponentInChildren<Text> ().text = "Back";

				m_bottomButtons [0].image.sprite = m_buttonImgs ["btnTSM"];
				m_bottomButtons [1].image.sprite = m_buttonImgs ["btnSetWO"];	
				m_bottomButtons [2].image.sprite = m_buttonImgs ["btnMeasWorpBtm"];
				m_bottomButtons [3].image.sprite = m_buttonImgs ["btnMeasTool"];
				m_bottomButtons [4].image.sprite = m_buttonImgs ["btnPosiTion"];
				m_bottomButtons [6].image.sprite = m_buttonImgs ["btnFaceMill"];

				break;

			case "probeCycle":
				m_sideButtons [0].GetComponentInChildren<Text> ().text = "Select\nwork offs.";
				m_sideButtons [7].GetComponentInChildren<Text> ().text = "Back";

				m_bottomButtons [0].image.sprite = m_buttonImgs ["btnTSM"];
				m_bottomButtons [1].image.sprite = m_buttonImgs ["btnSetWO"];
				m_bottomButtons [1].onClick.AddListener (m_cncCanvas.ShowWorksOffsetDisplay);
				m_bottomButtons [2].image.sprite = m_buttonImgs ["btnMeasWorpBtm"];
				m_bottomButtons [3].image.sprite = m_buttonImgs ["btnMeasTool"];
				m_bottomButtons [4].image.sprite = m_buttonImgs ["btnPosiTion"];
				m_bottomButtons [6].image.sprite = m_buttonImgs ["btnFaceMill"];
				break;

			case "worksOffset":

				m_sideButtons [0].GetComponentInChildren<Text> ().text = "X = 0";
				m_sideButtons [1].GetComponentInChildren<Text> ().text = "Y = 0";
				m_sideButtons [2].GetComponentInChildren<Text> ().text = "Z = 0";
				m_sideButtons [3].GetComponentInChildren<Text> ().text = "X = Y = Z = 0";
				m_sideButtons [4].GetComponentInChildren<Text> ().text = "Delete\nActive WO";
				m_sideButtons [7].GetComponentInChildren<Text> ().text = "Back";
				m_sideButtons [7].onClick.AddListener (m_cncCanvas.ShowMDIDisplay);

				m_bottomButtons [0].image.sprite = m_buttonImgs ["btnTSM"];
				m_bottomButtons [1].image.sprite = m_buttonImgs ["btnSetWO"];	
				m_bottomButtons [2].image.sprite = m_buttonImgs ["btnMeasWorpBtm"];
				m_bottomButtons [3].image.sprite = m_buttonImgs ["btnMeasTool"];
				m_bottomButtons [4].image.sprite = m_buttonImgs ["btnPosiTion"];
				m_bottomButtons [6].image.sprite = m_buttonImgs ["btnFaceMill"];

				break;
		}
	}
}
