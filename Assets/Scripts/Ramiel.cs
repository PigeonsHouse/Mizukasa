using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ramiel : MonoBehaviour{
    void Start(){
        
    }

    void Update(){
        
    }

    void OnTriggerEnter2D(Collider2D collider){
        if (collider.gameObject.tag == "Player"){
            Destroy(gameObject);
        }
    }
}
