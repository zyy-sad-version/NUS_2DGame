using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    //timmy's attack speed
    public bool gift2;
    //timmt's barrier
    public bool gift3;
    //timmy's max energy
    public bool gift4;
    private static GameProperty  s_instance;
    public string sceneName;
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
     
        getLastGameScene();
    }
    void getLastGameScene(){
        Scene scene = SceneManager.GetActiveScene();
        if(scene.name != "Fail"){
            sceneName = scene.name;
        }
    }
}
