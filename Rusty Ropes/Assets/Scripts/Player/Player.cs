using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class Player : MonoBehaviour{
    public static Player instance;
    [Header("Properties")]
    [SerializeField]public float healthMax=20f;
    [SerializeField]public float healthStart=20f;
    [DisableInEditorMode]public float health;
    [SerializeField]public float speed=6f;

    [SerializeField]int yPosID;

    [HideInInspector]public bool damaged=false;
    [HideInInspector]public bool healed=false;
    [HideInInspector]public bool shadowed=false;
    [HideInInspector]public bool dashing=false;
    [HideInInspector]public bool flamed=false;
    [HideInInspector]public bool electricified=false;
    Rigidbody2D rb;
    void Awake(){instance=this;}
    IEnumerator Start(){
        rb=GetComponent<Rigidbody2D>();
        health=healthStart;
        yield return new WaitForSeconds(0.02f);
        yPosID=LinesSpawner.instance.linesPosYs.Length/2;
        transform.position=new Vector2(0,LinesSpawner.instance.linesPosYs[yPosID]);
    }
    void Update(){
        MovePlayer();
        Die();
        health=Mathf.Clamp(health,0,healthMax);
    }
    void MovePlayer(){
        var newXpos=transform.position.x;
        var newYpos=transform.position.y;

        if(Input.GetKeyDown(KeyCode.W)){if(yPosID>0){yPosID--;AudioManager.instance.Play("LineSwitch");}}
        else if(Input.GetKeyDown(KeyCode.S)){if(yPosID<LinesSpawner.instance.linesPosYs.Length-1){yPosID++;AudioManager.instance.Play("LineSwitch");}}
        yPosID=Mathf.Clamp(yPosID,0,LinesSpawner.instance.linesPosYs.Length-1);
        newYpos=LinesSpawner.instance.linesPosYs[yPosID];

        float deltaX=0f;
        deltaX=Input.GetAxis("Horizontal")*speed*Time.deltaTime;
        newXpos=Mathf.Clamp(transform.position.x,Playfield.xRange.x,Playfield.xRange.y)+deltaX;
        transform.position=new Vector2(newXpos,newYpos);
    }
    void OnTriggerEnter2D(Collider2D other){
        float dmg=0;dmgType dmgType=dmgType.normal;
        if(other.gameObject.CompareTag("Obstacle")){dmg=1;Destroy(other.gameObject);}
        Damage(dmg,dmgType);
    }
    void Die(){if(health<=0){
        Destroy(gameObject,0.01f);AudioManager.instance.Play("PlayerDeath");GameOverCanvas.instance.OpenGameOverCanvas();
    }}
    public void Damage(float dmg, dmgType type){
        if(type!=dmgType.heal&&type!=dmgType.healSilent)if(dmg!=0){health-=dmg;/*HPPopUpHUD(-dmg);*/}

        if(type==dmgType.silent){damaged=true;}
        if(type==dmgType.normal){damaged=true;AudioManager.instance.Play("PlayerHit");}
        if(type==dmgType.flame){flamed=true;AudioManager.instance.Play("Fire");}
        if(type==dmgType.decay){damaged=true;AudioManager.instance.Play("Decay");}
        if(type==dmgType.electr){electricified=true;/*Electrc(electrTime);*/}//electricified=true;AudioManager.instance.Play("Electric");}
        if(type==dmgType.shadow){shadowed=true;AudioManager.instance.Play("ShadowHit");}
        if(type==dmgType.heal){healed=true;if(dmg!=0){health+=dmg;/*HPPopUpHUD(dmg);*/}}
        if(type==dmgType.healSilent){if(dmg!=0){health+=dmg;/*HPPopUpHUD(dmg);*/}}
    }
}