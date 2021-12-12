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
    void Start(){
        linesGOs.Add(transform.GetChild(0).gameObject);
        transform.GetChild(0).position=new Vector2(transform.GetChild(0).position.x,Playfield.yRange.x-0.2f);
        for(int i=0;i<4;i++){
            var go=Instantiate(linesGOs[0],transform);linesGOs.Add(go);
            SetLinesPosYs();
            go.transform.position=new Vector2(go.transform.position.x,(float)Math.Round(linesPosYs[linesPosYs.Length-1]+linesSpacing,2));
            yPosIDMax++;go.GetComponent<Line>().yPosID=yPosIDMax;
        }
        spawnCounter=linesFallSpeed*5;
    }
    void Update(){
        if(spawnCounter>0)spawnCounter-=Time.deltaTime;
        if(spawnCounter<=0&&spawnCounter!=-4){
            if(linesPosYs[0]!=((float)Math.Round(linesGOs[linesGOs.Count-1].transform.position.y+linesSpacing,2))&&
            (float)Math.Round(linesGOs[linesGOs.Count-1].transform.position.y+linesSpacing,2)<Playfield.yRange.y){
                var go=Instantiate(linesGOs[0],transform);linesGOs.Add(go);
                SetLinesPosYs();
                go.transform.position=new Vector2(go.transform.position.x,(float)Math.Round(linesPosYs[linesPosYs.Length-1]+linesSpacing,2));
                yPosIDMax++;go.GetComponent<Line>().yPosID=yPosIDMax;
            }
            spawnCounter=linesFallSpeed*5;
        }
        SetLinesPosYs();
    }
    void SetLinesPosYs(){
        var _linesPosYsTemp=new float[1];
        if(_linesPosYsTemp.Length!=linesGOs.Count){_linesPosYsTemp=new float[linesGOs.Count];}
        for(int i=0;i<linesGOs.Count;i++){
            if(linesGOs[i]!=null){
                _linesPosYsTemp[i]=(float)Math.Round(linesGOs[i].transform.position.y,2);
            }
        }
        if(linesPosYs.Length!=_linesPosYsTemp.Length){linesPosYs=new float[_linesPosYsTemp.Length];}
        for(int i=0;i<linesGOs.Count;i++){
            linesGOs[i].name="Line"+i;
            linesPosYs[i]=(float)Math.Round(_linesPosYsTemp[i],2);
        }
        //Array.Sort(linesPosYs);
    }
}

