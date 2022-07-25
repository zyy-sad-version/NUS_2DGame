using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Boss3 : MonoBehaviour
{
    private float spawnTime = 3f;        // The amount of time between each spawn.
    private float spawnDelay = 5f;        // The amount of time before spawning starts.
    public int bulletCnt = 0;
    public Vector3[] attackLocations = new Vector3[9];
    public const float RotateSpeed = 0.03f;
    private float totalBlood;
    public float blood = 30;
    public int posCount = 1;
    public Blood bloodBox;
    public TimmyInBoss timmy;
    private bool opt = false;

    private int attackCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        totalBlood = blood;
        InvokeRepeating("RandomStyleAttack", spawnDelay, spawnTime);
        timmy = GameObject.Find("Timmy").GetComponent<TimmyInBoss>();
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
        attackCount ++;
        if(attackCount == 2){
            timmy.SetActivateAttack();
        }
        if(opt){
            AttackByTraceBullet();
            opt = false;
        }
        else{
            AttackByBountifulBullet();
            opt = true;
        }
    }

    private void AttackByBountifulBullet(){
        CameraSupport s = Camera.main.GetComponent<CameraSupport>();
        Vector3 dir = transform.localPosition;
        dir.x = s.GetWorldBound().min.x + Random.value * 0.8f * s.GetWorldBound().size.x + 0.1f * s.GetWorldBound().size.x;
        dir.y = s.GetWorldBound().min.y + Random.value * 0.8f * s.GetWorldBound().size.y + 0.1f * s.GetWorldBound().size.y;
        GameObject e = Instantiate(Resources.Load("Prefabs/BountifulBullet") as GameObject);
        e.transform.localPosition = new Vector3(dir.x, dir.y , -1F);
    }

    //Attack in a cross style
    private void AttackByTraceBullet(){
        GameObject forecastMark = Instantiate(Resources.Load("Prefabs/ForecastMark3") as GameObject);
        forecastMark.transform.localPosition = new Vector3(32F, 40F, -1.1F);
    }

    public void LaunchAttackStyleThree(){
         //Launch Attack
        GameObject fe = GameObject.Find("TraceBullet(Clone)");
        Destroy(fe);
        GameObject e = Instantiate(Resources.Load("Prefabs/TraceBullet") as GameObject); // Prefab MUST BE locaed in Resources/Prefabs folder!
        bulletCnt++;
        e.transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, 0F);
    }

    public void DestroyBullet(){
        bulletCnt--;
    }

     private void OnTriggerEnter2D(Collider2D collision){
        if((collision.gameObject.name == "Arrow(Clone)")){ // Flower box need to be bit smaller
           // Debug.Log("boss was hit : " + blood);
            bloodBox.loseHealth(totalBlood, timmy.atk,blood);
            blood-=timmy.atk;
            Destroy(collision.gameObject);
        
            
        }
     }
}
