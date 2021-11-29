using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineCreator : MonoBehaviour{
    [SerializeField] public int linesAmnt=4;
    [SerializeField] public float linesSpacing=2.33f;
    [SerializeField] public GameObject[] linesGOs;
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
        
    }
}
