using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimmyInBoss : MonoBehaviour
{
    public GameProperty gameProperty;
    public float OneMove;
    public int EnergyValue;
    public int Giftcount;

    public int direction = 0; //1 for up, 2 for down, 3 for left, 4 for right,record last move
    public bool Victory = false;
    private float currenttime = 0;
    public Text Menergyvalue = null;

    // timmy's attack force
    public float atk;

    public SpriteRenderer sr;
    public Sprite[] timmy;
    public int CountRight = 0;
    public int CountLeft = 0;

    //cool down time 
    private float coolDownTime;

    //sound
    public AudioClip Hitwall;
    public AudioClip Walk;
    public AudioClip Win;
    public AudioClip Heal;
    public AudioClip Damage;
    public AudioClip Trap;


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

        if(Input.GetKey(KeyCode.Q)){ // quit
            #if UNITY_EDITOR 
                UnityEditor.EditorApplication.isPlaying = false;
            #else 
                Application.Quit();
            #endif
        }
        
        Vector3 p = transform.localPosition;
        if (Input.GetKeyDown(KeyCode.A)){
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
        else if(Input.GetKeyDown(KeyCode.D)){
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
        else if(Input.GetKeyDown(KeyCode.S)){
            GetComponent<AudioSource>().clip = Walk;
            GetComponent<AudioSource>().Play();
            CountLeft = 0;
            CountRight = 0;
            p.y -= OneMove;                
            
            direction = 2;
            sr.sprite = timmy[6];
        }
        else if(Input.GetKeyDown(KeyCode.W)){
            GetComponent<AudioSource>().clip = Walk;
            GetComponent<AudioSource>().Play();
            CountLeft = 0;
            CountRight = 0;
            p.y += OneMove;                    
            
            direction = 1;
            sr.sprite = timmy[7];
        }
        transform.localPosition = p;
        Menergyvalue.text = "" + EnergyValue;

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

    private void OnTriggerEnter2D(Collider2D collision){
        if(gameProperty.barrier <=0){
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
            gameProperty.barrier--;
        }
      }
    
    
    //load the property of timmy from txt file
    void LoadProperty()
    {
        gameProperty = GameObject.FindObjectOfType<GameProperty>();
        atk=gameProperty.atk;
        Giftcount = gameProperty.giftcount;
        EnergyValue = gameProperty.maxEnergy;
        coolDownTime = gameProperty.attackSpeed;

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
}
