using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinesSpawnerOld : MonoBehaviour{
    public static LinesSpawnerOld instance;
    [SerializeField] public int linesAmnt=4;
    [SerializeField] public float linesSpacing=2.33f;
    public List<GameObject> linesGOs;
    public List<float> linesPosYs;
    void Awake(){if(instance!=null){Destroy(gameObject);}else{instance=this;}}
    void Start(){
        if(linesAmnt%2==1){linesGOs.Add(transform.GetChild(0).gameObject);}//Add the first child on Uneven
        
        for(int i=0,e=0,u=0;i<linesAmnt;i++){
            linesGOs.Add(Instantiate(linesGOs[0],transform));
            if(linesAmnt%2==0){linesGOs.Remove(transform.GetChild(0).gameObject);Destroy(transform.GetChild(0).gameObject);}//Destroy the first child on Even

            if(linesAmnt%2==1){//Uneven
                if(i==0)i=1;
                if(i%2==0){e++;linesGOs[i].transform.localPosition=new Vector2(linesGOs[0].transform.localPosition.x,linesGOs[0].transform.localPosition.y-(linesSpacing*e));}
                else{u++;linesGOs[i].transform.localPosition=new Vector2(linesGOs[0].transform.localPosition.x,linesGOs[0].transform.localPosition.y+(linesSpacing*u));}
            }else{//Even
                if(i%2==0){e++;linesGOs[i].transform.localPosition=new Vector2(linesGOs[0].transform.localPosition.x,0-(linesSpacing*e));}
                else{u++;linesGOs[i].transform.localPosition=new Vector2(linesGOs[0].transform.localPosition.x,0+(linesSpacing*u));}
            }
            //linesGOs[i].name="Line"+(i+1);
            SetLinesPosYs();
            SortLines();
        }
    }
    void Update(){
        SetLinesPosYs();
        SortLines();
    }
    void SetLinesPosYs(){
        for(int i=0;i<linesGOs.Count;i++){
            if(linesGOs[i]!=null)if(!linesPosYs.Contains(linesGOs[i].transform.position.y))linesPosYs.Add(linesGOs[i].transform.position.y);
        }
        if(linesPosYs.Count>0){
            linesPosYs.Sort();
            if(linesPosYs[0]<0)linesPosYs.Reverse();
        }
    }
    void SortLines(){
        if(linesGOs.Count>0){
            for(int i=0;i<linesGOs.Count;i++){
                //linesGOs.Sort(gameObject.CompPos.Compare(linesGOs[i].transform.position.y,linesPosYs[i]));
                //linesGOs=linesGOs.SortByDistance(Vector2.zero);
                linesGOs[i].transform.position=new Vector2(linesGOs[i].transform.position.x,linesPosYs[i]);
                linesGOs[i].name="Line"+(i+1);
                linesGOs[i].transform.SetSiblingIndex(i);
            }
        }
    }
    /*class CompPos : IComparer<float>{
        public int Compare(float x, float y){
            var dif=x.CompareTo(y);
            return dif;
        }
    }*/
}

