using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour{
    [SerializeField]public int yPosID;
    [SerializeField]public bool fall;
    [SerializeField]public bool destroyOOP=true;
    void Update(){
        if(fall){
            var newYpos=transform.position.y;
            var step=-(LinesSpawner.instance.linesFallSpeed)*Time.deltaTime;
            newYpos=transform.position.y+step;
            transform.position=new Vector2(transform.position.x,newYpos);
        }
        if(destroyOOP){
            if(transform.position.y<Playfield.yRange.x-1f){
                if(Player.instance.yPosID>0)Player.instance.yPosID--;
                if(LinesSpawner.instance!=null)LinesSpawner.instance.linesGOs.Remove(LinesSpawner.instance.linesGOs.Find(x=>x==gameObject));
                LinesSpawner.instance.ResetLinesPosYs();
                Destroy(gameObject);
            }
        }
    }
}
