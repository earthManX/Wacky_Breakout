using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BallBehaviour : MonoBehaviour
{
	Rigidbody2D rigidBody2D; 
	Timer timer ;
	Timer speedupTimer;

	bool speedupBall = false ;
	float speedupFactor = 1.0f ;

	float ballAliveTime;
	BallSpawner ballSpawner;

	BallsLeftEvent ballsLeftEvent = new BallsLeftEvent();
    void Start()
    {
		StartCoroutine(BallCoroutine());
		rigidBody2D = GetComponent<Rigidbody2D>();

		timer = gameObject.AddComponent<Timer>();
		timer.Duration = ConfigurationUtils.BallAliveTime;

		speedupTimer = gameObject.AddComponent<Timer>();
		speedupTimer.Duration = ConfigurationUtils.SpeedupEffectDuration;
		// New spawns
		ballSpawner = Camera.main.GetComponent<BallSpawner>();

		EventManager.AddBallsInvoker(this);
		EventManager.AddPickupEffectListener(SpeedupEffectBehaviour);
    }

    public void SetDirection( Vector2 directionUnit){
		rigidBody2D.velocity = directionUnit * rigidBody2D.velocity.magnitude;
		//Debug.Log(rigidBody2D.velocity);
	}
	
	void Update(){
		
		if( timer.Finished  ){
			//ballsLeftEvent.Invoke();
			ballSpawner.SpawnBall();
			Destroy(gameObject);
		}else if(rigidBody2D.position.y < (ScreenUtils.ScreenBottom - 0.2f)){
			ballsLeftEvent.Invoke();
			ballSpawner.SpawnBall();
			Destroy(gameObject);
		}

		if( speedupBall ){
			if( speedupTimer.Finished ){
				rigidBody2D.velocity = rigidBody2D.velocity /speedupFactor;
				speedupBall = false;
			}
		}
	}

	void BallInitializer(){
		// Setting timer
		// Change velocity using effectUtils
		 
		timer.Run();
		// If speedup is already activated
        if( EffectUtils.IsSpeedup){
			speedupFactor = EffectUtils.SpeedFactor ;
			speedupTimer.Duration = EffectUtils.TimeLeft;
			speedupTimer.Run();
			speedupBall = true;
		}

		float angle = -90 * Mathf.PI / 180;
		Vector2 direction = new Vector2( Mathf.Cos(angle) , Mathf.Sin(angle));
		rigidBody2D.AddForce( direction * ConfigurationUtils.BallImpulseForce * speedupFactor , ForceMode2D.Impulse );
	}
	IEnumerator BallCoroutine(){
		yield return new WaitForSeconds(1);
		BallInitializer();
	}

	public void AddBallsListener( UnityAction listener){
		ballsLeftEvent.AddListener( listener );
	}

	public void SpeedupEffectBehaviour( float duration , float factor){
		// This method is only activated when ball alreadu exists and the effect is activated
		if( speedupTimer.Running){
			speedupTimer.AddDuration( duration ); 
		}else {
			speedupTimer.Run();
			speedupFactor = factor;
			rigidBody2D.velocity = rigidBody2D.velocity * speedupFactor;
		}
		speedupBall = true;

	}
}
