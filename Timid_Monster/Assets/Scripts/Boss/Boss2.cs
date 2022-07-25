using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Boss2 : MonoBehaviour
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

    private int opt = 0;
    private int attackCount = 0;

    private float speed = 30f;
    private int towards;
    private GameObject mTarget = null;

    // Start is called before the first frame update
    void Start()
    {
        totalBlood = blood;
        InvokeRepeating("RandomStyleAttack", spawnDelay, spawnTime);
        timmy = GameObject.Find("Timmy").GetComponent<TimmyInBoss>();
        towards = Random.Range(1, 5);
    }

    // Update is called once per frame
    void Update()
    {
        if(blood <= 0){
            CancelInvoke();
            Destroy(gameObject);
            timmy.Victory =true;
           // SceneManager.LoadScene("BossScene3");
        }
        if(towards == 1){
            mTarget = GameObject.Find("A");
        }
        if(towards == 2){
            mTarget = GameObject.Find("B");
        }
        if(towards == 3){
            mTarget = GameObject.Find("C");
        }
        if(towards == 4){
            mTarget = GameObject.Find("D");
        }
        Vector3 dir = new Vector3(mTarget.transform.position.x, mTarget.transform.position.y, 0F);
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, dir, speed * Time.deltaTime);
        float dist = Vector3.Distance(dir, transform.localPosition);
        if(dist < 0.1f){
            towards = Random.Range(1, 5);
        }
    }

    private void RandomStyleAttack(){
        attackCount ++;
        if(attackCount == 2){
            timmy.SetActivateAttack();
        }
        if(opt == 1){
            AttackBySplitBullet();
            opt ++;
        }
        else{
            AttackByRandomExplosion();
            opt ++;
            if(opt == 3){
                opt = 0;
            }
        }
    }
    private void AttackBySplitBullet(){
        //Debug.Log("split bullet");
        GameObject e = Instantiate(Resources.Load("Prefabs/SplitBullet") as GameObject); 
        e.transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, -3F) ;
        e.transform.up = transform.up;
        timmy = GameObject.Find("Timmy").GetComponent<TimmyInBoss>();
        e.transform.Rotate(0F, 0F, timmy.transform.localPosition.z);
    }

    private void AttackByRandomExplosion(){
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

    public void LaunchAttackStyleTwo(){
         //Launch Attack
        //for(int i = 1; i <= 8; i++){
        GameObject e = Instantiate(Resources.Load("Prefabs/Explosion") as GameObject); // Prefab MUST BE locaed in Resources/Prefabs folder!
        e.transform.localPosition = attackLocations[posCount];
        posCount++;
        if(posCount == 9) posCount = 1;
        
    }

    public void DestroyBullet(){
        bulletCnt--;
    }

     private void OnTriggerEnter2D(Collider2D collision){
        if((collision.gameObject.name == "Arrow(Clone)")){ 
        
            bloodBox.loseHealth(totalBlood, timmy.atk,blood);
            blood-=timmy.atk;
            Destroy(collision.gameObject);
        }
     }
}
