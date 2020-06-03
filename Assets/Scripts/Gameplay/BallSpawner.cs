using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject ballPrefab;
    bool spawnState = false;
    int spawnTime;
    Vector2 spawnPosition = new Vector2( 0 , 0 );
    Vector2 spawnLocationMax;
    Vector2 spawnLocationMin;
    bool retrySpawn = false;
    // Start is called before the first frame update
    void Start()
    {   

    // To get the Ball collider dimensions 
    GameObject tempBall = Instantiate( ballPrefab , spawnPosition , Quaternion.identity);
    BoxCollider2D collider = tempBall.GetComponent<BoxCollider2D>();
    float ballColliderHalfWidth = collider.size.x * tempBall.transform.localScale.x / 2;
    float ballColliderHalfHeight = collider.size.y * tempBall.transform.localScale.y / 2;
    spawnLocationMin = new Vector2(
        tempBall.transform.position.x - ballColliderHalfWidth,
        tempBall.transform.position.y - ballColliderHalfHeight);
    spawnLocationMax = new Vector2(
        tempBall.transform.position.x + ballColliderHalfWidth,
        tempBall.transform.position.y + ballColliderHalfHeight);
    //Debug.Log("min" + spawnLocationMin);
   // Debug.Log("max" + spawnLocationMax);
    Destroy(tempBall);
    //
    // Initial ball
    SpawnBall();

    }

    // Update is called once per frame
    void Update()
    {
        if(!spawnState){
            spawnTime = Random.Range(ConfigurationUtils.MinSpawnTime , ConfigurationUtils.MaxSpawnTime + 1);
            spawnState = true;
            StartCoroutine(SpawnBallCoroutine(spawnTime));
        }
        if(retrySpawn){
            SpawnBall();
        }
    }
    public void SpawnBall(){
        if( Physics2D.OverlapArea( spawnLocationMin , spawnLocationMax) == null){
            retrySpawn = false ;
            Instantiate( ballPrefab , spawnPosition , Quaternion.identity );
        }else{
          retrySpawn = true;
            //Instantiate( ballPrefab , spawnPosition , Quaternion.identity );
            Debug.Log("retry iddue");
        }
    }
    

    IEnumerator SpawnBallCoroutine( int spawnTime ){
        yield return new WaitForSeconds(spawnTime);
        SpawnBall();
        spawnState = false;
    }
}
