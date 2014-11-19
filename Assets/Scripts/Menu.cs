using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	public int window;
	// Use this for initialization
	void Start () {
		window = 1;
	}

	void OnGUI()
	{
		GUI.BeginGroup (new Rect (Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 200)); 
		if(window == 1) 
		{ 
			if(GUI.Button (new Rect (10,30,180,30), "Play")) 
			{ 
				window = 2;   
				Application.LoadLevel(1);
			} 
			if(GUI.Button (new Rect (10,70,180,30), "Settings")) 
			{ 
				window = 3; 
			} 
			if(GUI.Button (new Rect (10,110,180,30), "About game")) 
			{ 
				window = 4; 
			} 
			if(GUI.Button (new Rect (10,150,180,30), "Quit")) 
			{ 
				window = 5; 
			} 
		} 
		if (window == 2)
		{

		}
		if(window == 3)
		{ 
			GUI.Label(new Rect(50, 10, 180, 30), "Game settings");   
			if(GUI.Button (new Rect (10,40,180,30), "Game")) 
			{ 
			} 
			if(GUI.Button (new Rect (10,80,180,30), "Audio")) 
			{ 
			} 
			if(GUI.Button (new Rect (10,120,180,30), "Video")) 
			{ 
			} 
			if(GUI.Button (new Rect (10,160,180,30), "Back")) 
			{ 
				window = 1; 
			}   
		}
		if(window == 4) 
		{ 
			GUI.Label(new Rect(50, 10, 180, 30), "About Game");   
			GUI.Label(new Rect( 10, 40, 180, 40), "Information about developer and game"); 
			if(GUI.Button (new Rect (10,90,180,30), "Back")) 
			{ 
				window = 1; 
			}   
		} 
		if(window == 5) 
		{ 
			GUI.Label(new Rect(50, 10, 180, 30), "Are you sure?");   
			if(GUI.Button (new Rect (10,40,180,30), "Yes")) 
			{ 
				Application.Quit(); 
			} 
			if(GUI.Button (new Rect (10,80,180,30), "No")) 
			{ 
				window = 1; 
			} 
		} 
		GUI.EndGroup ();
	}
}
