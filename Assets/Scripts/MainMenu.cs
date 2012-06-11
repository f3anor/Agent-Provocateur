using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour
{

	private string instructionText = "Instructions:\nPress Left and right to move.\npress mouse button to shoot molotov cocktail";
	private int buttonWidth = 200;
	private int buttonHeight = 50; 
	
	
	void OnGUI ()
	{
		GUI.Label(new Rect(10,10,200,200), instructionText);
		if(GUI.Button(new Rect(Screen.width/2 - buttonWidth/2, Screen.height/2 - buttonHeight/2 ,buttonWidth, buttonHeight), "Start"))
		{
			Application.LoadLevel(GlobalNames.SCENE_ID_LEVEL);	
		}
	} 
}

