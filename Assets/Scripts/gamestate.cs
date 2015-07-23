using UnityEngine;
using System.Collections;

public class gamestate : MonoBehaviour {

	// http://www.fizixstudios.com/labs/do/view/id/unity-game-state-manager

	// Declare properties
	private static gamestate instance;
	private string activeLevel;			// Active level
	private string cname;				// Characters name
	private int deaths;					// # deaths

	// ---------------------------------------------------------------------------------------------------
	// gamestate()
	// --------------------------------------------------------------------------------------------------- 
	// Creates an instance of gamestate as a gameobject if an instance does not exist
	// ---------------------------------------------------------------------------------------------------
	public static gamestate Instance
	{
		get
		{
			if(instance == null)
			{
				instance = new GameObject("gamestate").AddComponent<gamestate> ();
			}
			
			return instance;
		}
	}	
	
	// Sets the instance to null when the application quits
	public void OnApplicationQuit()
	{
		instance = null;
	}
	
	// ---------------------------------------------------------------------------------------------------
	// startState()
	// --------------------------------------------------------------------------------------------------- 
	// Creates a new game state
	// ---------------------------------------------------------------------------------------------------
	public void startState()
	{
		print ("Creating a new game state");

		// Set default properties:
		activeLevel = "Level 1";
		cname = "Schwipps";
		deaths = 0;

		// Load level 1
		Application.LoadLevel("Level 1");

	}

	// ---------------------------------------------------------------------------------------------------
	// getLevel()
	// --------------------------------------------------------------------------------------------------- 
	// Returns the currently active level
	// ---------------------------------------------------------------------------------------------------
	public string getLevel()
	{
		return activeLevel;
	}
	
	// ---------------------------------------------------------------------------------------------------
	// setLevel()
	// --------------------------------------------------------------------------------------------------- 
	// Sets the currently active level to a new value
	// ---------------------------------------------------------------------------------------------------
	public void setLevel(string newLevel)
	{
		// Set activeLevel to newLevel
		activeLevel = newLevel;
	}

	// ---------------------------------------------------------------------------------------------------
	// getName()
	// --------------------------------------------------------------------------------------------------- 
	// Returns the characters name
	// ---------------------------------------------------------------------------------------------------
	public string getName()
	{
		return cname;
	}

	// ---------------------------------------------------------------------------------------------------
	// getHP()
	// --------------------------------------------------------------------------------------------------- 
	// Returns the characters hp
	// ---------------------------------------------------------------------------------------------------
	public int getDeaths()
	{
		return deaths;
	}


}
