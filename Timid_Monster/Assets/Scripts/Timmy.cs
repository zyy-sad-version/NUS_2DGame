using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timmy : MonoBehaviour
{
    public float OneMove = 15f;
    public int EnergyValue = 100;
    public int Giftcount = 0;
    public int direction = 0; //1 for up, 2 for down, 3 for left, 4 for right,record last move
    public bool Victory = false;
    private float currenttime = 0;
    public Text Menergyvalue = null;

    //cool down time 
    private float coolDownTime = 0.5f;

    public bool Final = true;    

    // Start is called before the first frame update
    void Start()
    {
        EnergyValue = 18;
        currenttime = Time.time;
        Victory = false;
        Final = true;
    }

    // Update is called once per frame
    void Update(){
        if((EnergyValue == 0) && (!Victory)){
            Menergyvalue.text = "FAIL!";
            return;
        }
        if(Victory){
            Menergyvalue.text = "WIN!!";
            return;
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
            p.x -= OneMove;               
            EnergyValue --;
            direction = 3;
        }
        else if(Input.GetKeyDown(KeyCode.D)){
            p.x += OneMove;    
            EnergyValue --;
            direction = 4;
        }
        else if(Input.GetKeyDown(KeyCode.S)){
            p.y -= OneMove;                
            EnergyValue --;
            direction = 2;
        }
        else if(Input.GetKeyDown(KeyCode.W)){
            p.y += OneMove;                    
            EnergyValue --;
            direction = 1;
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
            EnergyValue ++;
            Destroy(collision.gameObject);
        }
        else if((collision.gameObject.name == "Trap") || (collision.gameObject.name == "Enemy")){
            EnergyValue --;
        }
        else if(collision.gameObject.name == "Treasure"){
            Giftcount ++;
        }
        else if(collision.gameObject.name == "Friend"){
            Debug.Log("friend collide");
            Victory = true;
        }
        else if(collision.gameObject.name == "Wall"){
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
}
