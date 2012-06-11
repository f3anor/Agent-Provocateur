using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
	
	public EnemyStates 	state;
	public Vector3 		direction;
	public Settings.EnemySettings	enemySettings { get; private set; } 
	
	void Start()
	{
		enemySettings = GOD.Instance.Settings.enemy;
		
		if(enemySettings == null)
			Debug.Log("settings in " + gameObject.name + " is null");
		
		
		state = EnemyStates.NEUTRAL;		
		
		//init spawn direction
		switch (Random.Range(0 , 5)) 
		{
			case 0: 
				direction = new Vector3(1,0,0);
				break;
			case 1: 
				direction = new Vector3(0,0,1);
				break;
			case 2: 
				direction = new Vector3(0,0,-1);
				break;
			case 3: 
				direction = new Vector3(-1,0,0);
				break;
			default:
			break;
		}
		
		
	}
	
	void Update()
	{
		Wander (Time.deltaTime);
	
	}
	
	void Wander(float dt)
	{		
		transform.Translate(direction * Time.deltaTime * enemySettings.movingSpeed);
	}
	
	
    void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.layer == LayerMask.NameToLayer("wall")){
        	ChangeDirection(collision);
			state = (EnemyStates)Random.Range(0,4);	
			ChangeColor(state);
		}
		
		if(collision.gameObject.tag == GlobalNames.TAG_PLAYER){
			state = (EnemyStates)Random.Range(0,4);	
			ChangeColor(state);
			Debug.Log("player hit");
		}
    }

	

	void ChangeDirection(Collision collision)
	{
		direction = Vector3.Reflect(direction, collision.contacts[0].normal);
	}

	void ChangeColor(EnemyStates state)
	{
		
		switch (state) 
		{
			case EnemyStates.NEUTRAL: 
				gameObject.renderer.material.color = Color.blue;
				break;
			case EnemyStates.PISSED: 
				gameObject.renderer.material.color = Color.yellow;
				break;
			case EnemyStates.ANGRY: 
				gameObject.renderer.material.color = Color.red;
				break;
			case EnemyStates.DEAD: 
				gameObject.renderer.material.color = Color.green;
				break;
			default:
			break;
		}
	}
}