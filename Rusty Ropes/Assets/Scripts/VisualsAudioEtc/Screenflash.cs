using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Screenflash : MonoBehaviour{
    [SerializeField] Color damageFlashColor;
    [SerializeField] float damageFlashSpeed;
    [SerializeField] Color healFlashColor;
    [SerializeField] float healedFlashSpeed;
    Image img;
    void Start(){
        img=GetComponent<Image>();
    }
    void Update(){if(Player.instance!=null){
        if(Player.instance.damaged==true){img.color=damageFlashColor;Player.instance.damaged=false;}
        else{img.color=Color.Lerp(img.color,Color.clear, damageFlashSpeed*Time.deltaTime);}
        if(Player.instance.healed==true){img.color=healFlashColor;Player.instance.healed=false;}
        else{img.color=Color.Lerp(img.color,Color.clear, healedFlashSpeed*Time.deltaTime);}
    }}
}
