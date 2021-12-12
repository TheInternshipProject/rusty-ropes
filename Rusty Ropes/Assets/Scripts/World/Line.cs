using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour{
    [SerializeField]public int yPosID;
    void Update(){
        var newYpos=transform.position.y;
        newYpos=transform.position.y-(LinesSpawner.instance.linesFallSpeed/10);
        transform.position=new Vector2(transform.position.x,newYpos);
    }
}
