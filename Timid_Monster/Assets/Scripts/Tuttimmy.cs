using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tuttimmy : MonoBehaviour
{
    public float OneMove = 15f;
    public int EnergyValue = 100;
    public int Giftcount = 0;
    public int direction = 0; //1 for up, 2 for down, 3 for left, 4 for right,record last move
    public bool Victory = false;
    private float currenttime = 0;
    public Text Menergyvalue = null;

    public bool CheckPoint1 = false;
    public bool AttackSpeed = false;

    public SpriteRenderer sr;
    public Sprite[] timmy;
    public int CountRight = 0;
    public int CountLeft = 0;

    //cool down time 
    private float coolDownTime = 0.5f;

    //sound
    public AudioClip Hitwall;
    public AudioClip Walk;
    public AudioClip Win;
    public AudioClip Heal;
    public AudioClip Damage;
    public AudioClip Trap;

    public bool Final;

    // to check which scene is active
    private Scene scene;    
    private Vector3 origin;

    // Start is called before the first frame update
    void Start()
    {
        origin = transform.localPosition;
        EnergyValue = 18;
        currenttime = Time.time;
        Victory = false;
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update(){
        if(Victory){
            Menergyvalue.text = "WIN!!";
           SceneManager.LoadScene("Level1");
        }
        if((EnergyValue <= 0) && (!Victory)){
            Menergyvalue.text = "FAIL!";
         
            SceneManager.LoadScene("TIMMYScene");
        }
        
        Vector3 p = transform.localPosition;
        if (Input.GetKeyDown(KeyCode.A)){
            GetComponent<AudioSource>().clip = Walk;
            GetComponent<AudioSource>().Play();
            CountRight = 0;
            p.x -= OneMove;               
            if(!Final){
                EnergyValue--;
                }
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
            if(!Final){
                EnergyValue--;
            }
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
            if(!Final){
                EnergyValue--;
            }
            direction = 2;
            sr.sprite = timmy[6];
        }
        else if(Input.GetKeyDown(KeyCode.W)){
            GetComponent<AudioSource>().clip = Walk;
            GetComponent<AudioSource>().Play();
            CountLeft = 0;
            CountRight = 0;
            p.y += OneMove;                    
            if(!Final){
                EnergyValue--;
            }
            direction = 1;
            sr.sprite = timmy[7];
        }
        transform.localPosition = p;
        Menergyvalue.text = "" + EnergyValue;

        if(Input.GetKeyDown(KeyCode.V)) Final = true;

        if(Final){
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
        if((collision.gameObject.name == "Flower") || (collision.gameObject.name == "Letter")){ // Flower box need to be bit smaller
            GetComponent<AudioSource>().clip = Heal;
            GetComponent<AudioSource>().Play();
            EnergyValue ++;
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
            EnergyValue --;
        }
        else if(collision.gameObject.name == "Treasure"){
            GetComponent<AudioSource>().clip = Heal;
            GetComponent<AudioSource>().Play();
            Giftcount ++;
        }
        else if(collision.gameObject.name == "Friend"){
            Victory = true;
        }else if(collision.gameObject.name == "Boss"){
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
        else if(collision.gameObject.name == "Gift"){
             Giftcount ++;
            AttackSpeed = true;
            Destroy(collision.gameObject);
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
            Debug.Log("Bullet : " + EnergyValue);
            EnergyValue --;
        }
        else if(collision.gameObject.name == "TraceBullet(Clone)"){
            Debug.Log("Trace : " + EnergyValue);
            EnergyValue --;
        }
        else if(collision.gameObject.name == "Explosion(Clone)"){
            Debug.Log("Explosion : " + EnergyValue);
            EnergyValue --;
        }
    }
    void changeSprite(int num){
        switch(num){
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
        }
        
    }
}
