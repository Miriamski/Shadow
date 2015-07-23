using UnityEngine;
using System.Collections;

public class levelgui : MonoBehaviour {

	// Initialize level
	void Start () 
	{
		print ("Loaded: " + gamestate.Instance.getLevel());
	}

	
	// ---------------------------------------------------------------------------------------------------
	// OnGUI()
	// --------------------------------------------------------------------------------------------------- 
	// Provides a GUI on level scenes
	// ---------------------------------------------------------------------------------------------------
	void OnGUI()
	{		
		// Create buttons to move between level 1 and level 2
		if (GUI.Button (new Rect (30, 30, 150, 30), "Load Level 1"))
		{
			gamestate.Instance.setLevel("Level 1");
			Application.LoadLevel("Level 1");
		}
		
		if (GUI.Button (new Rect (300, 30, 150, 30), "Load Level 2"))
		{
			print ("Moving to level 2");
			gamestate.Instance.setLevel("Level 2");
			Application.LoadLevel("Level 2");
		}

		// Output stats
		GUI.Label(new Rect(30, 100, 400, 30), "Name: " + gamestate.Instance.getName());
		GUI.Label(new Rect(30, 130, 400, 30), "HP: " + gamestate.Instance.getDeaths().ToString());

	}

}
