using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sea : MonoBehaviour{
    public GameObject player;
    public float camcenter_x;
    public float speed;
    private Player playersc;
    private float heightpow;

    void Start(){
        playersc = player.GetComponent<Player>();
    }
    void Update(){
        if(!playersc.isDeath && this.transform.position.y < 108.25f){
            heightpow = Input.GetAxis("Vertical");
            if(heightpow > 0){
                this.transform.Translate(0f, speed * heightpow * Time.deltaTime, 0f);
            }
            if(this.transform.position.y < -12f){
                this.transform.position = new Vector2(this.transform.position.x, -12f);
            }
/*            if(player.transform.position.x > camcenter_x){
                this.transform.position = new Vector2(player.transform.position.x, this.transform.position.y);
            }*/
        }
    }
}