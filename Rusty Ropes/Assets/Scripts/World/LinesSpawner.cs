using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class LinesSpawner : MonoBehaviour{
    public static LinesSpawner instance;
    [SerializeField] public float linesSpacing=2.33f;
    [SerializeField] public float linesFallSpeed=0.5f;
    public List<GameObject> linesGOs;
    public float[] linesPosYs;
    [DisableInEditorMode]public int yPosIDMax;
    [DisableInEditorMode]public float spawnCounter=-4;
    void Awake(){if(instance!=null){Destroy(gameObject);}else{instance=this;}}
    IEnumerator Start(){
        linesGOs.Add(transform.GetChild(0).gameObject);
        transform.GetChild(0).position=new Vector2(transform.GetChild(0).position.x,Playfield.yRange.x+0.2f);
        transform.GetChild(0).gameObject.GetComponent<Line>().fall=true;
        ResetLinesPosYs();
        for(int i=0;i<(Playfield.yRange.y/linesSpacing)*2;i++){//Create lines on whole screen
            yield return new WaitForSeconds(0.01f);
            StartCoroutine(CreateLine());
        }
        spawnCounter=0.04f;
        Player.instance.SetOnMiddleLine();
    }
    void Update(){
        SetLinesPosYs();
        if(spawnCounter>0)spawnCounter-=Time.deltaTime;
        if(spawnCounter<=0&&spawnCounter!=-4){
            if((float)Math.Round(linesGOs[linesGOs.Count-1].transform.position.y+linesSpacing,2)<Playfield.yRange.y+linesSpacing){
                StartCoroutine(CreateLine());
            spawnCounter=0.04f;
            }
        }
    }
    IEnumerator CreateLine(){
        var go=Instantiate(linesGOs[0],transform);linesGOs.Add(go);
        go.transform.position=new Vector2(go.transform.position.x,(float)Math.Round(linesPosYs[linesPosYs.Length-1]+linesSpacing,2));
        yield return new WaitForSeconds(0.01f);
        ResetLinesPosYs();
        var l=go.GetComponent<Line>();
        yPosIDMax++;l.yPosIDAbsolute=yPosIDMax;
        l.fall=true;
    }
    public void ResetLinesPosYs(){
        if(linesPosYs.Length!=linesGOs.Count){linesPosYs=new float[linesGOs.Count];}
        SetLinesPosYs();
    }
    public void SetLinesPosYs(){
        for(int i=0;i<linesGOs.Count;i++){
            var l=linesGOs[i].GetComponent<Line>();
            linesGOs[i].name="Line"+i+" ("+l.yPosIDAbsolute+")";
            l.yPosID=i;
            if(i<linesPosYs.Length)linesPosYs[i]=(float)Math.Round(linesGOs[i].transform.position.y,2);
        }
    }

    public bool PrevLineInPlayfield(int id){
        bool _isPossible=false;
        if(id==0);
        else if(linesPosYs[id-1]>Playfield.yRange.x)_isPossible=true;
        return _isPossible;
    }public bool NextLineInPlayfield(int id){
        bool _isPossible=false;
        if(id>=linesPosYs.Length);
        else if(linesPosYs[id+1]<Playfield.yRange.y)_isPossible=true;
        return _isPossible;
    }public int RandomLineInPlayfield(){
        int id=UnityEngine.Random.Range(0,LinesSpawner.instance.linesPosYs.Length);
        while(linesPosYs[id]>Playfield.yRange.y&&linesPosYs[id]<Playfield.yRange.x){
            id=UnityEngine.Random.Range(0,LinesSpawner.instance.linesPosYs.Length);
        }
        return id;
    }
}

