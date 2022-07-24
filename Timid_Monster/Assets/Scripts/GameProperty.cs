using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameProperty : MonoBehaviour
{

    public bool checkPoint1;
    public bool checkPoint2;
    public bool checkPoint3;
    public bool checkPoint4;

    public bool checkPoint5;
    public bool checkPoint6;
    public bool checkPoint7;


    //timmy's attack force
    public bool gift1;
    public float atk;
    //timmy's attack speed
    public bool gift2;
    public float attackSpeed;
    //timmt's barrier
    public bool gift3;
    public int barrier;
    //timmy's max energy
    public bool gift4;
    public int maxEnergy;
    public int giftcount;
    private static GameProperty  s_instance;
    void Awake(){
        if(s_instance!=null){
        Destroy(gameObject);

        }
        else{
            s_instance = this;
            DontDestroyOnLoad(this.gameObject); 
        }
        
            
        
    }
    // Start is called before the first frame update
    void Start()
    {
        checkPoint1=false;
        checkPoint2=false;
        checkPoint3=false;
        checkPoint4=false;
        checkPoint5=false;
        checkPoint6=false;
        checkPoint7=false;
        gift1=false;
        gift2=false;
        gift3=false;
        gift4=false;

        atk=1;
        attackSpeed=0.5f;
        maxEnergy=20;
        barrier=0;
        giftcount=0;
    }

    // Update is called once per frame
    void Update()
    {
        //save point for boss level
        if(checkPoint5&checkPoint6&checkPoint7){
            checkPoint5=!checkPoint5;
            checkPoint6=!checkPoint6;
            checkPoint7=!checkPoint7;
        }
        if(gift1) atk=3;
        if(gift2) attackSpeed=0.3f;
        if(gift3) barrier=3;
        if(gift4) maxEnergy=25;
    }
}
