using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour{
    [SerializeField] float strength=3f;
    void OnTriggerEnter2D(Collider2D other){
        if(other.GetComponent<PlayerHUB>()!=null){
            other.GetComponent<Rigidbody2D>().velocity=new Vector2(other.GetComponent<Rigidbody2D>().velocity.x,other.GetComponent<Rigidbody2D>().velocity.y+strength);
        }
    }
}
