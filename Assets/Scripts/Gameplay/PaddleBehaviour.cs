using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleBehaviour : MonoBehaviour
{
	Rigidbody2D rigidBody;
    BoxCollider2D box;
	
	float halfWidthCollider;
	float halfHeightCollider;
    float screenLeft;
    float screenRight;
	float boolTolerance = 0.04f;
	const float BounceAngleHalfRange = 60 * Mathf.PI / 180;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();
        Vector2 boxMeasurements = box.size;
        halfWidthCollider = boxMeasurements.x * transform.localScale.x * 0.5f ; 
		halfHeightCollider = boxMeasurements.y * transform.localScale.y * 0.5f ;
        screenLeft = ScreenUtils.ScreenLeft;
        screenRight = ScreenUtils.ScreenRight;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
		
		Vector2 move = new Vector2(horizontalInput , 0 );
		Vector2 position = rigidBody.position;
		
		position = position + ConfigurationUtils.PaddleMoveUnitsPerSecond * move * Time.deltaTime;
		position.x = CalculatedClampedX(position.x);
        rigidBody.MovePosition(position);
    }

    private float CalculatedClampedX( float xPosition){
        if(xPosition < 0 ){
            if(xPosition - halfWidthCollider < screenLeft ){
                return screenLeft + halfWidthCollider; 
            }
        }else if(xPosition > 0 ){
            if(xPosition + halfWidthCollider > screenRight){
                return screenRight - halfWidthCollider;
            }
        }
		
		return xPosition;
    }
	
	    /// <summary>
    /// Detects collision with a ball to aim the ball
    /// </summary>
    /// <param name="coll">collision info</param>
    void OnCollisionEnter2D(Collision2D coll)
    {
		
        if ( coll.gameObject.CompareTag("Ball") && checkTopCollision(coll) ){
            // calculate new ball direction
            float ballOffsetFromPaddleCenter = transform.position.x -
                coll.transform.position.x;
            float normalizedBallOffset = ballOffsetFromPaddleCenter /
                halfWidthCollider;
            float angleOffset = normalizedBallOffset * BounceAngleHalfRange;
            float angle = Mathf.PI / 2 + angleOffset;
			// below is the unit vector for the direction
            Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
      
            // tell ball to set direction to new direction
            BallBehaviour ballScript = coll.gameObject.GetComponent<BallBehaviour>();
            ballScript.SetDirection(direction);
        }
    }
	
	bool checkTopCollision( Collision2D coll ){
		//Debug.Log("Coll : " + coll.GetContact(0).point.y);
		//Debug.Log("Top "  + (rigidBody.position.y + (halfHeightCollider/2)));		
		if( coll.GetContact(0).point.y < rigidBody.position.y + halfHeightCollider + boolTolerance && 
	coll.GetContact(0).point.y > rigidBody.position.y + halfHeightCollider - boolTolerance		){

			return true;
		}
		return false;
	}
}
