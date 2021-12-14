using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class Obstacle : MonoBehaviour{
    public string name="Spider";
    [SerializeField]public float dmg=1;
    [SerializeField]public Vector2 speedRange=new Vector2(5f,9f);
    public float speed;
    [DisableInEditorMode]public int yPosID;
    public bool stuckOnLine=true;
    [DisableInEditorMode]public bool reverseSpeed;
    [DisableInEditorMode]public Vector2 startVel;
    [DisableInEditorMode]public Vector2 velocity;
    Rigidbody2D rb;
    IEnumerator Start(){
        rb=GetComponent<Rigidbody2D>();
        
        yield return new WaitForSeconds(0.05f);
        speed=Random.Range(speedRange.x,speedRange.y)*-1;
        startVel=new Vector2(speed,0);
        if(GetComponent<BounceOnEdge>()!=null){stuckOnLine=false;startVel=new Vector2(startVel.x,speed*(int)(Random.Range(0,2)*2-1));}
        if(reverseSpeed){speed=Mathf.Abs(speed);startVel=new Vector2(Mathf.Abs(startVel.x),Mathf.Abs(startVel.y));}
        velocity=startVel;
    }
    void Update(){
        if(stuckOnLine)if(yPosID<LinesSpawner.instance.linesPosYs.Length-1&&yPosID>=0)transform.position=new Vector2(transform.position.x,LinesSpawner.instance.linesPosYs[yPosID]);
        rb.velocity=velocity;
    }
}
