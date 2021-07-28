using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSystem : MonoBehaviour{
    public int timerUI;
    public float timer = 0;
    public Text timerTxt;
    public Text ramTxt;
    public GameObject player;
    private Player playersc;
    private int oldTimer = -1;
    private int oldRam   = -1;

    void Start(){
        playersc = player.GetComponent<Player>();
    }

    void Update(){
        if(!playersc.isClear && !playersc.isDeath){
            timer += Time.deltaTime;
            timerUI = (int)timer;
            if(oldTimer != timerUI){
                if(timerUI >= 100){
                    timerTxt.text = "Time : ";
                }else if(timerUI >= 10){
                    timerTxt.text = "Time : 0";
                }else{
                    timerTxt.text = "Time : 00";
                }
                timerTxt.text += timerUI.ToString();
                oldTimer = timerUI;
            }
            if(oldRam != playersc.ramPoint){
                if(playersc.ramPoint >= 10){
                    ramTxt.text = "× ";
                }else{
                    ramTxt.text = "× 0";
                }
                ramTxt.text += playersc.ramPoint.ToString();
                oldRam = playersc.ramPoint;
            }
        }
        if(playersc.isClear){
            
        }
    }
}
