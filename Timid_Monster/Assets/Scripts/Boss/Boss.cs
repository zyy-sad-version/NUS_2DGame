using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private float spawnTime = 8f;        // The amount of time between each spawn.
    private float spawnDelay = 1f;        // The amount of time before spawning starts.
    public int bulletCnt = 0;
    public Vector3[] attackLocations = new Vector3[9];
    public const float RotateSpeed = 0.03f;
    private int totalBlood;
    public int blood = 10;
    public int posCount = 1;
    public Blood bloodBox;

    // Start is called before the first frame update
    void Start()
    {
        totalBlood = blood;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.U)){
            InvokeRepeating("ForecastAttackStyleOne", spawnDelay, spawnTime);
        }
        if(Input.GetKeyDown(KeyCode.I)){
            InvokeRepeating("ForecastAttackStyleTwo", spawnDelay, spawnTime);
        }
        if(Input.GetKeyDown(KeyCode.Q)){
            CancelInvoke();
        }
        if(blood == 0){
            CancelInvoke();
            Destroy(gameObject);
        }
    }

    //Attack in a cross style
    private void ForecastAttackStyleOne(){
        //Debug.Log("forecast attack 1");
        //Forecast attack
        GameObject forecastMark = Instantiate(Resources.Load("Prefabs/ForecastMark") as GameObject);
        forecastMark.transform.localPosition = new Vector3(32F, 40F, -1.1F);
    }

    private void ForecastAttackStyleTwo(){
        //Debug.Log("forecast attack 2");
        //Forecast attack
        for(int i = 1; i <= 8; i++){
            GameObject e = Instantiate(Resources.Load("Prefabs/AttackLocation") as GameObject);
            CameraSupport s = Camera.main.GetComponent<CameraSupport>();
            Vector3 p = transform.localPosition;
            p.x = s.GetWorldBound().min.x + Random.value * 0.8f * s.GetWorldBound().size.x + 0.1f * s.GetWorldBound().size.x;
            p.y = s.GetWorldBound().min.y + Random.value * 0.8f * s.GetWorldBound().size.y + 0.1f * s.GetWorldBound().size.y;
            attackLocations[i] = p;
            e.transform.localPosition = p;
        }
    }

    public void LaunchAttackStyleOne(){
         //Launch Attack
        for(int i = 1; i <= 8; i++){
            GameObject e = Instantiate(Resources.Load("Prefabs/Bullet") as GameObject); // Prefab MUST BE locaed in Resources/Prefabs folder!
            bulletCnt++;
           // Debug.Log("bulletCnt: " + bulletCnt);
            e.transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, 0F) ;
            e.transform.up = transform.up;
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

    public void LaunchAttackStyleTwo(){
         //Launch Attack
        //for(int i = 1; i <= 8; i++){
        GameObject e = Instantiate(Resources.Load("Prefabs/Explosion") as GameObject); // Prefab MUST BE locaed in Resources/Prefabs folder!
        e.transform.localPosition = attackLocations[posCount];
        posCount++;
        if(posCount == 9) posCount = 1;
        //}
    }

    public void DestroyBullet(){
        bulletCnt--;
    }

     private void OnTriggerEnter2D(Collider2D collision){
        if((collision.gameObject.name == "Arrow(Clone)")){ // Flower box need to be bit smaller
           // Debug.Log("boss was hit : " + blood);
            bloodBox.loseHealth( totalBlood, 1, blood);
            blood--;
            
            Destroy(collision.gameObject);
        }
     }
}
