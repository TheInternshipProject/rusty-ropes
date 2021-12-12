using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : MonoBehaviour{
    [SerializeField] public float deccelRate=4f;
    [SerializeField] public float startDeccelTimer=0.8f;
    bool revert;
    Obstacle obs;
    void Start(){
        obs=GetComponent<Obstacle>();
    }
    void Update(){
        if(startDeccelTimer>0)startDeccelTimer-=Time.deltaTime;
        float step=deccelRate*Time.deltaTime;
        int dir=1;if(obs.startVel.x>0){dir=-1;}
        if(startDeccelTimer<=0&&
        ((obs.startVel.x>0&&obs.velocity.x>=obs.startVel.x*-1)||
        (obs.startVel.x<0&&obs.velocity.x<=obs.startVel.x*-1))){
            obs.velocity=new Vector2(obs.velocity.x+(step*dir),0);
        }

        float rotStep=obs.velocity.x*Time.deltaTime*Mathf.Abs(obs.startVel.x);
        transform.Rotate(0,0,rotStep);
    }
}
