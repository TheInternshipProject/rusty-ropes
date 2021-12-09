using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : MonoBehaviour{
    [SerializeField] public float accelRate=4f;
    float startVal;
    bool revert;
    Rigidbody2D rb;
    void Start(){
        rb=GetComponent<Rigidbody2D>();
        startVal=rb.velocity.x;
    }
    void Update(){
        var step=accelRate*Time.deltaTime;
        int dir=1;if(startVal>0){dir=-1;}
        //if((Mathf.Abs(rb.velocity.x)<=Mathf.Abs(startVal))&&
        //((dir==-1&&rb.velocity.x>-0.001f)||(dir==1&&rb.velocity.x<0.001f))){
        if(!revert){rb.velocity=new Vector2(rb.velocity.x+(step*dir),0);}
        if(
        (Mathf.Sign(rb.velocity.x)!=Mathf.Sign(startVal))||
        (Mathf.Abs(rb.velocity.x)<0.05f)
        ){revert=true;}
        if(revert){rb.velocity=new Vector2(rb.velocity.x-(step*dir*-1),0);}

        transform.Rotate(0,0,rb.velocity.x);
    }
}
