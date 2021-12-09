using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour{
    public static ObstacleSpawner instance;
    [SerializeField]public GameObject[] obstalcePrefabs;
    [SerializeField]public Vector2 spawnPosXs=new Vector2(-13.5f,13.5f);
    [SerializeField]public Vector2 obstacleSpeedRange=new Vector2(5f,9f);
    [SerializeField]public Vector2 spawnTimeRange=new Vector2(0.3f,1.2f);
    public float spawnTimer=-4;
    public int yPosID;
    void Awake(){if(instance!=null){Destroy(gameObject);}else{instance=this;}}
    void Start(){
        spawnTimer=Random.Range(spawnTimeRange.x,spawnTimeRange.y);
    }
    void Update(){
        if(spawnTimer>0)spawnTimer-=Time.deltaTime;
        else if(spawnTimer<=0&&spawnTimer!=-4){
            yPosID=Random.Range(0,LinesSpawner.instance.linesPosYs.Length);
            var go=Instantiate(obstalcePrefabs[Random.Range(0,obstalcePrefabs.Length)],transform);
            var spawnPosX=spawnPosXs.y;
            if(Random.Range(0,2)==1){spawnPosX=spawnPosXs.x;}
            go.transform.localPosition=new Vector2(spawnPosX,LinesSpawner.instance.linesPosYs[yPosID]);
            var speed=Random.Range(obstacleSpeedRange.x,obstacleSpeedRange.y)*-1;
            if(spawnPosX==spawnPosXs.x){speed=Mathf.Abs(speed);go.GetComponent<SpriteRenderer>().flipX=true;}
            
            go.GetComponent<Rigidbody2D>().velocity=new Vector2(speed,0);
            if(go.GetComponent<BounceOnEdge>()!=null){go.GetComponent<Rigidbody2D>().velocity=new Vector2(go.GetComponent<Rigidbody2D>().velocity.x,speed*(int)Random.Range(1,-1));}

            spawnTimer=Random.Range(spawnTimeRange.x,spawnTimeRange.y);
        }
    }
}
