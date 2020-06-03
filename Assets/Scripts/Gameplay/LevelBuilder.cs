using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
    [SerializeField]
    GameObject paddlePrefab;
    [SerializeField]
    GameObject bonusBlockPrefab;
    [SerializeField]
    PickupBlockBehaviour pickupBlockPrefab;
    [SerializeField]
    GameObject stdBlockPrefab;

    PickupBlockBehaviour instantiatedBlock;
    
    Vector2 position = new Vector2(0,0);
    Vector2 blockSize;
    int noOfBlocks;
    float spacebetweenBlocks;
    float screenTop;
    float screenBottom;
    float screenLeft;
    float screenRight ;

    float[] blockProbabilities = new float[4];
    // Start is called before the first frame update
    void Start()
    {
        screenTop = ScreenUtils.ScreenTop;
        screenBottom = ScreenUtils.ScreenBottom;
        screenLeft = ScreenUtils.ScreenLeft;
        screenRight = ScreenUtils.ScreenRight;
        // Get Paddle
        Instantiate( paddlePrefab , new Vector2( 0, screenBottom + 0.5f) , Quaternion.identity);
        
        // Get blocks 
        getBlockDimensions();
        blockProbabilities = ConfigurationUtils.GetBlockProbabilities;
        // Build the array
        buildArray();

    }

    void getBlockDimensions(){
        position.y = screenTop - ( ( screenTop - screenBottom)/5 ); 
        position.x = screenLeft;
        GameObject tempObject = Instantiate( stdBlockPrefab , new Vector2( 0 , screenTop) , Quaternion.identity);
        blockSize = tempObject.GetComponent<BoxCollider2D>().size * tempObject.transform.localScale;
        Debug.Log("Block size : " + blockSize);
        noOfBlocks = (int) ((screenRight - screenLeft) / blockSize.x) ;
        Debug.Log("Number of Bolcks"  + noOfBlocks) ;
        spacebetweenBlocks = ( screenRight - screenLeft - ((float)noOfBlocks * blockSize.x )) / (float)(noOfBlocks-1);
        Debug.Log("Space " + spacebetweenBlocks);
        Destroy(tempObject);
    }

    void buildArray(){
        for( int i = 0 ; i < 3 ; i ++ ){
            position.x = position.x +  blockSize.x/2 ; 
            position.y = position.y +  blockSize.y ; 
            for( int j = 0 ; j < noOfBlocks ; j ++){

                switch(randomiseBlocks()){
                    case 0:
                        Instantiate(stdBlockPrefab , position , Quaternion.identity );
                        break;
                    case 1:
                        Instantiate(bonusBlockPrefab , position , Quaternion.identity );
                        break;
                    case 2:
                        instantiatedBlock = Instantiate(pickupBlockPrefab , position , Quaternion.identity );
                        instantiatedBlock.Effect = PickupEffect.Freezer ; 
                        break;
                    case 3:
                        instantiatedBlock = Instantiate(pickupBlockPrefab , position , Quaternion.identity );
                        instantiatedBlock.Effect = PickupEffect.Speedup ;
                        break;
                    default:
                        Instantiate(stdBlockPrefab , position , Quaternion.identity ); 
                        break;
                }

                position.x = position.x +  spacebetweenBlocks + blockSize.x;
            }
            position.x = screenLeft ;
        }
    }

    int randomiseBlocks(){
        float val = Random.value;
        float currentProb = 0 ; 
        for( int i = 0 ; i < 4 ; i++){
            currentProb = currentProb + blockProbabilities[i];
            if( val <= currentProb ){
                return i;
            }
        }
        return 0;

    }

}
