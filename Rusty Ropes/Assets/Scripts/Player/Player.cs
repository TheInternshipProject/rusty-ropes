using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour{
    public static Player instance;
    [Header("Properties")]
    [SerializeField]public float speed=6f;
    


    [HideInInspector]public bool damaged;
    [HideInInspector]public bool healed;

    Rigidbody2D rb;
    float moveInput;
    [SerializeField]Vector2 xRange;
    [SerializeField]Vector2 yRange;
    LineCreator lines;
    [SerializeField]List<float> linesPosYs=new List<float>();
    [SerializeField]int yPosID;
    void Awake(){instance=this;}
    IEnumerator Start(){
        rb=GetComponent<Rigidbody2D>();
        yield return new WaitForSeconds(0.05f);
        lines=FindObjectOfType<LineCreator>();
        foreach(GameObject line in lines.linesGOs){
            linesPosYs.Add(line.transform.position.y);
        }
        yPosID=linesPosYs.Count/2;
        transform.position=new Vector2(0,linesPosYs[yPosID]);
    }
    void Update(){
        MovePlayer();
    }
    void MovePlayer(){
        var newXpos=transform.position.x;
        var newYpos=transform.position.y;

        if(Input.GetKeyDown(KeyCode.W)){if(yPosID>0)yPosID--;}
        else if(Input.GetKeyDown(KeyCode.S)){if(yPosID<linesPosYs.Count-1)yPosID++;}
        yPosID=Mathf.Clamp(yPosID,0,linesPosYs.Count);
        newYpos=Mathf.Clamp(linesPosYs[yPosID],yRange.x,yRange.y);

        float deltaX=0f;
        deltaX=Input.GetAxis("Horizontal")*speed*Time.deltaTime;
        newXpos=Mathf.Clamp(transform.position.x,xRange.x,xRange.y)+deltaX;
        transform.position=new Vector2(newXpos,newYpos);
    }
}