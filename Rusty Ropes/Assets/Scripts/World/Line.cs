using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour{
    [SerializeField]public int yPosID;
    [SerializeField]public bool fall;
    void Update(){
        if(fall){
            var newYpos=transform.position.y;
            newYpos=transform.position.y-(LinesSpawner.instance.linesFallSpeed/10);
            //var step=(LinesSpawner.instance.linesFallSpeed/10)*Time.deltaTime;
            //newYpos=transform.position.y+step;
            transform.position=new Vector2(transform.position.x,newYpos);
        }
    }
}
