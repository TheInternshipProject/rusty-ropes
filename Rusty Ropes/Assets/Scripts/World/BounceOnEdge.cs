using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceOnEdge : MonoBehaviour{
    [SerializeField]public bool bounceOnY=true;
    [SerializeField]public bool bounceOnX=false;
    Rigidbody2D rb;
    float _margin=0.1f;
    void Start(){
        rb=GetComponent<Rigidbody2D>();
    }
    void Update(){
        if(bounceOnY){if(rb.velocity.y!=0)if(transform.position.y>=Playfield.yRange.y-_margin||transform.position.y<=Playfield.yRange.x+_margin){rb.velocity=new Vector2(rb.velocity.x,rb.velocity.y*-1);}}
        if(bounceOnX){if(rb.velocity.x!=0)if(transform.position.x>=Playfield.xRange.y-_margin||transform.position.x<=Playfield.xRange.x+_margin){rb.velocity=new Vector2(rb.velocity.x*-1,rb.velocity.y);}}
    }
}
