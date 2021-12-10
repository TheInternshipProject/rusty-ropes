using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceOnEdge : MonoBehaviour{
    [SerializeField]public bool bounceOnY=true;
    [SerializeField]public bool bounceOnX=false;
    
    Obstacle obs;
    float _margin=0.1f;
    float bouncedTimer=-4f;
    void Start(){
        obs=GetComponent<Obstacle>();
    }
    void Update(){
        if(bounceOnY){if(obs.velocity.y!=0)if(transform.position.y>=Playfield.yRange.y-_margin||transform.position.y<=Playfield.yRange.x+_margin){
            if(bouncedTimer==-4){bouncedTimer=0.1f;obs.velocity=new Vector2(obs.velocity.x,obs.velocity.y*-1);}}}
        if(bounceOnX){if(obs.velocity.x!=0)if(transform.position.x>=Playfield.xRange.y-_margin||transform.position.x<=Playfield.xRange.x+_margin){
            if(bouncedTimer==-4){bouncedTimer=0.1f;obs.velocity=new Vector2(obs.velocity.x*-1,obs.velocity.y);}}}

        if(bouncedTimer>0)bouncedTimer-=Time.deltaTime;
        if(bouncedTimer<=0&&bouncedTimer!=-4){bouncedTimer=-4;}
    }
}
