using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour{
    public static ObstacleSpawner instance;
    [SerializeField]public GameObject[] obstalcePrefabs;
    [SerializeField]public Vector2 spawnPosXs=new Vector2(-13.5f,13.5f);
    [SerializeField]public Vector2 spawnTimeRange=new Vector2(0.3f,1.2f);
    public float spawnTimer=-4;
    void Awake(){if(instance!=null){Destroy(gameObject);}else{instance=this;}}
    void Start(){
        spawnTimer=Random.Range(spawnTimeRange.x,spawnTimeRange.y);
    }
    void Update(){
        if(spawnTimer>0)spawnTimer-=Time.deltaTime;
        else if(spawnTimer<=0&&spawnTimer!=-4){
            if(LinesSpawner.instance.linesPosYs.Length>0){
                var yPosID=Random.Range(0,LinesSpawner.instance.linesPosYs.Length);
                var go=Instantiate(obstalcePrefabs[Random.Range(0,obstalcePrefabs.Length)],transform);
                var obs=go.GetComponent<Obstacle>();
                var spawnPosX=spawnPosXs.y;
                if((int)(Random.Range(0,2)*2-1)==1){spawnPosX=spawnPosXs.x;}
                go.transform.localPosition=new Vector2(spawnPosX,LinesSpawner.instance.linesPosYs[yPosID]);
                if(spawnPosX==spawnPosXs.x){obs.reverseSpeed=true;go.GetComponent<SpriteRenderer>().flipX=true;}
            }

            spawnTimer=Random.Range(spawnTimeRange.x,spawnTimeRange.y);
        }
    }
}
