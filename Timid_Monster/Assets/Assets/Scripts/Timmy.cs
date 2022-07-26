using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timmy : MonoBehaviour
{
    public GameProperty gameProperty;
    public float OneMove;
    public int EnergyValue;

    public int direction = 0; //1 for up, 2 for down, 3 for left, 4 for right,record last move
    public bool Victory = false;
    private float currenttime = 0;
    public Text Menergyvalue = null;

    // public bool AttackSpeed;
    // timmy's attack force

    public SpriteRenderer sr;
    public Sprite[] timmy;
    public int CountRight = 0;
    public int CountLeft = 0;

    //sound
    public AudioClip Hitwall;
    public AudioClip Walk;
    public AudioClip Win;
    public AudioClip Heal;
    public AudioClip Damage;
    public AudioClip Trap;
    public AudioClip Gift;
    public AudioClip Special;

    public float boundl;
    public float boundr;
    public float boundu;
    public float boundd;
    public float friendx;
    public float friendy;

    // to check which scene is active
    private Scene scene;    

    void Awake(){
        LoadProperty();
    }

    // Start is called before the first frame update
    void Start()
    {
        
        currenttime = Time.time;
        Victory = false;
        sr = GetComponent<SpriteRenderer>();
    
    }

    // Update is called once per frame
    void Update(){
        if(Victory){
            Menergyvalue.text = "WIN!!";
            OneMove = 0;
            CheckPointCheck();
            
        }
        if((EnergyValue <= 0) && (!Victory)){
            Menergyvalue.text = "FAIL!";
            SceneManager.LoadScene("Fail");
        }
        
        Vector3 p = transform.localPosition;
        if ((Input.GetKeyDown(KeyCode.A)) && (p.x >= boundl)){
            GetComponent<AudioSource>().clip = Walk;
            GetComponent<AudioSource>().Play();
            CountRight = 0;
            p.x -= OneMove;               
            EnergyValue--;
            direction = 3;
            ++CountLeft;
            switch(CountLeft%4){
                case 0:{
                    sr.sprite = timmy[1];
                    break;
                }
                case 1:{
                    sr.sprite = timmy[2];
                    break;
                }
                case 2:{
                    sr.sprite = timmy[1];
                    break;
                }
                case 3:{
                    sr.sprite = timmy[0];
                    break;
                }
            }        }
        else if((Input.GetKeyDown(KeyCode.D)) && (p.x <= boundr)){
            GetComponent<AudioSource>().clip = Walk;
            GetComponent<AudioSource>().Play();
            CountLeft=0;
            p.x += OneMove;    
            EnergyValue--;
            direction = 4;
             ++CountRight;
            switch(CountRight%4){
                case 0:{
                    sr.sprite = timmy[4];
                    break;
                }
                case 1:{
                    sr.sprite = timmy[5];
                    break;
                }
                case 2:{
                    sr.sprite = timmy[4];
                    break;
                }
                case 3:{
                    sr.sprite = timmy[3];
                    break;
                }
            }

        }
        else if((Input.GetKeyDown(KeyCode.S)) && (p.y >= boundd)){
            GetComponent<AudioSource>().clip = Walk;
            GetComponent<AudioSource>().Play();
            CountLeft = 0;
            CountRight = 0;
            p.y -= OneMove;                
            EnergyValue--;
            direction = 2;
            sr.sprite = timmy[6];
        }
        else if((Input.GetKeyDown(KeyCode.W)) && (p.y <= boundu)){
            GetComponent<AudioSource>().clip = Walk;
            GetComponent<AudioSource>().Play();
            CountLeft = 0;
            CountRight = 0;
            p.y += OneMove;                    
            EnergyValue--;
 
            direction = 1;
            sr.sprite = timmy[7];
        }
        else if ((Input.GetKeyDown(KeyCode.A)) && (p.x < boundl)){
            GetComponent<AudioSource>().clip = Hitwall;
            GetComponent<AudioSource>().Play();
            sr.sprite = timmy[1];
        }
        else if ((Input.GetKeyDown(KeyCode.D)) && (p.x > boundr)){
            if((p.x == friendx) && (p.y == friendy)){
                GetComponent<AudioSource>().clip = Walk;
                GetComponent<AudioSource>().Play();
                p.x += OneMove;    
                EnergyValue--;
                direction = 4;
            }
            else {
                GetComponent<AudioSource>().clip = Hitwall;
                GetComponent<AudioSource>().Play();
                sr.sprite = timmy[4];
            }
        }
        else if ((Input.GetKeyDown(KeyCode.W)) && (p.y > boundu)){
            GetComponent<AudioSource>().clip = Hitwall;
            GetComponent<AudioSource>().Play();
            sr.sprite = timmy[7];
        }
        else if ((Input.GetKeyDown(KeyCode.S)) && (p.y < boundd)){
            GetComponent<AudioSource>().clip = Hitwall;
            GetComponent<AudioSource>().Play();
            sr.sprite = timmy[6];
        }
        transform.localPosition = p;
        Menergyvalue.text = "" + EnergyValue;
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if((collision.gameObject.name == "Flower") || (collision.gameObject.name == "Letter")){ // Flower box need to be bit smaller
            GetComponent<AudioSource>().clip = Heal;
            GetComponent<AudioSource>().Play();
            EnergyValue += 2;
            Destroy(collision.gameObject);
        }
        else if(collision.gameObject.name == "Trap"){
            GetComponent<AudioSource>().clip = Trap;
            GetComponent<AudioSource>().Play();
            EnergyValue --;
        }
        else if(collision.gameObject.name == "Enemy"){
            GetComponent<AudioSource>().clip = Damage;
            GetComponent<AudioSource>().Play();
            EnergyValue--;
        }
        else if(collision.gameObject.tag == "SpecialWall"){
            GetComponent<AudioSource>().clip = Special;
            GetComponent<AudioSource>().Play();
        }
        else if(collision.gameObject.name == "Friend"){
            Debug.Log("Win");
            Victory = true;
        }
        else if(collision.gameObject.tag == "Gift"){
            GetComponent<AudioSource>().clip = Gift;
            GetComponent<AudioSource>().Play();
            Destroy(collision.gameObject);
        }
        else if(collision.gameObject.tag == "Wall"){
            EnergyValue ++;
            GetComponent<AudioSource>().clip = Hitwall;
            GetComponent<AudioSource>().Play();
            Vector3 p = transform.localPosition;
            switch (direction){
                case 1:{
                    p.y -= OneMove;
                    break;
                }
                case 2:{
                    p.y += OneMove;
                    break;
                }
                case 3 :{
                    p.x += OneMove;
                    break;
                }
                case 4:{
                    p.x -= OneMove;
                    break;
                }
            }
            transform.localPosition = p;
        }
        
    }
    
    
    //load the property of timmy from txt file
     void LoadProperty()
    {
        gameProperty = GameObject.FindObjectOfType<GameProperty>();

    }  
    void CheckPointCheck(){
        Scene scene = SceneManager.GetActiveScene();
          switch(scene.name){
            case "Level1":{
                gameProperty.checkPoint1=true;
                break;
            }
            case "Level2":{
                gameProperty.checkPoint2=true;
                break;
            }
            case "Level3":{
                gameProperty.checkPoint3=true;
                break;
            }
            case "Level4":{
                gameProperty.checkPoint4=true;
                break;
            }
         

        }  
    }
}
