using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinesSpawner : MonoBehaviour{
    public static LinesSpawner instance;
    [SerializeField] public int linesAmnt=4;
    [SerializeField] public float linesSpacing=2.33f;
    public GameObject[] linesGOs;
    public float[] linesPosYs;
    void Awake(){if(instance!=null){Destroy(gameObject);}else{instance=this;}}
    void Start(){
        linesGOs=new GameObject[linesAmnt];
        linesGOs[0]=transform.GetChild(0).gameObject;
        for(int i=1;i<linesAmnt;i++){
            linesGOs[i]=Instantiate(linesGOs[0],transform);
            linesGOs[i].transform.localPosition=new Vector2(linesGOs[0].transform.localPosition.x,linesGOs[0].transform.localPosition.y-(linesSpacing*i));
            linesGOs[i].name="Line"+(i+1);
        }
    }
    void Update(){
        if(linesPosYs.Length!=linesGOs.Length){linesPosYs=new float[linesGOs.Length];}
        for(int i=0;i<linesGOs.Length;i++){
            if(linesPosYs[i]!=linesGOs[i].transform.position.y)linesPosYs[i]=linesGOs[i].transform.position.y;
        }
    }
}
