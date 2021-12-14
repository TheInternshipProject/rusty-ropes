using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour{
    [SerializeField]public int yPosID;
    [SerializeField]public bool fall;
    [SerializeField]public bool destroy=true;
    void Update(){
        if(fall){
            var newYpos=transform.position.y;
            newYpos=transform.position.y-(LinesSpawner.instance.linesFallSpeed/10);
            //var step=(LinesSpawner.instance.linesFallSpeed/10)*Time.deltaTime;
            //newYpos=transform.position.y+step;
            transform.position=new Vector2(transform.position.x,newYpos);
        }
        /*if(destroy){
            if(transform.position.y<Playfield.yRange.x-0.1f){
                if(LinesSpawner.instance!=null)LinesSpawner.instance.linesGOs.Remove(LinesSpawner.instance.linesGOs.Find(x=>x==gameObject));
                Destroy(gameObject);
            }
        }*/
    }
}
