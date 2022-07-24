using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.SceneManagement;

//boss1 attack by full-screen barrage
public class Boss1 : MonoBehaviour
{
    private float spawnTime = 5f;        // The amount of time between each spawn.
    private float spawnDelay = 8f;        // The amount of time before spawning starts.
    public int bulletCnt = 0;
    public Vector3[] attackLocations = new Vector3[9];
    public const float RotateSpeed = 0.03f;
    private float totalBlood;
    public float blood = 10;    //changed from int to float
    public int posCount = 1;

    public TimmyInBoss timmy;
    public Blood bloodBox;

    private bool opt = false;
    


    // Start is called before the first frame update
    void Start()
    {
        totalBlood = blood;
        InvokeRepeating("RandomStyleAttack", spawnDelay, spawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        if(blood <= 0){
            CancelInvoke();
            Destroy(gameObject);
            timmy.Victory = true;
        }
    }
    private void RandomStyleAttack(){
        if(opt){
            AttackByCrossBullet();
            opt = false;
        }
        else{
            opt = true;
            AttackByRotatingBeam();
        }
    }

    //Attack in a cross style
    private void AttackByCrossBullet(){
        //Forecast attack
        GameObject forecastMark = Instantiate(Resources.Load("Prefabs/ForecastMark") as GameObject);
        forecastMark.transform.localPosition = new Vector3(32F, 40F, -1.1F);
    }

    private void AttackByRotatingBeam(){
        for(int i = 1; i <= 8; i++){
            GameObject beam1 = Instantiate(Resources.Load("Prefabs/Beam") as GameObject);
            float posy = -40 - i*20;
            beam1.transform.localPosition = new Vector3(0F, posy, -1F);
        }
        for(int i = 1; i <= 10; i++){
            GameObject beam2 = Instantiate(Resources.Load("Prefabs/Beam") as GameObject);
            float posy = 40 + i*20;
            beam2.transform.localPosition = new Vector3(0F, posy, -1F);
        }
    }

    public void LaunchAttackStyleOne(){
        for(int i = 1; i <= 8; i++){
            GameObject e = Instantiate(Resources.Load("Prefabs/Bullet") as GameObject); // Prefab MUST BE locaed in Resources/Prefabs folder!
            e.GetComponent<Bullet>().boss = this.gameObject;
            bulletCnt++;
            e.transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, 0F) ;
            switch(i){
                case 1:
                    e.transform.Rotate(0, 0, 0);
                    break;
                case 2:
                    e.transform.Rotate(0, 0, -45);
                    break;
                case 3:
                    e.transform.Rotate(0, 0, 45);
                    break;
                case 4:
                    e.transform.Rotate(0, 0, -90);
                    break;
                case 5:
                    e.transform.Rotate(0, 0, 90);
                    break;
                case 6:
                    e.transform.Rotate(0, 0, -135);
                    break;
                case 7:
                    e.transform.Rotate(0, 0, 135);
                    break;
                case 8:
                    e.transform.Rotate(0, 0, -180);
                    break;
            }
        }
    }



     private void OnTriggerEnter2D(Collider2D collision){
        if((collision.gameObject.name == "Arrow(Clone)")){ 
        
            bloodBox.loseHealth(totalBlood, timmy.atk,blood);
            blood-=timmy.atk;
            Destroy(collision.gameObject);
        }
     }
}
