using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CNCUIAbstractPanel : MonoBehaviour 
{
	public enum POSITION
	{
		TOP_RIGHT,
		TOP_LEFT,
		BOTTOM_RIGHT,
		BOTTOM_LEFT,
		BOTTOM
	}

	public abstract POSITION PanelPosition { get; }
}
