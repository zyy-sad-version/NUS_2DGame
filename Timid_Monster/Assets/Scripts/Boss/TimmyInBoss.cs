using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimmyInBoss : MonoBehaviour
{
    public GameProperty gameProperty;
    public float OneMove = 30;
    

    public int direction = 0; //1 for up, 2 for down, 3 for left, 4 for right,record last move
    public bool Victory = false;
    private float currenttime = 0;
    public Text Menergyvalue = null;

    // timmy's attack force
    public float atk;
    //cool down time 
    private float coolDownTime;
    public int EnergyValue;
    public int barrierNum;

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

    public float boundl;
    public float boundr;
    public float boundd;
    public float boundu;

    public bool activateAttack = false;

    // to check which scene is active
    private Scene scene;    

    void Awake(){
        LoadProperty();
    }

    // Start is called before the first frame update
    void Start()
    {
        OneMove = 30;
        currenttime = Time.time;
        Victory = false;
        sr = GetComponent<SpriteRenderer>();
    
    }

    // Update is called once per frame
    void Update(){
        OneMove = 30;
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
            
            direction = 2;
            sr.sprite = timmy[6];
        }
        else if((Input.GetKeyDown(KeyCode.W)) && (p.y <= boundu)){
            GetComponent<AudioSource>().clip = Walk;
            GetComponent<AudioSource>().Play();
            CountLeft = 0;
            CountRight = 0;
            p.y += OneMove;                    
            
            direction = 1;
            sr.sprite = timmy[7];
        }
        else if ((Input.GetKeyDown(KeyCode.A)) && (p.x < boundl)){
            GetComponent<AudioSource>().clip = Hitwall;
            GetComponent<AudioSource>().Play();
            sr.sprite = timmy[1];
        }
        else if ((Input.GetKeyDown(KeyCode.D)) && (p.x > boundr)){
            GetComponent<AudioSource>().clip = Hitwall;
            GetComponent<AudioSource>().Play();
            sr.sprite = timmy[4];
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

        if(activateAttack){
            if(Input.GetKey(KeyCode.UpArrow)){
                if ((Time.time - currenttime) > coolDownTime){
                    GameObject e = Instantiate(Resources.Load("Prefabs/Arrow") as GameObject); // Prefab MUST BE located in Resources/Prefabs folder!
                    Vector3 o = transform.localPosition ;
                    o.y += OneMove;
                    e.transform.localPosition = o;
                    Vector3 q = new Vector3(0,1,0);
                    e.transform.up = q;
                    currenttime = Time.time;        
                }
            }
            else if(Input.GetKey(KeyCode.DownArrow)){
                if ((Time.time - currenttime) > coolDownTime){
                    GameObject e = Instantiate(Resources.Load("Prefabs/Arrow") as GameObject); // Prefab MUST BE located in Resources/Prefabs folder!
                    Vector3 o = transform.localPosition ;
                    o.y -= OneMove;
                    e.transform.localPosition = o;
                    Vector3 q = new Vector3(0,-1,0);
                    e.transform.up = q;
                    currenttime = Time.time;        
                }
            }
            else if(Input.GetKey(KeyCode.LeftArrow)){
                if ((Time.time - currenttime) > coolDownTime){
                    GameObject e = Instantiate(Resources.Load("Prefabs/Arrow") as GameObject); // Prefab MUST BE located in Resources/Prefabs folder!
                    Vector3 o = transform.localPosition ;
                    o.x -= OneMove;
                    e.transform.localPosition = o;
                    Vector3 q = new Vector3(-1,0,0);
                    e.transform.up = q;
                    currenttime = Time.time;        
                }
            }
            else if(Input.GetKey(KeyCode.RightArrow)){
                if ((Time.time - currenttime) > coolDownTime){
                    GameObject e = Instantiate(Resources.Load("Prefabs/Arrow") as GameObject); // Prefab MUST BE located in Resources/Prefabs folder!
                    Vector3 o = transform.localPosition ;
                    o.x += OneMove;
                    e.transform.localPosition = o;
                    Vector3 q = new Vector3(1,0,0);
                    e.transform.up = q;
                    currenttime = Time.time;        
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(barrierNum <=0){
            if(collision.gameObject.tag == "Boss"){
                EnergyValue--;
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
            else if(collision.gameObject.tag == "Wall"){
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
            else if(collision.gameObject.name == "Bullet(Clone)"){
                //Debug.Log("Bullet : " + EnergyValue);
                EnergyValue --;
            }
            else if(collision.gameObject.name == "TraceBullet(Clone)"){
                //Debug.Log("Trace : " + EnergyValue);
                EnergyValue --;
            }
            else if(collision.gameObject.name == "Beam(Clone)"){
                //Debug.Log("Beam : " + EnergyValue);
                EnergyValue --;
            }
            else if(collision.gameObject.name == "Explosion(Clone)"){
                //Debug.Log("Explosion : " + EnergyValue);
                EnergyValue --;
            }
            else if(collision.gameObject.name == "SplitBullet(Clone)"){
                EnergyValue --;
            }
    
        }
        else
        {
            barrierNum--;
        }
      }
    
    
    //load the property of timmy from txt file
     void LoadProperty()
    {
        
        gameProperty = GameObject.FindObjectOfType<GameProperty>();
        if(gameProperty.gift1) atk=3;else atk=1;
        if(gameProperty.gift2) coolDownTime=0.3f; else coolDownTime=0.5f;
        if(gameProperty.gift3) barrierNum=3; else barrierNum =0;
        if(gameProperty.gift4) EnergyValue=25; else EnergyValue =20;
    } 
    void CheckPointCheck(){
        Scene scene = SceneManager.GetActiveScene();
         switch(scene.name){
            case "BossScene":{
                gameProperty.checkPoint5=true;
                break;
            }
            case "BossScene2":{
                gameProperty.checkPoint6=true;
                break;
            }
            case "BossScene3":{
                gameProperty.checkPoint7=true;
                break;
            }

        } 
    }

    public void SetActivateAttack(){
        activateAttack = true;
    }
}
