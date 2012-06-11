using UnityEngine;
using System.Collections;

public class MolotovController : MonoBehaviour
{
	public GameObject ExplosionPrefab;
	public Settings.Molotov settings { get; private set; } 
	public CharacterActionController characterController;

	void Start ()
	{
		settings = GOD.Instance.Settings.molotov;
		
		if(settings == null)
			Debug.Log("settings in " + gameObject.name + " is null");
		
		
		characterController = GameObject.Find("Character").GetComponent(typeof(CharacterActionController)) as CharacterActionController;
		
		if(characterController == null)
			Debug.Log("characterController in " + gameObject.name + " is null");
	}

	void Update ()
	{		
		Vector3 movement = gameObject.transform.forward * settings.movingSpeed * Time.deltaTime;
		transform.position += movement;
	}

	void OnCollisionEnter(Collision collision) 
	{
		Instantiate(ExplosionPrefab, collision.transform.position, collision.transform.rotation);
		Destroy(this.gameObject);
		Debug.Log("Cocktail destroyed");			
	}
}
