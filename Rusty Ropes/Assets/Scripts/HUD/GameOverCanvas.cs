using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverCanvas : MonoBehaviour{
    public static GameOverCanvas instance;
    void Awake(){instance=this;}
    public void OpenGameOverCanvas(bool open=true){
        transform.GetChild(0).gameObject.SetActive(open);
    }
}
