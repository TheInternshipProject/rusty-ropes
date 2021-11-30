using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour{
    public static Player instance;
    [Header("Properties")]
    [SerializeField]public float speed=6f;
    [SerializeField]Vector2 xRange=new Vector2(-12,12f);

    [SerializeField]int yPosID;

    [HideInInspector]public bool damaged;
    [HideInInspector]public bool healed;
    Rigidbody2D rb;
    void Awake(){instance=this;}
    IEnumerator Start(){
        rb=GetComponent<Rigidbody2D>();
        yield return new WaitForSeconds(0.02f);
        yPosID=LinesSpawner.instance.linesPosYs.Length/2;
        transform.position=new Vector2(0,LinesSpawner.instance.linesPosYs[yPosID]);
    }
    void Update(){
        MovePlayer();
        
    }
    void MovePlayer(){
        var newXpos=transform.position.x;
        var newYpos=transform.position.y;

        if(Input.GetKeyDown(KeyCode.W)){if(yPosID>0)yPosID--;}
        else if(Input.GetKeyDown(KeyCode.S)){if(yPosID<LinesSpawner.instance.linesPosYs.Length-1)yPosID++;}
        yPosID=Mathf.Clamp(yPosID,0,LinesSpawner.instance.linesPosYs.Length-1);
        newYpos=LinesSpawner.instance.linesPosYs[yPosID];

        float deltaX=0f;
        deltaX=Input.GetAxis("Horizontal")*speed*Time.deltaTime;
        newXpos=Mathf.Clamp(transform.position.x,xRange.x,xRange.y)+deltaX;
        transform.position=new Vector2(newXpos,newYpos);
    }
}