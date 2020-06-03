using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BallBehaviour : MonoBehaviour
{
	Rigidbody2D rigidBody2D; 
	Timer timer ;
	float ballAliveTime;
	BallSpawner ballSpawner;

	BallsLeftEvent ballsLeftEvent = new BallsLeftEvent();
    void Start()
    {
		StartCoroutine(BallCoroutine());
		rigidBody2D = GetComponent<Rigidbody2D>();
		timer = gameObject.AddComponent<Timer>();
		// New spawns
		ballSpawner = Camera.main.GetComponent<BallSpawner>();

		EventManager.AddBallsInvoker(this);
    }

    public void SetDirection( Vector2 directionUnit){
		rigidBody2D.velocity = directionUnit * rigidBody2D.velocity.magnitude;
		//Debug.Log(rigidBody2D.velocity);
	}
	
	void Update(){
		
		if( timer.Finished || rigidBody2D.position.y < (ScreenUtils.ScreenBottom - 0.2f) ){
			ballsLeftEvent.Invoke();
			ballSpawner.SpawnBall();
			Destroy(gameObject);
		}
	}

	void BallInitializer(){
		// Setting timer
		
		timer.Duration = ConfigurationUtils.BallAliveTime; 
		timer.Run();
		// Starting ball movement 
        
		float angle = -90 * Mathf.PI / 180;
		Vector2 direction = new Vector2( Mathf.Cos(angle) , Mathf.Sin(angle));
		rigidBody2D.AddForce( direction * ConfigurationUtils.BallImpulseForce , ForceMode2D.Impulse );
	}
	IEnumerator BallCoroutine(){
		yield return new WaitForSeconds(1);
		BallInitializer();
	}

	public void AddBallsListener( UnityAction listener){
		ballsLeftEvent.AddListener( listener );
	}
}
