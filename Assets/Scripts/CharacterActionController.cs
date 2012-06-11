using UnityEngine;
using System.Collections;

public class CharacterActionController : MonoBehaviour {

	
	public GameObject MolotovCocktail;
	public Settings.CharacterSettings settings { get; private set; } 
	public GUISkin guiSkin;
	
	void Start()
	{
		settings = GOD.Instance.Settings.character;
		
		if(settings == null)
			Debug.Log("settings in " + gameObject.name + " is null");
	}
	
	void Update()
	{		
		if(Input.GetMouseButtonDown(0))
		{
			//Vector3 position = new Vector3(transform.position.x, transform.position.y + transform.localScale.y / 2, transform.position.z);
			Instantiate(MolotovCocktail, transform.position, transform.rotation); 
		}
		
		if(Input.GetKeyDown(KeyCode.Escape))
			Application.Quit();
	}
	
	
	void OnGUI()
	{
		GUI.Label(new Rect(10, 10, 100, 100), "Go with the Flow", guiSkin.label);
		//GUI.Label(new Rect(Screen.width / 2, 10, 200, 200), "Choose your side", guiSkin.label);
	}
}
