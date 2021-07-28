using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour{
    public int ramPoint = 0;
    public float halfStageLength;
    public float speed;
    public float jumpforce;
    public bool isDeath;
    public bool isClear;
    public LayerMask groundLayer;
    public LayerMask seaLayer;
    private float horipow;
    private bool isGround;
    private bool isSea;
    private bool isPress;
    private Animator anim;
    private Rigidbody2D rb2d;
    private SpriteRenderer spRenderer;

    void Start(){
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        spRenderer = GetComponent<SpriteRenderer>();
    }

    void Update(){
        if(!isClear){
            if(!isDeath){ 
                horipow = Input.GetAxis("Horizontal");
                gameObject.transform.Translate(speed * horipow * Time.deltaTime, 0f, 0f);
                if(gameObject.transform.position.x < -halfStageLength){
                    gameObject.transform.position = new Vector2(-halfStageLength, gameObject.transform.position.y);
                    rb2d.velocity = new Vector2(0f, rb2d.velocity.y);
                }
                if(gameObject.transform.position.x > halfStageLength){
                    gameObject.transform.position = new Vector2(halfStageLength, gameObject.transform.position.y);
                    rb2d.velocity = new Vector2(0f, rb2d.velocity.y);
                }
                if(Input.GetButtonDown("Jump") && (isGround || isSea)){
                    rb2d.AddForce(Vector2.up * jumpforce);
                }
                if(!Input.GetButton("Jump") && rb2d.velocity.y > 0 ){
                    rb2d.AddForce( Vector2.down * 20f);
                }
            }
            if(Input.GetKeyDown("r")){
                    SceneManager.LoadScene("Game");
            }
            if(gameObject.transform.position.x > 7.5f && gameObject.transform.position.y > 114f){
                isClear = true;
            }
        }
    }

    void FixedUpdate(){
        isGround = false;
        isSea = false;
        Vector2 groundPos = new Vector2 ( transform.position.x, transform.position.y - 0.5f);
        Vector2 groundArea = new Vector2( 0.14f, 0.25f );
        Vector2 HeadPos = new Vector2 ( transform.position.x, transform.position.y + 0.1f);
        Vector2 HeadArea = new Vector2( 0.2f, 0.125f );
        isGround = Physics2D.OverlapArea( groundPos + groundArea, groundPos - groundArea, groundLayer );
        isSea = Physics2D.OverlapArea( groundPos + groundArea, groundPos - groundArea, seaLayer );
        isPress = Physics2D.OverlapArea( HeadPos + HeadArea, HeadPos - HeadArea, groundLayer );
        Debug.DrawLine( HeadPos + HeadArea, HeadPos - HeadArea, Color.red );
        if(isPress){
            isDeath = true;
        }
        if(isDeath){
            rb2d.velocity = Vector2.zero;
            rb2d.gravityScale = 0f;
        }
        anim.SetBool("isDeath", isDeath );
    }

    void OnTriggerEnter2D(Collider2D collider){
        if(!isDeath){
            if (collider.gameObject.tag == "Ramiel"){
                ramPoint += 1;
            }
            if (collider.gameObject.tag == "Poison"){
                isDeath = true;
            }
        }
    }

    void Invisible(){
        spRenderer.material.color = Color.clear;
    }
}
