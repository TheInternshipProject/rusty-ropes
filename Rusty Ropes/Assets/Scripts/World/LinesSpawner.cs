using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinesSpawner : MonoBehaviour{
    public static LinesSpawner instance;
    [SerializeField] public float linesSpacing=2.33f;
    [SerializeField] public float linesFallSpeed=0.5f;
    public List<GameObject> linesGOs;
    public float[] linesPosYs;
    public int yPosIDMax;
    public float spawnCounter=-4;
    void Awake(){if(instance!=null){Destroy(gameObject);}else{instance=this;}}
    IEnumerator Start(){
        linesGOs.Add(transform.GetChild(0).gameObject);
        transform.GetChild(0).position=new Vector2(transform.GetChild(0).position.x,Playfield.yRange.x+0.2f);
        transform.GetChild(0).gameObject.GetComponent<Line>().fall=true;
        ResetLinesPosYs();
        for(int i=0;i<5;i++){
            yield return new WaitForSeconds(0.01f);
            StartCoroutine(CreateLine());
        }
        spawnCounter=linesFallSpeed*5;
    }
    void Update(){
        SetLinesPosYs();
        if(spawnCounter>0)spawnCounter-=Time.deltaTime;
        if(spawnCounter<=0&&spawnCounter!=-4){
            if((float)Math.Round(linesGOs[linesGOs.Count-1].transform.position.y+linesSpacing,2)<Playfield.yRange.y+linesSpacing){
                StartCoroutine(CreateLine());
            spawnCounter=linesFallSpeed*5;
            }
        }
    }
    IEnumerator CreateLine(){
        var go=Instantiate(linesGOs[0],transform);linesGOs.Add(go);
        go.transform.position=new Vector2(go.transform.position.x,(float)Math.Round(linesPosYs[linesPosYs.Length-1]+linesSpacing,2));
        yield return new WaitForSeconds(0.01f);
        ResetLinesPosYs();
        yPosIDMax++;go.GetComponent<Line>().yPosID=yPosIDMax;
        go.GetComponent<Line>().fall=true;
    }
    void ResetLinesPosYs(){
        if(linesPosYs.Length!=linesGOs.Count){linesPosYs=new float[linesGOs.Count];}
        SetLinesPosYs();
    }
    void SetLinesPosYs(){
        for(int i=0;i<linesGOs.Count;i++){
            linesGOs[i].name="Line"+i;
            if(i<linesPosYs.Length)linesPosYs[i]=(float)Math.Round(linesGOs[i].transform.position.y,2);
        }
    }
}

