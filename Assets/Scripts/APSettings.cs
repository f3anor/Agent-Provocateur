using UnityEngine;
using System.Collections.Generic;

public class APSettings : MonoBehaviour
{

	public Settings.CharacterSettings	character;
	public Settings.EnemySettings		enemy;
	public Settings.Molotov				molotov;
}

namespace Settings
{
	[System.Serializable]
	public class CharacterSettings
	{
		public int tmp; 
	}

	[System.Serializable]
	public class EnemySettings
	{
		public EnemyStates emotionState;
		public int movingSpeed = 4;
	}
	
	[System.Serializable]
	public class Molotov
	{
		public int movingSpeed = 4;
	}
	
}