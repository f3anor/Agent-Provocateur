using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

[RequireComponent( typeof( APSettings ) )]
public class GOD : MonoBehaviour
{
	static public GOD						Instance { get; private set; }			
	public APSettings						Settings { get; private set; }			
	//public APSounds						Sounds { get; private set; }	
		
	
	//Initialization to search for objects in scene
	void Awake()
	{
		if( GOD.Instance != null )
		{
			Debug.LogWarning( "God::Awake:" + gameObject.name + ": Only one god allowed: Destroy" );
			DestroyImmediate( gameObject, true );
			return;
		}
		else
		{
			Instance = this;
			//dont destroy god on new level load
			DontDestroyOnLoad( this );
		}

		
		if( ( Settings = gameObject.GetComponent<APSettings>() ) == null )
			Debug.LogWarning( "God::Awake:" + gameObject.name + ": Did not find settings object" );
		
//		if( ( Sounds = gameObject.GetComponent<APSounds>() ) == null )
//			Debug.LogWarning( "God::Awake:" + gameObject.name + ": Did not find sounds object" );
	}
}
