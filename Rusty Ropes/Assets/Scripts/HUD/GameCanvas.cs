using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCanvas : MonoBehaviour{
    public static GameCanvas instance;
    void Awake(){
        instance=this;
    }
    void Update(){
        //popupSumTime=SaveSerial.instance.settingsData.popupSumTime;
        /*if(hpPopup!=null&&hpCount!=0){string symbol="-";if(hpCount>0){symbol="+";}hpPopup.GetComponentInChildren<TMPro.TextMeshProUGUI>().text=
        symbol+System.Math.Abs(System.Math.Round(hpCount,1)).ToString();}*/
        /*if(scPopup!=null&&scCount!=0){string symbol="-";if(scCount>0){symbol="+";}scPopup.GetComponentInChildren<TMPro.TextMeshProUGUI>().text=
        symbol+System.Math.Abs(System.Math.Round(scCount,1)).ToString();}*/

        if(Time.timeScale>0.0001f){
            //if(hpTimer>0){hpTimer-=Time.unscaledDeltaTime;}
            //if(scTimer>0){scTimer-=Time.unscaledDeltaTime;}
        }
    }
    public static GameObject CreateOnUI(GameObject obj, Vector2 position){
        GameCanvas canvas=FindObjectOfType<GameCanvas>();
        GameObject childObject=Instantiate(obj,Camera.main.WorldToScreenPoint(position),Quaternion.identity,canvas.transform);
        //childObject.transform.parent=canvas.transform;
        childObject.transform.SetParent(canvas.transform);
        childObject.transform.position=Camera.main.WorldToScreenPoint(position);
        return childObject;
    }
}
